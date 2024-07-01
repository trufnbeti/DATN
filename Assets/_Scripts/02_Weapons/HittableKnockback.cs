using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class HittableKnockback : MonoBehaviour, IHittable
    {
        public Rigidbody2D rb2d;
        public float force = 10;

        private void Awake()
        {
            if (rb2d == null)
                rb2d = GetComponent<Rigidbody2D>();
        }
        public void GetHit(GameObject opponent, int damageAmount)
        {
            var direction = transform.position - opponent.transform.position;
            rb2d.AddForce(new Vector2(direction.normalized.x,0) * force, ForceMode2D.Impulse);
        }
    }
}
