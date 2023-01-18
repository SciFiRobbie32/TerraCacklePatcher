
using Jotunn.Entities;
using Jotunn.Managers;
using Newtonsoft.Json.Linq;
using UnityEngine;
using static Terraheim.Utility.Data;

namespace TerraCacklePatcher.YeenUtility
{
    public class YeenUtilities
    {
        /*public static void CreateCloneSet(string setName, int cVariation, JToken setBalance)
        {
            ArmorSet armor = ArmorSets[setName];
            string[] armorPieces = { armor.HelmetID, armor.ChestID, armor.LegsID};
            foreach(string armorPiece in armorPieces)
            {
                CreateClonePiece(armorPiece,setName,"",cVariation,setBalance);
            }
        }//*/
        public static void CreateClonePieceMod(string setName, string location, JToken setBalance)
        {
            ArmorSet armor = ArmorSets[setName];
            if (ValidArmorId(armor, location))
            {
                string id = "";
                string name = "";
                switch (location)
                {
                    case "head":
                        id = armor.HelmetID;
                        name = armor.HelmetName;
                        break;
                    case "chest":
                        id = armor.ChestID;
                        name = armor.ChestName;
                        break;
                    case "legs":
                        id = armor.LegsID;
                        name = armor.LegsName;
                        break;
                }
                GameObject clonedArmorPiece = PrefabManager.Instance.CreateClonedPrefab(id+"3", id);
                CustomItem piece = new CustomItem(clonedArmorPiece, true);
                ItemManager.Instance.AddItem(piece);
                YeenArmorHelper.ModArmorPiece(setName, location, ref piece.ItemDrop.m_itemData, setBalance);
            }
            else
            {
                Log.LogWarning("CreateClonePiece: "+setName+" "+location+" invalid");
                Log.LogWarning(armor);
            }
        }
        public static void CreateClonePiece(string setName, string location, int cVariation)
        {
            ArmorSet armor = ArmorSets[setName];
            if (ValidArmorId(armor, location))
            {
                string id = "";
                switch (location)
                {
                    case "head":
                        id = armor.HelmetID;
                        armor.HelmetID = armor.HelmetID + cVariation;
                        location = "head";
                        break;
                    case "chest":
                        id = armor.ChestID;
                        armor.ChestID = armor.ChestID + cVariation;
                        location = "chest";
                        break;
                    case "legs":
                        id = armor.LegsID;
                        armor.LegsID = armor.LegsID + cVariation;
                        location = "legs";
                        break;
                }
                GameObject clonedArmorPiece = PrefabManager.Instance.CreateClonedPrefab(id + cVariation, id);
                CustomItem piece = new CustomItem(clonedArmorPiece, true);
                ItemManager.Instance.AddItem(piece);
                ArmorSets[setName] = armor;
                YeenArmorHelper.YeenAddArmorPiece(setName, location);
            }
            else
            {
                Log.LogWarning("CreateClonePiece: " + setName + " " + location + " invalid");
                Log.LogWarning(armor);
            }

        }
        public static bool ValidArmorId(ArmorSet armor, string location)
        {
            bool setChecker = false;
            switch (location)
            {
                case "head":
                    if (armor.HelmetID != "n/a")
                    {
                        setChecker = true;
                    }
                    break;
                case "chest":
                    if (armor.ChestID != "n/a")
                    {
                        setChecker = true;
                    }
                    break;
                case "legs":
                    if (armor.LegsID != "n/a")
                    {
                        setChecker = true;
                    }
                    break;
            }
            return setChecker;
        }
    }
}
