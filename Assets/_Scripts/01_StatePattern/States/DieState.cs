using Platformer.Sates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class DieState : State
    {
        public float timeToWaitBerofreRespawn = 2;
        public override void EnterState()
        {
            agent.animationManager.PlayAnimation(AnimationType.die);
            agent.animationManager.OnAnimationEnd.AddListener(WaitBeforeRestart);
            agent.rb2d.velocity = new Vector2(0,Physics2D.gravity.y);
            //agent.enabled = false;
            //agent.rb2d.isKinematic = true;
        }

        public override void HandleAttack()
        {
            //Don't allow attack 
        }

        public override void HandleJumpPressed()
        {
            //Don't allow jumping
        }

        public override void GetHit()
        {
            //Don't allow being hit
        }

        public override void Die()
        {
            //Don't allow die
        }

        public override void StateUpdate()
        {
            //prevent fall state
            agent.rb2d.velocity = new Vector2(0, agent.rb2d.velocity.y);
            //agent.rb2d.velocity += new Vector2(0, Physics2D.gravity.y * 3 * Time.deltaTime);
        }

        //public override void StateFixedUpdate()
        //{
        //    if(agent.IsGrounded == false)
        //        agent.rb2d.MovePosition((Vector2)agent.transform.position + new Vector2(0, agent.rb2d.gravityScale * Physics2D.gravity.y*Time.fixedDeltaTime));
        //}


        public override void HandleMovement(Vector2 movementVector)
        {
            //prevent rotating player
        }

        private void WaitBeforeRestart()
        {
            StartCoroutine(WaitCoroutine());
        }

        IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(timeToWaitBerofreRespawn);
            //agent.enabled = true;
            
            //transform.root.gameObject.SetActive(true);
            agent.OnAgentDied?.Invoke();
            
        }

        public override void ExitState()
        {
            base.ExitState();
            //agent.rb2d.isKinematic = false;
        }
    }
}
