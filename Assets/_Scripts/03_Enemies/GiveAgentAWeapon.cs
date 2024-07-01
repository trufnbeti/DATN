using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class GiveAgentAWeapon : MonoBehaviour
    {
        public List<WeaponData> weaponData;

        private void Start()
        {
            Agent agent = GetComponentInChildren<Agent>();
            foreach (var item in weaponData)
            {
                agent.agentWeapon.AddWeaponData(item);
            }
            
        }
    }
}
