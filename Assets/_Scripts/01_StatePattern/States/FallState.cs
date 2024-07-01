using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Sates
{
    public class FallState : MoveState
    {
        public override void EnterState()
        {
            agent.animationManager.PlayAnimation(AnimationType.fall);
        }

        public override void HandleJumpPressed()
        {
            //Dont allow jumping when falling
        }

        public override void StateUpdate()
        {
            movementData.currentVelocity = agent.rb2d.velocity;
            movementData.currentVelocity.y += agent.agentData.gravityModifier * Physics2D.gravity.y * Time.deltaTime;
            agent.rb2d.velocity = movementData.currentVelocity;
            //if (player.playerInput.MovementVector.magnitude > 0)
                CalculateVelocity();
            SetPlayersVelocity();
            if (agent.IsGrounded)
            {
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Idle), this);
            }
            else
            {
                if(agent.agentInput.MovementVector.y > 0 || agent.agentInput.MovementVector.y < 0)
                {
                    TestClimbingTransition();
                }
            }
        }

        private void TestClimbingTransition()
        {
            if (agent.CanClimb) //&& Mathf.Abs(player.playerInput.MovementVector.y) > 0
            {
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Climbing), this);
            }
        }
    }
}
