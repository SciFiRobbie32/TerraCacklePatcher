using BepInEx;
using HarmonyLib;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using System;
using Terraheim.Utility;

namespace TerraCacklePatcher
{
    [BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("DarnHyena.Cackleheim", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("DasSauerkraut.Terraheim", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInProcess("Valheim.exe")]
    class TerraCacklePatcher : BaseUnityPlugin
    {

        public const string PluginGUID = "SomeActualYeen.CackleheimTerraCacklePatcherPatch";
        public const string PluginName = "CackleTerraPatch";
        public const string PluginVersion = "1.0.3";
        private readonly Harmony harmony = new Harmony("TerraCacklehiem.ValheimMod");
        public void Awake()
        {
            Log.Init(Logger);
            //Log.LogInfo("Cackleheim Terraheim Patch STARTING");
            harmony.PatchAll();
            Init();
            //Log.LogInfo("Cackleheim Terraheim Patch COMPLETE");
        }
        private static JObject balance = UtilityFunctions.GetJsonFromFile("balance.json");
        public static void Init()
        {
            ItemManager.OnItemsRegistered += CHleather;
            ItemManager.OnItemsRegistered += CHTroll;
            ItemManager.OnItemsRegistered += CHBronze;
            ItemManager.OnItemsRegistered += CHIron;
            ItemManager.OnItemsRegistered += CHSilver;
            ItemManager.OnItemsRegistered += CHPadded;
            ItemManager.OnItemsRegistered += CHManes;
            ItemManager.OnItemsRegistered += CHSkins;
        }

        protected static void CHleather()
        {

            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chLeMask");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chLePants");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chLePoncho");

            var setBalance = balance["leather"];

            ArmorHelper.ModArmorSet("leather", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);

        }
        protected static void CHTroll()
        {
            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chTrHat");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chTrPants");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chTrScarf");

            var setBalance = balance["trollLeather"];

            ArmorHelper.ModArmorSet("trollLeather", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
        }
        protected static void CHBronze()
        {
            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chBzHelm");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chBzPants");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chBzChest");

            var setBalance = balance["bronze"];

            ArmorHelper.ModArmorSet("bronze", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
        }
        protected static void CHIron()
        {
            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chIrHelm");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chIrSuit");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chIrChest");

            var setBalance = balance["iron"];

            ArmorHelper.ModArmorSet("iron", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
        }
        protected static void CHSilver()
        {
            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chWoHelm");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chIrSuit");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chIrChest");

            var setBalance = balance["silver"];

            ArmorHelper.ModArmorSet("silver", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
        }
        protected static void CHPadded()
        {
            var helmet = PrefabManager.Cache.GetPrefab<ItemDrop>("chPaHelm");
            var legs = PrefabManager.Cache.GetPrefab<ItemDrop>("chPaSuit");
            var chest = PrefabManager.Cache.GetPrefab<ItemDrop>("chPaCoat");

            var setBalance = balance["padded"];

            ArmorHelper.ModArmorSet("padded", ref helmet.m_itemData, ref chest.m_itemData, ref legs.m_itemData, setBalance, false, -1);
            //public static void ModArmorPiece(string setName, string location, ref ItemDrop.ItemData piece, JToken values, bool isNewSet, int i);
        }
        private static void CHManes()
        {
            string[] manes =
            {
                "chMaA1","chMaA2","chMaA3","chMaB1","chMaB2","chMaB3",
            "chMaC1","chMaC2","chMaC3"
            };
            string[] bal =
            {
                "leather","bronze","silver","leather","bronze","silver","leather","bronze","silver"
            };
            for(int i=0; i <= 8; i++)
            {
                var setBalance = balance[bal[i]];
                var mane = PrefabManager.Cache.GetPrefab<ItemDrop>(manes[i]);
                ArmorHelper.ModArmorPiece(bal[i], "head", ref mane.m_itemData, setBalance, false, -1);
            }
            
        }
        private static void CHSkins()
        {
            string[] skins =
            {
                "Cackle01","Cackle02","Cackle03","Cackle04","chWambui",
            "chWambuiA","chWambuiB","chCuan","chCuanA","chCuanB","chDraca","chDracaA","chDracaB"
            };
            var skin = PrefabManager.Cache.GetPrefab<ItemDrop>("Cackle01"); ;
            var setBalance = balance["capes"];
            for (int i = 0; i <= 12; i++)
            {
                skin = PrefabManager.Cache.GetPrefab<ItemDrop>(skins[i]);
                skin.m_itemData.m_shared.m_description += $"\nHyeena's move fast, Movement speed is increased by <color=cyan>{(float)setBalance["leather"]["capeEffectVal"] * 100 }%</color>.";
                skin.m_itemData.m_shared.m_movementModifier = (float)setBalance["leather"]["capeEffectVal"];
            }

            skin = PrefabManager.Cache.GetPrefab<ItemDrop>("chForsaken");
            skin.m_itemData.m_shared.m_description += $"\nIt smells of musk and rot, must be good for something... ";
            skin.m_itemData.m_shared.m_equipStatusEffect =
            ArmorHelper.GetArmorEffect(
                "lifesteal",
                setBalance["leather"],
                "cape",
                ref skin.m_itemData.m_shared.m_description);
            //"chForsaken"
        }
        /*
         "Cackle01","Cackle02","Cackle03","Cackle04","chForsaken","chWambui",
            "chWambuiA","chWambuiB","chCuan","chCuanA","chCuanB","chDraca","chDracaA","chDracaB"
         */
    }
}
