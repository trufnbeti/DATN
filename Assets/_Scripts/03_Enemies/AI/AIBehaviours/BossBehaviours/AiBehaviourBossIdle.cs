using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.AI
{
    public class AiBehaviourBossIdle : AIBehaviour
    {
        public override void PerformAction(AIEnemy enemyAI)
        {
            
            enemyAI.CallOnMovement(Vector2.zero);
            enemyAI.MovementVector = Vector2.zero;
        }
    }
}
