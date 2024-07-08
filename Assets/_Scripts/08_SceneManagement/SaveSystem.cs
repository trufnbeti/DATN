using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Platformer
{
    public static class SaveSystem
    {
        public static string pointsKey = "Points";
        public static string playerWeaponsKey = "PlayerWeapons";
        public static string levelKey = "LevelKey";
        private static string saveDataKey = "saveDataKey";
            
        public static void SaveGameData(int levelIndexToSave) {
            Level = levelIndexToSave;
            PlayerPrefs.SetInt(saveDataKey, 1);
        }

        public static int Level {
            set => PlayerPrefs.SetInt(levelKey, value);
            get {
                if (IsSaveDataPreset())
                    return PlayerPrefs.GetInt(levelKey);
                return -1;
            }
        }

        public static List<string> Weapon {
            set {
                string data = JsonUtility.ToJson(new PlayerWeapons { playerWeapons = value });
                PlayerPrefs.SetString(playerWeaponsKey, data);
            }
            get {
                if (IsSaveDataPreset()) {
                    string data = PlayerPrefs.GetString(playerWeaponsKey);
                    if (data.Length > 0) {
                        return JsonUtility.FromJson<PlayerWeapons>(data).playerWeapons;
                    }
                }
                return null;
            }
        }
        
        public static int Point {
            set => PlayerPrefs.SetInt(pointsKey, value);
            get => PlayerPrefs.GetInt(pointsKey);
        }
        
        private static bool IsSaveDataPreset()
        {
            return PlayerPrefs.GetInt(saveDataKey) == 1;
        }
        
        public static void ResetSaveData()
        {
            PlayerPrefs.DeleteKey(pointsKey);
            PlayerPrefs.DeleteKey(playerWeaponsKey);
            PlayerPrefs.DeleteKey(levelKey);
            PlayerPrefs.DeleteKey(saveDataKey);
        }

        private struct PlayerWeapons
        {
            public List<string> playerWeapons;
        }
    }
}
