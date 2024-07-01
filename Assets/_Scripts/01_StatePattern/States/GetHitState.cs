using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Sates
{
    public class GetHitState : State
    {
        public override void EnterState()
        {
            agent.animationManager.PlayAnimation(AnimationType.hit);
            agent.animationManager.OnAnimationEnd.AddListener(TransitionToIdleState);
        }

        public override void HandleAttack()
        {
            //Don't allow attack 
        }

        public override void HandleJumpPressed()
        {
            //Don't allow jumping
        }

        public override void StateUpdate()
        {
            //prevent fall state
        }

        public override void GetHit()
        {
            //prevent
        }

        public void TransitionToIdleState()
        {
            agent.TransitionToState(agent.stateFactory.GetAppropriateState(StateType.Idle), this);
        }

        public override void ExitState()
        {
            agent.animationManager.OnAnimationEnd.RemoveListener(TransitionToIdleState);
        }
    }
}

