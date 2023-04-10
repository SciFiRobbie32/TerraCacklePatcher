using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using static TerraCacklePatcher.YeenUtility.YeenData;
using static TerraCacklePatcher.YeenUtility.YeenUtilities;
using Terraheim.Utility;
using static Terraheim.Utility.Data;
using TerraCacklePatcher.YeenUtility;

namespace TerraCacklePatcher.YeenArmor
{
    public class ModExistingSets
    {
        private static JObject balance = UtilityFunctions.GetJsonFromFile("balance.json");
        public static void Init()
        {
            //Tangent, i might add in my own balance json file for the yeen armor, allowing me to alter the effects with relative ease.
            //Tangent 2, and rather then being a json file i could attempt using a dictionary which would allow the addition of new sets, however this might not be as easy as it sounds. will look into.
            try
            {
                ItemManager.OnItemsRegistered += modSet;
            }
            catch
            {
                Log.LogError("---------------------------------------------------------------modSet Encountered an error---------------------------------------------------------------");
            }
            try
            {
                ItemManager.OnItemsRegistered += CHSkins;
            }
            catch
            {
                Log.LogError("---------------------------------------------------------------CHSkins Encountered an error---------------------------------------------------------------");
            }
            try
            {
                ItemManager.OnItemsRegistered += CHManes;
            }
            catch
            {
                Log.LogError("---------------------------------------------------------------CHManes Encountered an error---------------------------------------------------------------");
            }
            
            

        }
        public static void modSet()
        {
            string[] sets = { "chLeather", "chTrollLeather", "chBronze", "chIron", "chSilver", "chPadded" };
            foreach (string set in sets)
            {
                string setBalanceIntercept = balanceIntercept[set];
                ArmorSet armor = ArmorSets[set];
                var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>(armor.HelmetID);
                var chest = PrefabManager.Cache.GetPrefab<ItemDrop>(armor.ChestID);
                var legs = PrefabManager.Cache.GetPrefab<ItemDrop>(armor.LegsID);


                var setBalance = balance[setBalanceIntercept];

                ArmorHelper.ModArmorSet(set, ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
            }
            
        }
        public static void CHManes()
        {
            string location = "head";
            string[] manes =
            {
                "chMaA1","chMaA2","chMaA3", //Light colors
                "chMaB1","chMaB2","chMaB3", //Mid colors
                "chMaC1","chMaC2","chMaC3" //Dark colors
            };
            string[] bal =
            {
                "leather","trollLeather",
                "bronze","iron",
                "silver","padded"
            };
            int i = 0;
            int y = 0;
            foreach (string mane in manes)
            {
                for (int o = 0; o <= 1; o++)
                {
                    string setName = "ch" + YeenManeSets[mane] + bal[y];
                    var Mane = PrefabManager.Cache.GetPrefab<ItemDrop>(mane);
                    var setBalance = balance[bal[y]];
                    if (y % 2 != 0)
                    {
                        YeenArmorHelper.ModArmorPiece(setName, location, ref Mane.m_itemData, setBalance);

                    }
                    
                    y++;
                }
                if (y >= 5)
                {
                    y = 0;
                }
                i++;
            }
        }
        public static void CHSkins()
        {
            string[] skins =
            {
                "Cackle01", //0
                "Cackle02", //1
                "Cackle03", //2
                "Cackle04", //3

                "chWambui", //4
                "chWambuiA",//5
                "chWambuiB",//6

                "chCuan",   //7
                "chCuanA",  //8
                "chCuanB",  //9

                "chDraca",  //10
                "chDracaA", //11
                "chDracaB", //12
                "chForsaken" //13
            };
            var skin = PrefabManager.Cache.GetPrefab<ItemDrop>("Cackle01");
            var setBalance = balance["capes"];
            for (int i = 0; i <= 12; i++)
            {
                skin = PrefabManager.Cache.GetPrefab<ItemDrop>(skins[i]);
                skin.m_itemData.m_shared.m_description += $"\nHyeena's move fast, Movement speed is increased by <color=cyan>{(float)setBalance["leather"]["capeEffectVal"] * 100 }%</color>.";
                skin.m_itemData.m_shared.m_movementModifier = (float)setBalance["leather"]["capeEffectVal"];
                skin.m_itemData.m_shared.m_equipStatusEffect = ArmorHelper.GetArmorEffect((string)setBalance["trollLeather"]["effect"], setBalance["trollLeather"], "cape", ref skin.m_itemData.m_shared.m_description);


            }
            skin = PrefabManager.Cache.GetPrefab<ItemDrop>(skins[13]);
            skin.m_itemData.m_shared.m_description += $"\nHyeena's move fast, Movement speed is increased by <color=cyan>{(float)setBalance["leather"]["capeEffectVal"] * 100 }%</color>.";
            skin.m_itemData.m_shared.m_movementModifier = (float)setBalance["leather"]["capeEffectVal"];
            skin.m_itemData.m_shared.m_equipStatusEffect =
                ArmorHelper.GetArmorEffect(
                    "lifesteal",
                    setBalance["leather"],
                    "cape",
                    ref skin.m_itemData.m_shared.m_description);
        }
    }
}
