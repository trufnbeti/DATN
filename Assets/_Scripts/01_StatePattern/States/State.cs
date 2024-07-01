using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer.Sates
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField]
        protected Agent agent;

        [field: SerializeField]
        public UnityEvent OnEnter { get; set; }
        [field: SerializeField]
        public UnityEvent OnExit { get; set; }
        

        public void InitializeState(Agent player)
        {
            this.agent = player;
            
        }

        public void Enter()
        {
            agent.agentInput.OnAttack += HandleAttack;
            agent.agentInput.OnJumpPressed += HandleJumpPressed;
            agent.agentInput.OnJumpReleased += HandleJumpReleased;
            agent.agentInput.OnMovement += HandleMovement;
            OnEnter?.Invoke();
            EnterState();
        }

        public virtual void HandleMovement(Vector2 movementVector)
        {
            agent.agentRenderer.FaceDirection(movementVector);
        }

        public virtual void HandleJumpReleased()
        {
        }

        public virtual void HandleJumpPressed()
        {
            TestJumpTransition();
        }

        public virtual void HandleAttack()
        {
            TestAttackTransition();
        }

        public virtual void EnterState()
        {
        }

        public virtual void StateUpdate()
        {
            if(agent.IsGrounded == false)
            {
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Fall), this);
                return;
            }
        }

        public virtual void StateFixedUpdate()
        {

        }

        public virtual void ExitState()
        {

            
        }

        public virtual void GetHit()
        {
            agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.GetHit), this);
        }

        public virtual void Die()
        {
            agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Die), this);
        }


        public void Exit()
        {
            agent.agentInput.OnAttack -= HandleAttack;
            agent.agentInput.OnJumpPressed -= HandleJumpPressed;
            agent.agentInput.OnJumpReleased -= HandleJumpReleased;
            agent.agentInput.OnMovement -= HandleMovement;

            agent.animationManager.ResetEvents();
            OnExit?.Invoke();
            ExitState();
        }

        protected virtual void TestJumpTransition()
        {
            if (agent.IsGrounded)
            {
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Jump), this);
            }
        }

        protected virtual void TestAttackTransition()
        {
            if (agent.agentWeapon.CanIUseWeapon(agent.IsGrounded))
            {
                //agent.agentWeapon.GetCurrentWeapon().PerformAttack(agent, 1, Vector3.right);
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Attack), this);
            }
        }
    }
}

