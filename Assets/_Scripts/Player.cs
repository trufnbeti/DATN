using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Player : MonoBehaviour, ISavingData
    {
        private WeaponManager weaponManager;
        [SerializeField]
        private AgentWeaponManager playerWeapons;

        private void Awake()
        {
            weaponManager = FindObjectOfType<WeaponManager>();
        }
        //private void Awake()
        //{
        //    weaponManager = FindObjectOfType<WeaponManager>();
        //}

        public void SaveData()
        {
            List<string> weaponNames = playerWeapons.GetPlayerWeaponNames();
            if (weaponNames != null && weaponNames.Count > 0) {
                SaveSystem.Weapon = weaponNames;
            }
        }

        public void LoadData()
        {
            List<string> weaponNames = SaveSystem.Weapon;
            if (weaponNames != null)
            {
                foreach (var name in weaponNames)
                {
                    Debug.Log("Loading weapon: " + name);
                    var weapon = weaponManager.GetWeaponWithName(name);
                    playerWeapons.AddWeaponData(weapon);
                }
            }
            else
            {
                Debug.Log("No weapon data to load");
            }
        }
    }
}
