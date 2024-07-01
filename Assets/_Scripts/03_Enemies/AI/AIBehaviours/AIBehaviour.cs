using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Platformer.AI
{

    public abstract class AIBehaviour : MonoBehaviour
    {
        public abstract void PerformAction(AIEnemy enemyAI);
    }
}
