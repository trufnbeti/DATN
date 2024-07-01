using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.AI
{
    public class AIBehaviourPatrolPath : AIBehaviour
    {
        public PatrolPath patrolPath;
        [Range(0.1f, 1)]
        public float arriveDistance = 1;
        public float waitTime = 0.5f;
        [SerializeField]
        private bool isWaiting = false;
        [SerializeField]
        Vector2 currentPatrolTarget = Vector2.zero;
        bool isInitialized = false;

        [SerializeField]
        private Transform agent;

        private int currentIndex = -1;

        private void Awake()
        {
            if (patrolPath == null)
                patrolPath = GetComponentInParent<PatrolPath>();
        }
        public override void PerformAction(AIEnemy enemyAI)
        {
            if (!isWaiting)
            {
                if (patrolPath.Length < 2)
                    return;
                if (!isInitialized)
                {
                    var currentPathPoint = patrolPath.GetClosestPathPoint(agent.position);
                    this.currentIndex = currentPathPoint.Index;
                    this.currentPatrolTarget = currentPathPoint.Position;
                    isInitialized = true;
                }
                if (Vector2.Distance(agent.position, currentPatrolTarget) < arriveDistance)
                {
                    isWaiting = true;
                    enemyAI.MovementVector = Vector2.zero;
                    StartCoroutine(WaitCoroutine());
                    return;
                }
                Vector2 directionToGo = currentPatrolTarget - (Vector2)agent.position;

                enemyAI.CallOnMovement(directionToGo.normalized);
                enemyAI.MovementVector = directionToGo.normalized;


            }
        }

        IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(waitTime);
            var nextPathPoint = patrolPath.GetNextPathPoint(currentIndex);
            currentPatrolTarget = nextPathPoint.Position;
            currentIndex = nextPathPoint.Index;
            isWaiting = false;
        }
    }
}
