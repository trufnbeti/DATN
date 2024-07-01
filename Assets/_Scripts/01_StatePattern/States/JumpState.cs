using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Sates
{
    public class JumpState : MoveState
    {
        private bool jumpPressed = false;
        public override void EnterState()
        {
            agent.animationManager.PlayAnimation(AnimationType.jump);
            Vector2 velocity = agent.rb2d.velocity;
            velocity.y = agent.agentData.jumpSpeed;
            agent.rb2d.velocity = velocity;
            jumpPressed = true;
        }

        public override void HandleJumpPressed()
        {
            jumpPressed = true;
        }

        public override void HandleJumpReleased()
        {
            jumpPressed = false;
        }

        public override void StateUpdate()
        {
            //If we are not holding the jump fall faster
            ControlJumpHeight();
            //if(player.playerInput.MovementVector.magnitude > 0)
                CalculateVelocity();
            SetPlayersVelocity();
            if (agent.rb2d.velocity.y <= 0)
            {
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Fall), this);
            }else if (agent.CanClimb && Mathf.Abs(agent.agentInput.MovementVector.y) > 0)
            {
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Climbing), this);
            }
        }

        private void ControlJumpHeight()
        {
            if (jumpPressed == false)
            {
                movementData.currentVelocity = agent.rb2d.velocity;
                movementData.currentVelocity.y += agent.agentData.lowJumpMultiplier* Physics2D.gravity.y * Time.deltaTime;
                agent.rb2d.velocity = movementData.currentVelocity;
            }
        }

    }
}
