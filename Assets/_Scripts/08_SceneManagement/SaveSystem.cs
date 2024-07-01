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


        public static void SaveGameData(int levelIndexToSave)
        {
            
            SaveLevel(levelIndexToSave);
            PlayerPrefs.SetInt(saveDataKey, 1);
        }

        private static void SaveLevel(int levelIndex)
        {
            PlayerPrefs.SetInt(levelKey, levelIndex);
        }

        public static int LoadLevelIndex()
        {
            if (IsSaveDataPreset())
                return PlayerPrefs.GetInt(levelKey);
            return -1;
        }

        private static bool IsSaveDataPreset()
        {
            return PlayerPrefs.GetInt(saveDataKey) == 1;
        }

        public static void SaveWeapons(List<string> weaponNames)
        {

            string data = JsonUtility.ToJson(new PlayerWeapons { playerWeapons = weaponNames });
            PlayerPrefs.SetString(playerWeaponsKey, data);
        }
        public static List<string> LoadWeapons()
        {
            if (IsSaveDataPreset())
            {
                string data = PlayerPrefs.GetString(playerWeaponsKey);
                if (data.Length > 0)
                {
                    return JsonUtility.FromJson<PlayerWeapons>(data).playerWeapons;
                }
            }
            return null;
        }

        
        public static void SavePoints(int amount)
        {
            PlayerPrefs.SetInt(pointsKey, amount);
        }

        public static int LoadPoints()
        {
            return PlayerPrefs.GetInt(pointsKey);
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
