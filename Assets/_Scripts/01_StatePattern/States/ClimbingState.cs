using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Sates
{
    public class ClimbingState : State
    {
        private float previousGravityScale = 0;

        public override void EnterState()
        {
            agent.animationManager.PlayAnimation(AnimationType.climb);
            agent.animationManager.StopAnimation();
            agent.rb2d.velocity = Vector2.zero;
            previousGravityScale = agent.rb2d.gravityScale;
            agent.rb2d.gravityScale = 0;

        }

        public override void HandleJumpPressed()
        {
            agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Jump), this);
        }

        public override void HandleAttack()
        {
            //Don't allow attack 
        }

        public override void StateUpdate()
        {
            if (agent.agentInput.MovementVector.magnitude > 0)
            {
                agent.animationManager.StartAnimation();
                var velocity = new Vector2(agent.agentInput.MovementVector.x * agent.agentData.climbHorizontalSpeed, agent.agentInput.MovementVector.y * agent.agentData.climbVerticalSpeed);
                agent.rb2d.velocity = velocity;
            }
            else
            {
                agent.animationManager.StopAnimation();
                agent.rb2d.velocity = Vector2.zero;
            }

            if (agent.CanClimb == false)
            {
                Debug.Log("I cant climb");
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Idle), this);
            }

        }

        public override void ExitState()
        {
            //agent.rb2d.velocity = new Vector2(agent.rb2d.velocity.x, 0);
            agent.rb2d.velocity = Vector2.zero;
            agent.rb2d.gravityScale = previousGravityScale;
            agent.animationManager.StartAnimation();
        }
    }
}
