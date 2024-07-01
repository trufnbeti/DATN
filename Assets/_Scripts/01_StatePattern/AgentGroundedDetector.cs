using Platformer.AI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class AgentGroundedDetector : MonoBehaviour, IAIDetector
    {
        [SerializeField]
        private bool flying = false;

        public Collider2D agentCollider;
        public LayerMask groundMask;

        public bool isGrounded = false;

        [Header("Gizmo parameters:")]
        [Range(-2f, 2f)]
        public float cubeCastYOffset = -0.1f;
        [Range(-2f, 2f)]
        public float cubeCastXOffset = -0.1f;
        [Range(0, 2)]
        public float cubeCastWidth = 1, cubeCastHeight = 1;
        public Color gizmoColor = Color.red;
        //public UnityEvent<bool> IsGroundedEvent { get; set; }

        public Vector3 groundNormal;
        public float angleBetweenNormal = 0;

        private void Awake()
        {
            if(agentCollider==null)
                agentCollider = GetComponent<Collider2D>();
        }

        
        public void CheckIsGrounded()
        {
            if (flying)
            {
                isGrounded = true;
                groundNormal = Vector3.up;
                return;
            }
                
            RaycastHit2D raycastHit = Physics2D.BoxCast(agentCollider.bounds.center + new Vector3(cubeCastXOffset, cubeCastYOffset, 0), new Vector2(cubeCastWidth, cubeCastHeight), 0, Vector2.down,0, groundMask);

            //isGrounded = raycastGit.collider != null;
            if (raycastHit.collider != null) // && raycastGit.collider.CompareTag(platformsTag)
            {
                if (raycastHit.collider.IsTouching(agentCollider) == true)
                {
                    isGrounded = true;
                    RaycastHit2D hit = Physics2D.Raycast(agentCollider.bounds.center, Vector2.down, 5, groundMask);
                    if (hit.collider != null)
                    {
                        groundNormal = hit.normal;
                        angleBetweenNormal = Vector2.SignedAngle(Vector2.up, groundNormal);
                    }
                }
            }
            else
            {
                isGrounded = raycastHit.collider != null;
                angleBetweenNormal = 0;
            }
            //IsGroundedEvent?.Invoke(isGrounded);
        }

        private void OnDrawGizmos()
        {
            if (agentCollider == null)
                return;
            Gizmos.color = gizmoColor;
            if (isGrounded == true)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(agentCollider.bounds.center + new Vector3(cubeCastXOffset, cubeCastYOffset, 0), groundNormal);
            }
            //Gizmos.DrawWireSphere(circleCollider.bounds.center + new Vector3(0, circleCastYOffset, 0), circleCastRadius);
            Gizmos.DrawWireCube(agentCollider.bounds.center + new Vector3(cubeCastXOffset, cubeCastYOffset, 0), new Vector3(cubeCastWidth, cubeCastHeight));
        }

        //private Vector3 GetPosition()
        //{
        //    return agent.position + Vector3.Scale(transform.position, agent.localScale);
        //}

        public void ToggleFlying(bool val)
        {
            flying = val;
        }

        public bool GetDetectorValue()
        {
            return isGrounded;
        }
    }
}
