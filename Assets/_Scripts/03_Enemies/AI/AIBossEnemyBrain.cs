using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.AI
{
    public class AIBossEnemyBrain : AIEnemy
    {
        //public AIBehaviour BossPattern_1;
        public AIPlayerEnterAreaDetector playerDetector;
        public AIMeleeAttackDetector meleeRangeDetector;
        public AIEndPlatformDetector endPlatformDetector;

        public AIBehaviour IdleBehaviour, ChargeBehaviour, MeleeAttackBehaviour, WaitBehaviour;
        public AIDataBoard aiBoard;

        private void Update()
        {
            aiBoard.SetBoard(AIDataTypes.PlayerDetected, playerDetector.PlayerInArea);
            aiBoard.SetBoard(AIDataTypes.InMeleeRange, meleeRangeDetector.PlayerDetected);
            aiBoard.SetBoard(AIDataTypes.PathBlocked, endPlatformDetector.PathBlocked);

            if (aiBoard.CheckBoard(AIDataTypes.PlayerDetected))
            {
                if (aiBoard.CheckBoard(AIDataTypes.Waiting))
                {
                    WaitBehaviour.PerformAction(this);
                }
                else
                {
                    if (aiBoard.CheckBoard(AIDataTypes.InMeleeRange))
                    {
                        MeleeAttackBehaviour.PerformAction(this);
                    }
                    else
                    {
                        ChargeBehaviour.PerformAction(this);
                    }
                }
            }
            else
            {
                IdleBehaviour.PerformAction(this);
            }

        }
    }
}
