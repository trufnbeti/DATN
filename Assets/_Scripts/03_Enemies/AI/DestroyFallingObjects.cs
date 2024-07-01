using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class DestroyFallingObjects : MonoBehaviour
    {
        public LayerMask objectsToDestoryLayerMask;
        public Vector2 size;

        [Header("Gizmo parameters")]
        public Color gizmoColor = Color.red;
        public bool showGizmo = true;
        
        private void FixedUpdate()
        {
            var collider = Physics2D.OverlapBox(transform.position, size, 0, objectsToDestoryLayerMask);
            if (collider != null)
            {
                var agent = collider.GetComponent<Agent>();
                if (agent == null)
                {
                    Destroy(collider.gameObject);
                    return;
                }
                var damagable = agent.GetComponent<Damagable>();
                if (damagable != null)
                    damagable.GetHit(1);
                agent.AgentDied();
            }

        }

        private void OnDrawGizmos()
        {
            if (showGizmo)
            {
                Gizmos.color = gizmoColor;
                Gizmos.DrawCube(transform.position, size);
            }
        }
    }
}
