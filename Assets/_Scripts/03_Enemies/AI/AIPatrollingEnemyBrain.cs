using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Platformer.AI
{
    public class AIPatrollingEnemyBrain : AIEnemy
    {
        public Agent agent;
        public bool canMove = false;

        public AIBehaviour AttackBehaviour, PatrolBehaviour;

        private void Awake()
        {
            if (agent == null)
                agent = GetComponentInChildren<Agent>();


        }

        private void Update()
        {
            if (agent.IsGrounded)
            {
                AttackBehaviour.PerformAction(this);
                PatrolBehaviour.PerformAction(this);
            } 
        }

    }
}
