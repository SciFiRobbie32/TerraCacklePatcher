using System.Collections.Generic;
using Terraheim.Utility;

namespace TerraCacklePatcher.YeenUtility
{
	public class YeenData
	{
		public static Dictionary<string, string> balanceIntercept = new Dictionary<string, string>
		{
			{ "chRags", "rags" },
			{ "chLeather", "leather" },
			{ "chTrollLeather", "trollLeather" },
			{ "chBronze", "bronze" },
			{ "chIron", "iron" },
			{ "chSilver", "silver" },
			{ "chPadded", "padded" }
		};

		public static void DictionaryInjection()
		{
			Data.ArmorSets.Add("chRags", new Data.ArmorSet
			{
				HelmetID = "n/a",
				ChestID = "chRaHood",
				LegsID = "chRaPants",
				HelmetName = "n/a",
				ChestName = "$item_chest_rags_t",
				LegsName = "$item_legs_rags_t",
				ClassName = "$class_challenge",
				HelmetArmor = 0
			});
			Data.ArmorSets.Add("chLeather", new Data.ArmorSet
			{
				HelmetID = "chLeMask",
				ChestID = "chLePoncho",
				LegsID = "chLePants",
				HelmetName = "$item_helmet_leather_t",
				ChestName = "$item_chest_leather_t",
				LegsName = "$item_legs_leather_t",
				ClassName = "$class_berserker",
				HelmetArmor = 0
			});
			Data.ArmorSets.Add("chTrollLeather", new Data.ArmorSet
			{
				HelmetID = "chTrHat",
				ChestID = "chTrScarf",
				LegsID = "chTrPants",
				HelmetName = "$item_helmet_trollleather_t",
				ChestName = "$item_chest_trollleather_t",
				LegsName = "$item_legs_trollleather_t",
				ClassName = "$class_ranger",
				HelmetArmor = 0
			});
			Data.ArmorSets.Add("chBronze", new Data.ArmorSet
			{
				HelmetID = "chBzHelm",
				ChestID = "chBzChest",
				LegsID = "chBzPants",
				HelmetName = "$item_helmet_bronze_t",
				ChestName = "$item_chest_bronze_t",
				LegsName = "$item_legs_bronze_t",
				ClassName = "$class_tank",
				HelmetArmor = 0
			});
			Data.ArmorSets.Add("chIron", new Data.ArmorSet
			{
				HelmetID = "chIrHelm",
				ChestID = "chIrChest",
				LegsID = "chIrSuit",
				HelmetName = "$item_helmet_iron_t",
				ChestName = "$item_chest_iron_t",
				LegsName = "$item_legs_iron_t",
				ClassName = "$class_berserker",
				HelmetArmor = 2
			});
			Data.ArmorSets.Add("chSilver", new Data.ArmorSet
			{
				HelmetID = "chWoHelm",
				ChestID = "chWoCloak",
				LegsID = "chWoPants",
				HelmetName = "$item_helmet_drake_t",
				ChestName = "$item_chest_wolf_t",
				LegsName = "$item_legs_wolf_t",
				ClassName = "$class_ranger",
				HelmetArmor = 2
			});
			Data.ArmorSets.Add("chPadded", new Data.ArmorSet
			{
				HelmetID = "chPaHelm",
				ChestID = "chPaCoat",
				LegsID = "chPaSuit",
				HelmetName = "$item_helmet_padded_t",
				ChestName = "$item_chest_padded_t",
				LegsName = "$item_legs_padded_t",
				ClassName = "$class_tank",
				HelmetArmor = 2
			});
		}
	}
}