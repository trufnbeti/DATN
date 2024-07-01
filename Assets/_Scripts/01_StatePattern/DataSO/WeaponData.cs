using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{

    public abstract class WeaponData : ScriptableObject, IEquatable<WeaponData>
    {
        public string weaponName;
        public Sprite weaponSprite;
        public float attackRange = 2;
        public int weaponDamage = 1;
        public AudioClip weaponSwingSound;

        public abstract bool CanBeUsed(bool isAgentGrounded);

        public abstract void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction);

        public virtual void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
        {

        }

        public bool Equals(WeaponData other)
        {
            return weaponName == other.weaponName;
        }
    }

}
