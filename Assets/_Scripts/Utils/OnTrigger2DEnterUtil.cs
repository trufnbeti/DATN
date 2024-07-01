using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class OnTrigger2DEnterUtil : MonoBehaviour
    {
        public LayerMask collisionMask;
        public UnityEvent OnTriggerEnter, OnTriggerExit;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if( (1 << collision.gameObject.layer & collisionMask) != 0)
            {
                OnTriggerEnter?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if ((1 << collision.gameObject.layer & collisionMask) != 0)
            {
                OnTriggerExit?.Invoke();
            }
        }
    }
}
