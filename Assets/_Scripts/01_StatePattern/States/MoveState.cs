using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer.Sates
{
    public class MoveState : State
    {
        [SerializeField]
        protected MovementData movementData;

        public UnityEvent OnStep;

        private void Awake()
        {
            movementData = GetComponentInParent<MovementData>();
        }

        public override void EnterState()
        {
            agent.animationManager.PlayAnimation(AnimationType.run);
            agent.animationManager.OnAnimationAction.AddListener(StepFeadback);
            movementData.horizontalMovementDirection = 0;
            movementData.currentSpeed = 0;
            movementData.currentVelocity = Vector2.zero;
        }

        protected void CalculateSpeed(Vector2 movementInput, MovementData movementData)
        {
            if (Mathf.Abs(movementInput.x) > 0)
            {
                movementData.currentSpeed += agent.agentData.acceleration * Time.deltaTime;
            }
            else
            {
                movementData.currentSpeed -= agent.agentData.deacceleration * Time.deltaTime;
            }
            movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, agent.agentData.maxSpeed);
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
            CalculateVelocity();
            SetPlayersVelocity();
            if (agent.IsGrounded)
            {
                if (Mathf.Abs(agent.rb2d.velocity.x) < 0.01f)
                {
                    agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Idle), this);
                }
                //else if (Mathf.Abs(agent.groundSensor.angleBetweenNormal) > 5 && Mathf.Abs(agent.agentInput.MovementVector.x) < 0.01f)
                //{
                //    agent.TransitionToState(TransitionIdle, this);
                //}
            }
            
        }

        protected void CalculateVelocity()
        {
            CalculateSpeed(agent.agentInput.MovementVector, movementData);
            CalculateHorizontalDirection(movementData);
            movementData.currentVelocity = Vector3.right * movementData.horizontalMovementDirection * movementData.currentSpeed;
            movementData.currentVelocity.y = agent.rb2d.velocity.y;

            if (Mathf.Abs(agent.groundSensor.angleBetweenNormal) > 5)
            {
                Quaternion q = Quaternion.Euler(0, 0, agent.groundSensor.angleBetweenNormal);
                Vector3 newVelocity;
                if (agent.groundSensor.angleBetweenNormal > 5 && movementData.horizontalMovementDirection < 0 
                    || agent.groundSensor.angleBetweenNormal < 5 && movementData.horizontalMovementDirection > 0)
                {
                    newVelocity = q * movementData.currentVelocity;
                    Debug.DrawRay(transform.position, newVelocity.normalized * 2, Color.magenta);
                    movementData.currentVelocity = newVelocity;
                }
                
            }
        }

        protected void CalculateHorizontalDirection(MovementData movementData)
        {
            if (agent.agentInput.MovementVector.x > 0)
            {
                movementData.horizontalMovementDirection = 1;
            }
            else if (agent.agentInput.MovementVector.x < 0)
            {
                movementData.horizontalMovementDirection = -1;
            }
        }

        protected void SetPlayersVelocity()
        {
            agent.rb2d.velocity = movementData.currentVelocity;

        }

        public void SetSpeed(float val)
        {
            movementData.currentSpeed = val;
        }

        public override void ExitState()
        {
            agent.animationManager.OnAnimationAction.RemoveListener(StepFeadback);
        }

        protected void StepFeadback()
        {
            OnStep?.Invoke();
        }

    }
}

