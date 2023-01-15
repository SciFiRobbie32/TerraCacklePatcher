using Jotunn.Managers;
using TerraCacklePatcher.YeenUtility;

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
			Log.LogInfo("Adding Yeen ArmorSets");
			YeenArmorHelper.YeenAddArmorSet("chRags");
			YeenArmorHelper.YeenAddArmorSet("chLeather");
			YeenArmorHelper.YeenAddArmorSet("chTrollLeather");
			YeenArmorHelper.YeenAddArmorSet("chBronze");
			YeenArmorHelper.YeenAddArmorSet("chIron");
			YeenArmorHelper.YeenAddArmorSet("chSilver");
			YeenArmorHelper.YeenAddArmorSet("chPadded");
		}

		private static void ModExistingRecipes()
		{
			YeenArmorHelper.AddYeenTieredRecipes("chRags", "rags");
			YeenArmorHelper.AddYeenTieredRecipes("chLeather", "leather");
			YeenArmorHelper.AddYeenTieredRecipes("chTrollLeather", "trollLeather");
			YeenArmorHelper.AddYeenTieredRecipes("chBronze", "bronze");
			YeenArmorHelper.AddYeenTieredRecipes("chIron", "iron");
			YeenArmorHelper.AddYeenTieredRecipes("chSilver", "silver");
		}
	}
}
