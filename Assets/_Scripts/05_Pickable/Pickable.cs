using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public abstract class Pickable : MonoBehaviour
    {
        protected SpriteRenderer spriteRenderer;

        [SerializeField]
        protected Color gizmoColor = Color.magenta;
        

        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        public abstract void PickUp(Agent player);


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")){
                PickUp(collision.GetComponent<Agent>());
                Destroy(gameObject);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;
            var pickableCollider = GetComponent<BoxCollider2D>();
            Gizmos.DrawCube(pickableCollider.bounds.center, pickableCollider.bounds.size);
        }
#endif

    }
}
