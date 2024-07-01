using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.AI
{
    public class AIBehaviourBossPattern : AIBehaviour
    {
        public AIPlayerEnterAreaDetector playerDetector;
        public AIEndPlatformDetector detector;
        public AIMeleeAttackDetector meleeAttackDetector;
        public Agent agent;

        public float waitTime = 1;
        private float currentTime = 0;
        private bool isWaiting = false;
        public string status = "Nothing";

        private bool arrived = true;
        public float arriveDistance = 0.3f;
        private Vector2 direction;
        private Vector3 tempPosition;

        private void Start()
        {
            detector.OnPathBlocked += () =>
            {
                arrived = true;
                isWaiting = true;
            };
        }

        public override void PerformAction(AIEnemy enemyAI)
        {
            if (playerDetector.PlayerInArea)
            {
                if (isWaiting == false)
                {
                    SetChargeDestination();
                    ChargeAtThePlayer(enemyAI);
                }
                else
                {
                    status = "Waiting COOLDOWN";
                    if (currentTime >= waitTime)
                    {
                        currentTime = 0;
                        isWaiting = false;
                        Debug.Log("Stopped waiting");
                        return;
                    }
                    currentTime += Time.deltaTime;
                    enemyAI.CallOnMovement(Vector2.zero);
                    enemyAI.MovementVector = Vector2.zero;
                }
            }
            else
            {
                status = "Waiting for the player";
                enemyAI.CallOnMovement(Vector2.zero);
                enemyAI.MovementVector = Vector2.zero;
            }
        }

        private void ChargeAtThePlayer(AIEnemy enemyAI)
        {
            enemyAI.CallOnMovement(direction.normalized);
            enemyAI.MovementVector = direction.normalized;
            //CheckIfArrived();
            CheckAttack(enemyAI);
        }

        private void CheckAttack(AIEnemy enemyAI)
        {
            if (meleeAttackDetector.PlayerDetected)
            {
                enemyAI.CallAttack();
                arrived = true;
                isWaiting = true;
            }
        }

        private void CheckIfArrived()
        {
            if (Vector2.Distance(agent.transform.position, tempPosition) < arriveDistance)
            {
                arrived = true;
                isWaiting = true;
            }
        }

        private void SetChargeDestination()
        {
            if (arrived)
            {
                tempPosition = new Vector2(playerDetector.Player.position.x, agent.transform.position.y);
                direction = tempPosition - agent.transform.position;
                arrived = false;
            }
        }
    }
}
