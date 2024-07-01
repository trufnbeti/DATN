using Platformer.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class AIPlayerEnterAreaDetector : MonoBehaviour, IAIDetector
    {
        [field: SerializeField]
        public bool PlayerInArea { get; private set; }
        public Transform Player { get; private set; }

        public bool GetDetectorValue()
        {
            return PlayerInArea;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                PlayerInArea = true;
                Player = collision.gameObject.transform;
            }
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                PlayerInArea = true;
                Player = collision.gameObject.transform;
            }
        }
    }
}
