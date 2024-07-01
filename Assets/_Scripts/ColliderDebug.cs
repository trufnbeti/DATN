using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class ColliderDebug : MonoBehaviour
    {
        public BoxCollider2D colliderbox;
        public Color gizmoColor = Color.green;
        private void OnDrawGizmos()
        {
            if (colliderbox == null)
                return;
            Gizmos.color = gizmoColor;
            Gizmos.DrawCube(colliderbox.bounds.center, colliderbox.bounds.size);
        }
    }
}
