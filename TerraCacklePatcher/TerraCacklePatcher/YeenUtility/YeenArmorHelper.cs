﻿using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Terraheim.Utility;
using UnityEngine;
using static TerraCacklePatcher.YeenUtility.YeenData;
using static TerraCacklePatcher.YeenUtility.YeenUtilities;
using static TerraCacklePatcher.Log;
using static Terraheim.Utility.Data;

namespace TerraCacklePatcher.YeenUtility
{
    class YeenArmorHelper
    {
        private static JObject balance = UtilityFunctions.GetJsonFromFile("balance.json");
        public static void ModArmorPiece(string setName, string location, ref ItemDrop.ItemData piece, JToken values)
        {
            ArmorSet armor = ArmorSets[setName];
            JToken tierBalance = values;
            if(ValidArmorId(armor, location))
            {
                piece.m_shared.m_name = armor.HelmetName;
                StatusEffect setEffect = ArmorHelper.GetSetEffect((string)values["setEffect"], tierBalance);

                piece.m_shared.m_armor = (float)tierBalance["baseArmor"];
                piece.m_shared.m_armorPerLevel = (float)tierBalance["armorPerLevel"];
                if (setEffect != null)
                    piece.m_shared.m_setStatusEffect = setEffect;
                else
                    Log.LogWarning($"{setName} - No set effect found for provided effect: {(string)values["setEffect"]}");
                piece.m_shared.m_setSize = (setName != "rags" ? 3 : 2);
                piece.m_shared.m_setName = setName;
                if (!piece.m_shared.m_name.Contains("helmet"))
                    piece.m_shared.m_movementModifier = (float)tierBalance["globalMoveMod"];

                piece.m_shared.m_description = $"<i>{armor.ClassName}</i>\n{piece.m_shared.m_description}";

                if (location == "head")
                    piece.m_shared.m_armor += armor.HelmetArmor;

                StatusEffect status = ArmorHelper.GetArmorEffect((string)values[$"{location}Effect"], tierBalance, location, ref piece.m_shared.m_description);

                if ((string)values[$"{location}Effect"] == "challengemvespd")
                    piece.m_shared.m_movementModifier += (float)values[$"{location}EffectVal"];

                if (status != null)
                    piece.m_shared.m_equipStatusEffect = status;
                else
                    Log.LogWarning($"{setName} {location} - No status effect found for provided effect: {(string)values[$"{location}Effect"]}");
            }
            else
            {
            }
        }

        public static void YeenAddArmorPiece(string setName, string location)
        {
            ArmorSet armor = ArmorSets[setName];
            if (ValidArmorId(armor, location)) {
                string setBalanceIntercept = balanceIntercept[setName];
                var setBalance = balance[setBalanceIntercept];
                for (int i = (int)setBalance["upgrades"]["startingTier"]; i <= 5; i++)
                {
                    //var tierBalance = setBalance["upgrades"][$"t{i}"];
                    string id = "";
                    string name = "";
                    switch (location)
                    {
                        case "head":
                            id = armor.HelmetID;
                            name = armor.HelmetName;
                            break;
                        case "chest":
                            id = armor.ChestID;
                            name = armor.ChestName;
                            break;
                        case "legs":
                            id = armor.LegsID;
                            name = armor.LegsName;
                            break;
                        default:
                            break;
                    }

                    //Create mocks for use in clones
                    GameObject clonedPiece = PrefabManager.Instance.CreateClonedPrefab($"{id}T{i}", id);



                    //Set ID so that previous armors still exist
                    string armorSetName = char.ToUpper(setName[0]) + setName.Substring(1);
                    clonedPiece.name = $"{id}T{i}_Terraheim_AddNewSets_Add{armorSetName}Armor";

                    CustomItem piece = new CustomItem(clonedPiece, true);

                    //piece.ItemDrop.m_itemData.m_shared.m_name = $"{name}{i}";
                    piece.ItemDrop.m_itemData.m_shared.m_name = upgradedSet[i]+name;

                    ArmorHelper.ModArmorPiece(setName, location, ref piece.ItemDrop.m_itemData, setBalance, true, i);

                    //Recipes
                    Recipe recipe = ScriptableObject.CreateInstance<Recipe>();

                    recipe.name = $"Recipe_{id}T{i}";

                    List<Piece.Requirement> recipeList = new List<Piece.Requirement>();

                    //Add base armor to requirements
                    int j = 0;
                    if (i == (int)setBalance["upgrades"]["startingTier"])
                    {
                        recipeList.Add(MockRequirement.Create(id, 1, false));
                        j++;
                        recipeList[0].m_amountPerLevel = 0;
                    }

                    var recipeReqs = balance["upgradePath"][$"t{i}"];
                    int index = 0 + j;
                    foreach (JObject item in recipeReqs[location])
                    {
                        recipeList.Add(MockRequirement.Create((string)item["item"], (int)item["amount"]));
                        recipeList[index].m_amountPerLevel = (int)item["perLevel"];
                        index++;
                    }

                    recipe.m_craftingStation = Mock<CraftingStation>.Create((string)recipeReqs["station"]);

                    //Set crafting station level
                    recipe.m_minStationLevel = (int)recipeReqs["minLevel"];

                    //Assign reqs to recipe
                    recipe.m_resources = recipeList.ToArray();

                    //Add item to recipe
                    recipe.m_item = piece.ItemDrop;

                    //Create the custome recipe
                    CustomRecipe customPieceRecipe = new CustomRecipe(recipe, fixReference: true, fixRequirementReferences: true);

                    ItemManager.Instance.AddItem(piece);

                    //Add recipes to DB
                    ItemManager.Instance.AddRecipe(customPieceRecipe);
                }
            }
        }
        public static void YeenAddArmorSet(string setName)
        {
            YeenAddArmorPiece(setName, "head");
            YeenAddArmorPiece(setName, "chest");
            YeenAddArmorPiece(setName, "legs");
        }

        public static void AddYeenTieredRecipes(string YeenArmor, string setBalance)
        {
            string setBalanceIntercept;
            try
            {
                setBalanceIntercept = balanceIntercept[setBalance];
            }
            catch
            {
                setBalanceIntercept = setBalance;
            }
            ArmorSet armor = ArmorSets[YeenArmor];
            string armorSetName = char.ToUpper(YeenArmor[0]) + YeenArmor.Substring(1);
            for (int i = (int)balance[setBalanceIntercept]["upgrades"]["startingTier"] + 1; i <= 5; i++)
            {
                if(armor.HelmetID != "n/a")
                {
                    HelmetRecipe(armor, armorSetName, i);
                }
                
                if (armor.ChestID != "n/a")
                {
                    ChestRecipe(armor, armorSetName, i);
                }
                
                if (armor.LegsID != "n/a")
                {
                    LegsRecipe(armor, armorSetName, i);
                }
                
            }
        }
        public static void HelmetRecipe(ArmorSet armor, string armorSetName, int i)
        {
            Recipe helmetRecipe;
            helmetRecipe = ObjectDB.instance.GetRecipe(ObjectDB.instance.GetItemPrefab($"{armor.HelmetID}T{i}_Terraheim_AddNewSets_Add{armorSetName}Armor").GetComponent<ItemDrop>().m_itemData);
            List<Piece.Requirement> helmetList = helmetRecipe.m_resources.ToList();
            helmetList.Add(new Piece.Requirement()
            {
                m_resItem = ObjectDB.instance.GetItemPrefab($"{armor.HelmetID}T{i - 1}_Terraheim_AddNewSets_Add{armorSetName}Armor").GetComponent<ItemDrop>(),
                m_amount = 1,
                m_amountPerLevel = 0,
                m_recover = false
            });
            helmetRecipe.m_resources = helmetList.ToArray();
        }
        public static void ChestRecipe(ArmorSet armor, string armorSetName, int i)
        {
            Recipe chestRecipe;
            chestRecipe = ObjectDB.instance.GetRecipe(ObjectDB.instance.GetItemPrefab($"{armor.ChestID}T{i}_Terraheim_AddNewSets_Add{armorSetName}Armor").GetComponent<ItemDrop>().m_itemData);
            List<Piece.Requirement> chestList = chestRecipe.m_resources.ToList();
            chestList.Add(new Piece.Requirement()
            {
                m_resItem = ObjectDB.instance.GetItemPrefab($"{armor.ChestID}T{i - 1}_Terraheim_AddNewSets_Add{armorSetName}Armor").GetComponent<ItemDrop>(),
                m_amount = 1,
                m_amountPerLevel = 0,
                m_recover = false
            });
            chestRecipe.m_resources = chestList.ToArray();
        }
        public static void LegsRecipe(ArmorSet armor, string armorSetName, int i)
        {
            Recipe legsRecipe;
            legsRecipe = ObjectDB.instance.GetRecipe(ObjectDB.instance.GetItemPrefab($"{armor.LegsID}T{i}_Terraheim_AddNewSets_Add{armorSetName}Armor").GetComponent<ItemDrop>().m_itemData);
            List<Piece.Requirement> legsList = legsRecipe.m_resources.ToList();
            legsList.Add(new Piece.Requirement()
            {
                m_resItem = ObjectDB.instance.GetItemPrefab($"{armor.LegsID}T{i - 1}_Terraheim_AddNewSets_Add{armorSetName}Armor").GetComponent<ItemDrop>(),
                m_amount = 1,
                m_amountPerLevel = 0,
                m_recover = false
            });
            legsRecipe.m_resources = legsList.ToArray();
        }
    }
}







