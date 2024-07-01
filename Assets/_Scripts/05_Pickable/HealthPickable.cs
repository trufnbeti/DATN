using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class HealthPickable : Pickable
    {
        public int healthBoost = 1;
        public override void PickUp(Agent player)
        {
            player.GetComponent<Damagable>().AddHealth(healthBoost);
        }
    }
}
