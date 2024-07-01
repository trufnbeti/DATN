using Platformer.AI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class AIEndPlatformDetector : MonoBehaviour, IAIDetector
    {
        public BoxCollider2D detectorCOllider;

        public LayerMask groundMask;
        public float groundRaycastLength = 2;

        [Range(0,1)]
        public float groundRaycastDelay = 0.1f;

        public bool PathBlocked { get; private set; }

        public event Action OnPathBlocked;

        [Header("Gizmo Parameters")]
        public Color colliderColor = Color.magenta;
        public Color groundRaycastColor = Color.blue;
        public bool ShowGizmos = true;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnPathBlocked?.Invoke();
        }

        private void Start()
        {
            StartCoroutine(CheckGroundCoroutine());
        }

        IEnumerator CheckGroundCoroutine()
        {
            yield return new WaitForSeconds(groundRaycastDelay);
            var hit = Physics2D.Raycast(detectorCOllider.bounds.center, Vector2.down, groundRaycastLength,groundMask);
            if (hit.collider == null)
            {
                OnPathBlocked?.Invoke();

            }
            PathBlocked = hit.collider == null;        
            StartCoroutine(CheckGroundCoroutine());
        }

        private void OnDrawGizmos()
        {
            if (ShowGizmos && detectorCOllider!= null)
            {
                Gizmos.color = groundRaycastColor;
                Gizmos.DrawRay(detectorCOllider.bounds.center, Vector2.down * groundRaycastLength);
                Gizmos.color = colliderColor;
                Gizmos.DrawCube(detectorCOllider.bounds.center, detectorCOllider.bounds.size);
            }   
        }

        public bool GetDetectorValue()
        {
            return PathBlocked;
        }
    }
}
