using BepInEx.Logging;
using System;
using System.Collections.Generic;
using static Terraheim.Utility.Data;

namespace TerraCacklePatcher
{
    public  static class Log
    {
        public static ManualLogSource _logSource;

        public static void Init(ManualLogSource logSource)
        {
            _logSource = logSource;
        }

        public static void LogDebug(object data) => _logSource.LogDebug(data);
        public static void LogError(object data) => _logSource.LogError(data);
        public static void LogFatal(object data) => _logSource.LogFatal(data);
        public static void LogInfo(object data) => _logSource.LogInfo(data);
        public static void LogMessage(object data) => _logSource.LogMessage(data);
        public static void LogWarning(object data) => _logSource.LogWarning(data);

        public static void checkDictionary()
        {
            foreach (KeyValuePair<string, ArmorSet> entry in ArmorSets)
            {
                Log.LogInfo("------------------------------------------------------------------------------------------------------------------------------");
                Log.LogInfo("---------------------------------------------------------------" + entry.Key + "---------------------------------------------------------------");
                Log.LogInfo("---------------------------------------------------------------" + entry.Value.HelmetID + "---------------------------------------------------------------");
                Log.LogInfo("---------------------------------------------------------------" + entry.Value.HelmetName + "---------------------------------------------------------------");
                Log.LogInfo("---------------------------------------------------------------" + entry.Value.ChestName + "---------------------------------------------------------------");
                Log.LogInfo("---------------------------------------------------------------" + entry.Value.ChestID + "---------------------------------------------------------------");
                Log.LogInfo("---------------------------------------------------------------" + entry.Value.LegsID + "---------------------------------------------------------------");
                Log.LogInfo("---------------------------------------------------------------" + entry.Value.LegsName + "---------------------------------------------------------------");
                Log.LogInfo("------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public static void LogInfo()
        {
            throw new NotImplementedException();
        }
    }
}