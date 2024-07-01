using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer.Sates
{
    public class AttackState : State
    {
        public LayerMask hittableLayerMask;

        protected Vector2 direction;

        public UnityEvent<AudioClip> OnWeaponSound;
        private bool showGizmos = false;

        public override void EnterState()
        {
            agent.animationManager.ResetEvents();
            agent.animationManager.PlayAnimation(AnimationType.attack);
            agent.animationManager.OnAnimationEnd.AddListener(TransitionToIdleState);
            agent.animationManager.OnAnimationAction.AddListener(PerformAttack);

            agent.agentWeapon.ToggleWeaponVisibility(true);
            direction = agent.transform.right * (agent.transform.localScale.x > 0 ? 1 : -1);
            if (agent.IsGrounded)
                agent.rb2d.velocity = Vector2.zero;

            showGizmos = true;
        }

        private void TransitionToIdleState()
        {
            agent.animationManager.OnAnimationEnd.RemoveListener(TransitionToIdleState);
            if(agent.IsGrounded)
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Idle), this);
            else
                agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Fall), this);

        }

        private void PerformAttack()
        {
            OnWeaponSound?.Invoke(agent.agentWeapon.GetCurrentWeapon().weaponSwingSound);
            agent.animationManager.OnAnimationAction.RemoveListener(PerformAttack);
            agent.agentWeapon.GetCurrentWeapon().PerformAttack(agent, hittableLayerMask, direction);
            //attacked = true;

        }

        public override void ExitState()
        {
            agent.agentWeapon.ToggleWeaponVisibility(false);
            showGizmos = false;
        }

        private void OnDrawGizmos()
        {

            if (Application.isPlaying == false)
                return;
            if (showGizmos == false)
                return;
            Gizmos.color = Color.red;
            var pos = agent.agentWeapon.transform.position;
            var direction = new Vector3(1, 0, 0) * (agent.transform.localScale.x > 0 ? 1 : -1);
            agent.agentWeapon.GetCurrentWeapon().DrawWeaponGizmo(pos, direction);

        }

        public override void HandleAttack()
        {
            //Dont attack again
        }

        public override void HandleJumpPressed()
        {
            //DOnt allow jumping
        }

        public override void HandleJumpReleased()
        {

        }

        public override void HandleMovement(Vector2 movementVector)
        {
            //stop rotation
        }

        public override void StateUpdate()
        {
            //block falling transition
        }

        public override void StateFixedUpdate()
        {
            //block state fixed update
        }

        

        

    }
}
