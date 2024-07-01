using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class ThrowableSpawner : MonoBehaviour
    {
        public RangeWeaponData data;
        public Vector2 directionToUse;
        public float delay = 5;
        private float currentTime = 0;
        Collider2D myCollider;
        [SerializeField]
        private LayerMask hittableMask;
        private void Awake()
        {
            myCollider = GetComponent<Collider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime >= delay)
            {
                currentTime = 0;
                GameObject throwable = Instantiate(data.rangeWeaponPrefab, transform.position, Quaternion.identity);
                throwable.GetComponent<ThrowableWeapon>().Intialize(data, directionToUse, hittableMask);
                Physics2D.IgnoreCollision(throwable.GetComponentInChildren<Collider2D>(), myCollider);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position+(Vector3)directionToUse.normalized*2);
        }
    }
}

