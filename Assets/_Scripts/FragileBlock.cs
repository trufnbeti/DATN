using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class FragileBlock : MonoBehaviour, IHittable
    {
        public UnityEvent OnHit;

        public void GetHit(GameObject opponent, int damageAmount)
        {
            OnHit?.Invoke();
        }

        public void DeastroySelf()
        {
            Destroy(gameObject);
        }
    }
}
