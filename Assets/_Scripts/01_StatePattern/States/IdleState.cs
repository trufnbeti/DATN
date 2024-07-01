using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Sates
{
    public class IdleState : State
    {
        public override void EnterState()
        {
            agent.animationManager.PlayAnimation(AnimationType.idle);
            agent.rb2d.isKinematic = true;
            if (agent.IsGrounded)
                agent.rb2d.velocity = Vector2.zero;
            
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            
            if ((agent.agentInput.MovementVector.x > 0 || agent.agentInput.MovementVector.x < 0))
            {
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Move), this);
            }
            else if (agent.CanClimb && Mathf.Abs(agent.agentInput.MovementVector.y) > 0)
            {
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Climbing), this);
            }

        }

        public override void ExitState()
        {
            agent.rb2d.isKinematic = false;
        }

    }
}
