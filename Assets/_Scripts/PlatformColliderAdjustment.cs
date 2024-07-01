using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlatformColliderAdjustment : MonoBehaviour
    {
        [SerializeField]
        private BoxCollider2D platformCollider;
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            float y = spriteRenderer.bounds.center.y + spriteRenderer.bounds.size.y / 2f;
            platformCollider.size
                = new Vector2(spriteRenderer.size.x, platformCollider.size.y);
            platformCollider.offset = new Vector2(0, spriteRenderer.bounds.size.y / 2f - platformCollider.size.y / 2f);
            
        }

        private void OnDrawGizmos()
        {
            //Gizmos.color = Color.red;
            //Gizmos.DrawCube(spriteRenderer.bounds.center, spriteRenderer.bounds.size);
            //Gizmos.color = Color.blue;
            //Gizmos.DrawSphere(spriteRenderer.bounds.center, 1);
        }
    }
}
