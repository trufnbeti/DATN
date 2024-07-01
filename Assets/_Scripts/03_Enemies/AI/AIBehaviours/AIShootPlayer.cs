using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.AI
{
    public class AIShootPlayer : AIBehaviour
    {
        public AIPlayerDetector playerDetector;

        [SerializeField]
        private bool isWaiting;
        [SerializeField]
        private float delay = 1;
        public override void PerformAction(AIEnemy enemyAI)
        {
            if (isWaiting == true)
                return;
            if (playerDetector.PlayerDetected)
            {
                isWaiting = true;
                enemyAI.CallOnMovement(playerDetector.DirectionToTarget.normalized);
                enemyAI.CallAttack();
                StartCoroutine(AttackDelayCoroutine());
            }
        }

        IEnumerator AttackDelayCoroutine()
        {
            yield return new WaitForSeconds(delay);
            isWaiting = false;

        }
    }
}
