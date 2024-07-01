using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Sates
{
    public class FlyState : MoveState
    {
        protected Vector2 movementDirection;
        protected new void CalculateSpeed(Vector2 movementInput, MovementData movementData)
        {
            this.movementDirection = movementInput;
            if (movementInput.magnitude > 0)
            {
                movementData.currentSpeed += agent.agentData.acceleration * Time.deltaTime;
            }
            else
            {
                movementData.currentSpeed -= agent.agentData.deacceleration * Time.deltaTime;
            }
            movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, agent.agentData.maxSpeed);
        }

        protected new void CalculateVelocity()
        {
            CalculateSpeed(agent.agentInput.MovementVector, movementData);
            CalculateHorizontalDirection(movementData);
            movementData.currentVelocity = this.movementDirection * movementData.currentSpeed;

        }

        public override void StateUpdate()
        {
            CalculateVelocity();
            SetPlayersVelocity();
            //if (agent.rb2d.velocity.magnitude < 0.01f)
            //{
            //    agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Idle), this);
            //}
        }
    }
}
