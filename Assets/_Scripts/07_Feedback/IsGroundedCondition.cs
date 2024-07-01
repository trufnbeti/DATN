using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class IsGroundedCondition : MonoBehaviour
    {
        [SerializeField]
        private AgentGroundedDetector groundDetector;

        public UnityEvent OnConditionValidAction;

        public void TryPerformingAction()
        {
            if (groundDetector.isGrounded)
            {
                OnConditionValidAction?.Invoke();
            }
        }
    }
}
