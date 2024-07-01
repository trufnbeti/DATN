using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.AI
{
    public class AIBehaviourMeleeAttack : AIBehaviour
    {
        public AIMeleeAttackDetector meleeAttackDetector;

        [SerializeField]
        private bool isWaiting;

        [SerializeField]
        private float delay = 1;

        private void Awake()
        {
            if (meleeAttackDetector == null)
                meleeAttackDetector = GetComponentInChildren<AIMeleeAttackDetector>();
        }

        public override void PerformAction(AIEnemy enemyAI)
        {
            
            if (isWaiting)
            {
                return;
            }
            if (meleeAttackDetector.PlayerDetected == false)
                return;
            enemyAI.CallAttack();
            isWaiting = true;
            StartCoroutine(AttackDelayCoroutine());
        }

        IEnumerator AttackDelayCoroutine()
        {
            yield return new WaitForSeconds(delay);
            isWaiting = false;

        }
    }
}
