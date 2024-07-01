using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "NewWeaponData", menuName = "Weapons/MeleeWeaponData")]
    public class MeleeWeaponData : WeaponData
    {

        public override bool CanBeUsed(bool isAgentGrounded)
        {
            return isAgentGrounded == true;
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            RaycastHit2D hit = Physics2D.Raycast(agent.agentWeapon.transform.position, direction, attackRange, hittableMask);
            if (hit.collider != null)
            {
                foreach (var hittable in hit.collider.GetComponents<IHittable>())
                {
                    hittable.GetHit(agent.gameObject, weaponDamage);
                }
            }
        }

        public override void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
        {
           Gizmos.DrawLine(origin, origin + direction * attackRange);
        }
    }
}
