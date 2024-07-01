using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class WeaponPickable : Pickable
    {
        public WeaponData weaponData;

        private void Start()
        {
            spriteRenderer.sprite = weaponData.weaponSprite;
        }
        public override void PickUp(Agent player)
        {
            player.PickUp(weaponData);
        }
    }
}
