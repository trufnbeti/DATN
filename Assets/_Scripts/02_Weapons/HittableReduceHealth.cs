using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class HittableReduceHealth : MonoBehaviour, IHittable
    {
        public Damagable damagable;

        private void Awake()
        {
            damagable = damagable == null ? GetComponent<Damagable>() : damagable;
        }
        public void GetHit(GameObject opponent, int damageAmount)
        {
            if (damagable == null)
                return;
            damagable.GetHit(damageAmount);
        }
    }
}
