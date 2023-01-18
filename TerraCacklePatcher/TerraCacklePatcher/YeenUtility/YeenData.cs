using System.Collections.Generic;
using static Terraheim.Utility.Data;

namespace TerraCacklePatcher.YeenUtility
{
    public class YeenData
    {
        public static void InjectNewArmorSet(string setName, ArmorSet armor)
        {
            //The first idea was to get the asset bundel and pull info from it, however now the idea is to make it so you can apply changes to a template and push it though here to inject it with relative ease.
            //why use this instead of just adding to the dictionary like the hard coded versions below?
            //its mostly for mass additions to the dictionary, however in the state of how it is rn it wont really be useful.
            /*ArmorSets.Add(
                setName, new ArmorSet
                {
                    HelmetID = armor.HelmetID,
                    ChestID = armor.ChestID,
                    LegsID = armor.LegsID,
                    HelmetName = armor.HelmetName,
                    ChestName = armor.ChestName,
                    LegsName = armor.LegsName,
                    ClassName = armor.ClassName,
                    HelmetArmor = armor.HelmetArmor
                });
                ArmorSets["template"] = new ArmorSet
                {
                    HelmetID = "n/a",
                    ChestID = "n/a",
                    LegsID = "n/a",
                    HelmetName = "n/a",
                    ChestName = "n/a",
                    LegsName = "n/a",
                    ClassName = "n/a",
                    HelmetArmor = 2
                };*/
             
             
             
        }
        public static Dictionary<string, Dictionary<string, string>> testDictionary = new Dictionary<string, Dictionary<string, string>>
        {

        };
        public static void InjectManes()
        {
            string[] manes =
            {
                "chMaA1", "chMaA2", "chMaA3",
                //Light colors
                "chMaB1", "chMaB2", "chMaB3",
                //Mid colors
                "chMaC1", "chMaC2", "chMaC3"
                //Dark colors
            };
            string[] armorClass =
            {
                "$class_berserker","$class_ranger","$class_tank",
                "$class_berserker","$class_ranger","$class_tank",
                "$class_berserker","$class_ranger","$class_tank"
            };
            string[] balances =
            {
                "leather", "trollLeather", "bronze", "iron", "silver", "padded"
            };
            string[] appendix =
            {
                "Scout", "Rogue", "Warrior", "Knight", "Archer", "Paladin"
            };
            int i=0;
            int y=0;
            foreach (string mane in manes)
            {
                for (int o=0; o<=1; o++)
                {
                    //setName ch+stored name+the balance string
                    string setName = "ch" + YeenManeSets[mane] + balances[y];
                    ArmorSets.Add(setName, new ArmorSet
                    {
                        HelmetID = mane,
                        ChestID = "n/a",
                        LegsID = "n/a",
                        HelmetName =  YeenManeNames[mane] +" "+ appendix[y],
                        ChestName = "n/a",
                        LegsName = "n/a",
                        ClassName = armorClass[y],
                        HelmetArmor = 2
                    });
                    //add the set and its equivelent balance to the balance intercept dictionary, this is needed for later.
                    balanceIntercept.Add(setName, balances[y]);
                    //checkDictionaryEntry(setName);
                    y++;
                }
                if (y >= 5) 
                {
                    y = 0;
                }
                i++;
            }
        }

        public static void DictionaryInjection()
        {
            //This injects the yeen armor sets into the existing terraheim dictionary
            //I am hoping to make this obsolete somehow and that the addition of armor sets become easier.
            ArmorSets.Add(
            "chRags", new ArmorSet
            {
                HelmetID = "n/a",
                ChestID = "chRaHood",
                LegsID = "chRaPants",
                HelmetName = "n/a",
                ChestName = "Rag Hood",
                LegsName = "Rag Pants",
                ClassName = "$class_challenge",
                HelmetArmor = 0
            });
            ArmorSets.Add(
            "chLeather", new ArmorSet
            {
                HelmetID = "chLeMask",
                ChestID = "chLePoncho",
                LegsID = "chLePants",
                HelmetName = "Leather Mask",
                ChestName = "Leather Poncho",
                LegsName = "Leather Pants",
                ClassName = "$class_berserker",
                HelmetArmor = 0
            });
            ArmorSets.Add(
                "chTrollLeather", new ArmorSet
                {
                    HelmetID = "chTrHat",
                    ChestID = "chTrScarf",
                    LegsID = "chTrPants",
                    HelmetName = "Jotunn Hat",
                    ChestName = "Jotunn Scarf",
                    LegsName = "Jotunn Pants",
                    ClassName = "$class_ranger",
                    HelmetArmor = 0
                });
            ArmorSets.Add(
                "chBronze", new ArmorSet
                {
                    HelmetID = "chBzHelm",
                    ChestID = "chBzChest",
                    LegsID = "chBzPants",
                    HelmetName = "Bronze Helm",
                    ChestName = "Bronze Breastplate",
                    LegsName = "Bronze Chausses",
                    ClassName = "$class_tank",
                    HelmetArmor = 0


                });
            ArmorSets.Add(
                "chIron", new ArmorSet
                {
                    HelmetID = "chIrHelm",
                    ChestID = "chIrChest",
                    LegsID = "chIrSuit",
                    HelmetName = "Iron Helm",
                    ChestName = "Iron Breastplate",
                    LegsName = "Iron Chausses",
                    ClassName = "$class_berserker",
                    HelmetArmor = 2
                });
            ArmorSets.Add(
                "chSilver", new ArmorSet
                {
                    HelmetID = "chWoHelm",
                    ChestID = "chWoCloak",
                    LegsID = "chWoPants",
                    HelmetName = "Drake Helmet",
                    ChestName = "Wolf fur Cloak",
                    LegsName = "Wolf fur pants",
                    ClassName = "$class_ranger",
                    HelmetArmor = 2
                });
            ArmorSets.Add(
                "chPadded", new ArmorSet
                {
                    HelmetID = "chPaHelm",
                    ChestID = "chPaCoat",
                    LegsID = "chPaSuit",
                    HelmetName = "Gambeson Helm",
                    ChestName = "Gambeson Armor",
                    LegsName = "Gambeson Chausses",
                    ClassName = "$class_tank",
                    HelmetArmor = 2
                });
            //template acts as a way to transfer armorset values, meant to be used with the dictionaryinjector.
            /*ArmorSets.Add(
                "template", new ArmorSet
                {
                    HelmetID = "n/a",
                    ChestID = "n/a",
                    LegsID = "n/a",
                    HelmetName = "n/a",
                    ChestName = "n/a",
                    LegsName = "n/a",
                    ClassName = "n/a",
                    HelmetArmor = 2
                });
            //*/


        }
        public static Dictionary<string, string> balanceIntercept = new Dictionary<string, string>
        {
            {"chRags", "rags"},
            {"chLeather", "leather"},
            {"chTrollLeather", "trollLeather"},
            {"chBronze", "bronze"},
            {"chIron", "iron"},
            {"chSilver", "silver"},
            {"chPadded", "padded"}
        };
        public static Dictionary<int, string> upgradedSet = new Dictionary<int, string>
        {
            //This exists as a way to add the tier name to the armor, will be updated in the future for when new armors are added to the game.
            {0, ""},
            {1, "Jotunn Reinforced "},
            {2, "Bronze Reinforced "},
            {3, "Iron Reinforced "},
            {4, "Silver Reinforced "},
            {5, "Padded "},
            {6, "Chiten Reinforced "}
        };
        public static Dictionary<string, string> yeenSkinInfo = new Dictionary<string, string>
        {
            //this is possibly obsolete
            { "Cackle01", "A strange trinket covered in orange moss.  You hear a faint awa when held" },
            { "Cackle02", "A strange trinket covered in brown moss.  You hear a faint awa when held" },
            { "Cackle03", "A strange trinket covered in yellow moss.  You hear a faint awa when held" },
            { "Cackle04", "A strange trinket covered in red moss.  You hear a faint awa when held" },
            { "chWambui", "Like Mama always said, you are what you eat" },
            { "chWambuiA", "Like Mama always said, you are what you eat" },
            { "chWambuiB", "Like Mama always said, you are what you eat" },
            { "chCuan", "Once belonged to a strange creature that is very mouthy" },
            { "chCuanA", "Once belonged to a strange creature that is very doggo, much good" },
            { "chCuanB", "Once belonged to a strange creature that yells" },
            { "chDraca", "Smells a bit Earthy" },
            { "chDracaA", "Smells a bit Airid" },
            { "chDracaB", "Smells a bit Dusty" },
            { "chForsaken", "A strange trinket. Something's different about this one, smells a little off..." }
        };
        public static Dictionary<string, string> yeenSkinNames = new Dictionary<string, string>
        {
            //this is possibly obsolete, unless i decied to make the yeen skins set pieces rather then "capes"
            { "Cackle01", "dey Cackle Totem Tan" },
            { "Cackle02", "dey Cackle Totem Brown" },
            { "Cackle03", "dey Cackle Totem Blond" },
            { "Cackle04", "dey Cackle Totem Red" },
            { "chWambui", "dey Wambui Totem Wheat" },
            { "chWambuiA", "dey Wambui Totem Mud" },
            { "chWambuiB", "dey Wambui Totem Donk" },
            { "chCuan", "dey Cuan Totem Silver" },
            { "chCuanA", "dey Cuan Totem Cream" },
            { "chCuanB", "dey Cuan Totem Cherry" },
            { "chDraca", "dey Draca Totem Dirt" },
            { "chDracaA", "dey Draca Totem Sand" },
            { "chDracaB", "dey Draca Totem Clay" },
            { "chForsaken", "dey Forsaken Totem" }
        };
        public static Dictionary<string, string> YeenManeNames = new Dictionary<string, string>
        {
            {"chMaA1", "Light Mane Cherry" },
            {"chMaA2", "Medium Mane Cherry"},
            {"chMaA3", "Heavy Mane Cherry"},

            {"chMaB1", "Light Mane Chocolate"},
            {"chMaB2", "Medium Mane Chocolate"},
            {"chMaB3", "Heavy Mane Chocolate"},

            {"chMaC1", "Light Mane Strawberry"},
            {"chMaC2", "Medium Mane Strawberry"},
            {"chMaC3", "Heavy Mane Strawberry"}
        };
        public static Dictionary<string, string> YeenManeSets = new Dictionary<string, string>
        {
            {"chMaA1", "LightManeCherry" },
            {"chMaA2", "MediumManeCherry"},
            {"chMaA3", "HeavyManeCherry"},

            {"chMaB1", "LightManeChocolate"},
            {"chMaB2", "MediumManeChocolate"},
            {"chMaB3", "HeavyManeChocolate"},

            {"chMaC1", "LightManeStrawberry"},
            {"chMaC2", "MediumManeStrawberry"},
            {"chMaC3", "HeavyManeStrawberry"}
        };
    }
}