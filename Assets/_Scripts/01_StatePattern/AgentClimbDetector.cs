using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class AgentClimbDetector : MonoBehaviour
    {

        public string climbingStuffLayerName = "ClimbingStuff";
        public LayerMask climbingLayerMask;

        [SerializeField]
        private bool canClimb;
        
        public bool CanClimb
        {
            get { return canClimb; }
            private set { canClimb = value; }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            LayerMask collisionLayerMask = 1 << collision.gameObject.layer;
            //Debug.Log(collisionLayerMask & climbingLayerMask);
            if ((collisionLayerMask & climbingLayerMask) != 0)
            {
                canClimb = true;
            }
            //if (collision.gameObject.layer == LayerMask.NameToLayer(climbingStuffLayerName))
            //{
            //    canClimb = true;
            //}
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            LayerMask collisionLayerMask = 1 << collision.gameObject.layer;
            //Debug.Log(collisionLayerMask & climbingLayerMask);
            if ((collisionLayerMask & climbingLayerMask) != 0)
            {
                canClimb = false;
            }
            //if (collision.gameObject.layer == LayerMask.NameToLayer(climbingStuffLayerName))
            //{
            //    canClimb = false;
            //}
        }
    }
}
