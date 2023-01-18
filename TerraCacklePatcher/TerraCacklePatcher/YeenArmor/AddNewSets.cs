using Jotunn.Managers;
using TerraCacklePatcher.YeenUtility;
using static TerraCacklePatcher.YeenUtility.YeenData;
using static TerraCacklePatcher.YeenUtility.YeenUtilities;

namespace TerraCacklePatcher.YeenArmor
{
    public class AddNewSets
    {
        public static void Init()
        {
            ItemManager.OnVanillaItemsAvailable += YeenAddArmorSets;
            ItemManager.OnItemsRegistered += ModExistingRecipes;
        }
        public static void YeenAddArmorSets()
        {
            Log.LogMessage("Adding Yeen ArmorSets");
            //replace with loop later
            YeenArmorHelper.YeenAddArmorSet("chRags");
            YeenArmorHelper.YeenAddArmorSet("chLeather");
            YeenArmorHelper.YeenAddArmorSet("chTrollLeather");
            YeenArmorHelper.YeenAddArmorSet("chBronze");
            YeenArmorHelper.YeenAddArmorSet("chIron");
            YeenArmorHelper.YeenAddArmorSet("chSilver");
            YeenArmorHelper.YeenAddArmorSet("chPadded");
            AddManes();
        }
        public static void AddManes()
        {
            string[] manes =
            {
                "chMaA1","chMaA2","chMaA3",
                //Light colors
                "chMaB1","chMaB2","chMaB3",
                //Mid colors
                "chMaC1","chMaC2","chMaC3"
                //Dark colors
            };
            string[] armorClass =
            {
                "$class_berserker","$class_ranger","$class_tank","$class_berserker","$class_ranger","$class_tank","$class_berserker","$class_ranger","$class_tank"
            };
            string[] balances =
            {
                "leather","trollLeather","bronze","iron","silver","padded"
            };
            int i = 0;
            int y = 0;
            foreach (string mane in manes)
            {
                for (int o = 0; o <= 1; o++)
                {
                    string setName = "ch" + YeenManeSets[mane] + balances[y];

                    
                    if (y % 2 != 0)
                    {
                        CreateClonePiece(setName, "head", 2);
                        
                    }
                    else 
                    {
                        YeenArmorHelper.YeenAddArmorPiece(setName, "head");
                        

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
        private static void ModExistingRecipes()
        {
            YeenArmorHelper.AddYeenTieredRecipes("chRags","rags");
            YeenArmorHelper.AddYeenTieredRecipes("chLeather", "leather");
            YeenArmorHelper.AddYeenTieredRecipes("chTrollLeather", "trollLeather");
            YeenArmorHelper.AddYeenTieredRecipes("chBronze", "bronze");
            YeenArmorHelper.AddYeenTieredRecipes("chIron", "iron");
            YeenArmorHelper.AddYeenTieredRecipes("chSilver", "silver");
        }
    }
}