using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class WeaponManager : MonoBehaviour
    {
        public List<WeaponData> weaponList;
        Dictionary<string, WeaponData> weaponDictionary = new Dictionary<string, WeaponData>();

        private void Awake()
        {
            AddToDictionary(weaponList);
        }

        private void AddToDictionary(List<WeaponData> weaponList)
        {
            foreach (var item in weaponList)
            {
                weaponDictionary.Add(item.name, item);
            }
        }

        public WeaponData GetWeaponWithName(string name)
        {
            if (weaponDictionary.ContainsKey(name))
                return weaponDictionary[name];
            return null;
        }
    }
}
