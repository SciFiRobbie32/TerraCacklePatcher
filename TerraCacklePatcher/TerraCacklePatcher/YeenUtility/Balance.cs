/*
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraheim.Utility;

namespace TerraCacklePatcher.YeenUtility
{
    public class Balance { 
        //This is for for custom set balances to be added with relative ease,-
        //This will also allow the current graphical problem that causes the info box in game to glitch out by making sets-
        //that are using other set data to be counted as a completely different set.

        //Implimentation of this code will not replace the existing set balance but will allow new set balances to be added with relative ease.
        public class SetValue
        {
            public string Set { get; set; }
            public int baseArmor { get; set; }
            public int armorPerLevel { get; set; }
            public int moveMod { get; set; }
            public string setEffect { get; set; }
            public string headEffect { get; set; }
            public string chestEffect { get; set; }
            public string legsEffect { get; set; }
            public double setBonusValue { get; set; }
            public double setActivationHP { get; set; }
            public double setRegenBonus { get; set; }
            public double headEffectVal { get; set; }
            public double chestEffectVal { get; set; }
            public double legsEffectVal { get; set; }
            public double capeEffectVal { get; set; }
            public int startTier { get; set; }

        }
        public class SetTier
        {
            public string tier { get; set; }
            public int baseArmor { get; set; }
            public int armorPerLevel { get; set; }
            public int moveMod { get; set; }
            public double setBonusVal { get; set; }
            public double setActiveVal { get; set; }
            public double headEffectVal { get; set; }
            public double chestEffectVal { get; set; }
            public double legsEffectVal { get; set; }

        }
        public static Dictionary<string, SetValue> setValues = new Dictionary<string, SetValue>
        {
        };
        public static Dictionary<int, SetTier> setTiers = new Dictionary<int, SetTier>
        {
        };
        //public static Dictionary<string, Dictionary<string,string>> balanceDictionary = new Dictionary<string, Dictionary<string, string>>
        public static Dictionary<string, Dictionary<string,SetValue>> balanceDictionary = new Dictionary<string, Dictionary<string, SetValue>>
        {

        };
        public static void InjectSetBalances()
        {
            //This will inject the balance.json set info into the dictionarys.
            JObject balance = UtilityFunctions.GetJsonFromFile("balance.json");
            string[] sets = { "rags", "leather", "trollLeather", "bronze", "iron", "silver", "padded" };
            foreach (string set in sets)
            {
                var jBalance = balance[set];
                SetValue value = new SetValue{};
                //strings
                value.Set = (string)Info(jBalance["name"]);
                value.setEffect = (string)Info(jBalance["setEffect"]);
                value.headEffect = (string)Info(jBalance["headEffect"]);
                value.chestEffect = (string)Info(jBalance["chestEffect"]);
                value.legsEffect = (string)Info(jBalance["legsEffect"]);
                //ints
                value.baseArmor = (int)Info(jBalance["baseArmor"]);
                value.armorPerLevel = (int)Info(jBalance["armorPerLevel"]);
                value.moveMod = (int)Info(jBalance["globalMoveMod"]);
                value.startTier = (int)Info(jBalance["upgrades"]["startingTier"]);
                //doubles
                value.setBonusValue = (double)Info(jBalance["setBonusval"]);
                value.setActivationHP = (double)Info(jBalance["setActivationHP"]);
                value.headEffectVal = (double)Info(jBalance["headEffectVal"]);
                value.chestEffectVal = (double)Info(jBalance["chestEffectVal"]);
                value.legsEffectVal = (double)Info(jBalance["legsEffectVal"]);
                value.capeEffectVal = (double)Info(jBalance["capeEffectVal"]);
                
                setValues.Add(set, value);
            }
        }
        public static Object Info(Object value)
        {
            bool exists = DoesHave(value);
            if (exists)
            {

            } else
            {

            }
            return value;
        }
        public static bool DoesHave(Object value)
        {
            bool virdict=false;
            try
            {
                string obToString = value.ToString();
                Log.LogDebug(obToString);
            }
            catch
            {
                virdict = false;
            }
            return virdict;
        }
    }
}
//*/
