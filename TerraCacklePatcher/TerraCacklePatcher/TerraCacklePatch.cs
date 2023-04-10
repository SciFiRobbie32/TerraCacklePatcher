using BepInEx;
using HarmonyLib;
using TerraCacklePatcher.YeenUtility;


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
        public const string PluginVersion = "0.1.3";
        private readonly Harmony harmony = new Harmony("TerraCacklehiem.ValheimMod");
        public void Awake()
        {
            Log.Init(Logger);
            harmony.PatchAll();
            var checker = true;
            try
            {
                YeenData.DictionaryInjection();
            }
            catch
            {
                Log.LogError("---------------------------------------------------------------DictionaryInjection Encountered an error---------------------------------------------------------------");
                checker = false;
            }
            try
            {
                YeenData.InjectManes();
            }
            catch
            {
                Log.LogError("---------------------------------------------------------------InjectManes Encountered an error---------------------------------------------------------------");
            }
            if (checker)
            {
                YeenArmor.ModExistingSets.Init();
                YeenArmor.AddNewSets.Init();
                Log.LogInfo(PluginName + " Loaded!");
            }
            else
            {
                Log.LogError("---------------------------------------------------------------"+PluginName+": "+PluginVersion+" Encountered an error and could not load---------------------------------------------------------------");
            }
            
        }
    }
}
