using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public interface IHittable
    {
        void GetHit(GameObject opponent, int damageAmount);
    }
}
