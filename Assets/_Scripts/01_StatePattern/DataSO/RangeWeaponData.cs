using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapons/RangeWeaponData")]
    public class RangeWeaponData : WeaponData
    {
        public GameObject rangeWeaponPrefab;
        public float weaponThrowSpeed = 1;

        public override bool CanBeUsed(bool isAgentGrounded)
        {
            return true;
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            agent.agentWeapon.ToggleWeaponVisibility(false);
            GameObject throwable = Instantiate(rangeWeaponPrefab, agent.agentWeapon.transform.position, Quaternion.identity);
            throwable.GetComponent<ThrowableWeapon>().Intialize(this, direction, hittableMask);
        }
    }
}
