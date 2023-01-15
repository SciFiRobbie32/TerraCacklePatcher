using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using Terraheim.Utility;

namespace TerraCacklePatcher.YeenArmor
{
    public class ModExistingSets
    {
        private static JObject balance = UtilityFunctions.GetJsonFromFile("balance.json");
        public static void Init()
        {
            //ItemManager.OnItemsRegistered += CHRags;
            ItemManager.OnItemsRegistered += CHleather;
            ItemManager.OnItemsRegistered += CHTroll;
            ItemManager.OnItemsRegistered += CHBronze;
            ItemManager.OnItemsRegistered += CHIron;
            ItemManager.OnItemsRegistered += CHSilver;
            ItemManager.OnItemsRegistered += CHPadded;
            ItemManager.OnItemsRegistered += CHManes;
            ItemManager.OnItemsRegistered += CHSkins;
        }
        protected static void CHRags()
        {
        }
        protected static void CHleather()
        {
            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chLeMask");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chLePants");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chLePoncho");

            var setBalance = balance["leather"];

            ArmorHelper.ModArmorSet("chLeather", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
            Log.LogInfo("---------------------------------------------------------------CHLeather---------------------------------------------------------------");

        }
        protected static void CHTroll()
        {
            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chTrHat");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chTrPants");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chTrScarf");

            var setBalance = balance["trollLeather"];

            ArmorHelper.ModArmorSet("chTrollLeather", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
            Log.LogInfo("---------------------------------------------------------------CHtrollLeather---------------------------------------------------------------");
        }
        protected static void CHBronze()
        {
            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chBzHelm");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chBzPants");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chBzChest");

            var setBalance = balance["bronze"];

            ArmorHelper.ModArmorSet("chBronze", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
            Log.LogInfo("---------------------------------------------------------------CHBronze---------------------------------------------------------------");
        }
        protected static void CHIron()
        {
            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chIrHelm");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chIrSuit");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chIrChest");

            var setBalance = balance["iron"];

            ArmorHelper.ModArmorSet("chIron", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
            Log.LogInfo("---------------------------------------------------------------CHIron---------------------------------------------------------------");
        }
        protected static void CHSilver()
        {
            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chWoHelm");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chWoPants");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chWoCloak");

            var setBalance = balance["silver"];

            ArmorHelper.ModArmorSet("chSilver", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
            Log.LogInfo("---------------------------------------------------------------CHSilver---------------------------------------------------------------");
        }
        protected static void CHPadded()
        {
            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chPaHelm");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chPaSuit");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chPaCoat");

            var setBalance = balance["padded"];

            ArmorHelper.ModArmorSet("chPadded", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
            //dictionary ingection
            //pass all the data over
            //viola
            Log.LogInfo("---------------------------------------------------------------CHPadded---------------------------------------------------------------");
        }
        private static void CHManes()
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
                "leather","bronze","silver",
                "leather","bronze","silver",
                "leather","bronze","silver"
            };
            for (int i = 0; i <= 8; i++)
            {
                var setBalance = balance[bal[i]];
                var mane = PrefabManager.Cache.GetPrefab<ItemDrop>(manes[i]);
                ArmorHelper.ModArmorPiece(manes[i], location, ref mane.m_itemData, setBalance, false, -1);
            }
            Log.LogInfo("---------------------------------------------------------------CHManes---------------------------------------------------------------");

        }
        private static void CHSkins()
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
            }

            skin = PrefabManager.Cache.GetPrefab<ItemDrop>(skins[13]);
            skin.m_itemData.m_shared.m_description += $"\nIt smells of musk and rot, must be good for something... ";
            skin.m_itemData.m_shared.m_equipStatusEffect =
            ArmorHelper.GetArmorEffect(
                "lifesteal",
                setBalance["leather"],
                "cape",
                ref skin.m_itemData.m_shared.m_description);
            Log.LogInfo("---------------------------------------------------------------CHSkins---------------------------------------------------------------");
        }
    }
}
