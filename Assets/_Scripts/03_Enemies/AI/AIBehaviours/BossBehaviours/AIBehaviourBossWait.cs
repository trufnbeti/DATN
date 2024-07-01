using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.AI
{
    public class AIBehaviourBossWait : AIBehaviour
    {
        [SerializeField]
        private AIDataBoard aiBoard;
        [SerializeField]
        private float waitTime = 1;
        private float currentTime = 0;

        public override void PerformAction(AIEnemy enemyAI)
        {
            enemyAI.MovementVector = Vector2.zero;
            StartCoroutine(WaitCoroutine());
        }

        IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(waitTime);
            aiBoard.SetBoard(AIDataTypes.Waiting, false);
        }
    }
}
