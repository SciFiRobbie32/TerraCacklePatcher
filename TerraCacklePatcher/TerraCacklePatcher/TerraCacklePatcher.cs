using BepInEx;
using TerraCacklePatcher.YeenUtility;
using HarmonyLib;

namespace TerraCacklePatcher
{
    [BepInDependency("com.jotunn.jotunn", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("DarnHyena.Cackleheim", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("DasSauerkraut.Terraheim", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("SomeActualYeen.CackleheimTerraCacklePatcherPatch", "CackleTerraPatch", "1.1.5")]
    [BepInProcess("Valheim.exe")]
    internal class TerraCacklePatcher : BaseUnityPlugin
    {

        public const string PluginGUID = "SomeActualYeen.CackleheimTerraCacklePatcherPatch";

        public const string PluginName = "CackleTerraPatch";

        public const string PluginVersion = "0.0.2";

        private readonly Harmony harmony = new Harmony("TerraCacklehiem.ValheimMod");
        public void Awake()
        {
            Log.Init(base.Logger);
            harmony.PatchAll();
            YeenData.DictionaryInjection();
            ModExistingSets.Init();
            AddNewSets.Init();
        }
    }
}
