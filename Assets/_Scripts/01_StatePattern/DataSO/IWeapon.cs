using UnityEngine;

namespace Platformer
{
    public interface IWeapon
    {
        bool CanBeUsed(bool isAgentGrounded);
        void DrawWeaponGizmo(Vector3 origin, Vector3 direction);
        void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction);
    }
}