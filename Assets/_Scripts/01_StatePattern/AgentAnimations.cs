using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class AgentAnimations : MonoBehaviour
    {
        public UnityEvent OnAnimationAction { get; set; } = new UnityEvent();
        public UnityEvent OnAnimationEnd { get; set; } = new UnityEvent();

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            
        }

        public void PlayAnimation(AnimationType animationType)
        {
            switch (animationType)
            {
                case AnimationType.die:
                    Play("Die");
                    break;
                case AnimationType.hit:
                    Play("Get_hit");
                    break;
                case AnimationType.idle:
                    Play("Idle");
                    break;
                case AnimationType.attack:
                    Play("Attack");
                    break;
                case AnimationType.run:
                    Play("Run");
                    break;
                case AnimationType.jump:
                    Play("Jump");
                    break;
                case AnimationType.fall:
                    Play("fall");
                    break;
                case AnimationType.climb:
                    Play("Climb");
                    break;
                case AnimationType.land:
                    Play("land");
                    break;
                default:
                    throw new Exception("Enum not supported " + animationType);
            }
        }

        public void ResetEvents()
        {
            OnAnimationAction.RemoveAllListeners();
            OnAnimationEnd.RemoveAllListeners();
        }

        public void InvokeAnimationAction()
        {
            OnAnimationAction?.Invoke();
        }

        public void InvokeAnimationEnd()
        {
            OnAnimationEnd?.Invoke();
        }

        public void StopAnimation()
        {
            animator.enabled = false;
        }

        public void StartAnimation()
        {
            animator.enabled = true;
        }

        private void Play(string name)
        {
            animator.Play(name,-1,0f);
        }


    }
}

public enum AnimationType
{
    die, 
    hit, 
    idle,
    attack, 
    run, 
    jump, 
    fall, 
    climb, 
    land
}
