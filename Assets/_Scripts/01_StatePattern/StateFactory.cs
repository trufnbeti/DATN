using Platformer.Sates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Platformer
{
    public class StateFactory : MonoBehaviour
    {
        [SerializeField]
        private State Idle, Move, Fall, Climbing, GetHit, Jump, Attack, Die;

        public State GetAppropriateState(StateType stateType)
            => stateType switch
            {
                StateType.Idle => Idle,
                StateType.Move => Move,
                StateType.Fall => Fall,
                StateType.Climbing => Climbing,
                StateType.GetHit => GetHit,
                StateType.Jump => Jump,
                StateType.Attack => Attack,
                StateType.Die => Die,
                _ => throw new Exception("State not defined for " + stateType.ToString() + " state type enum.")
            };
        

    }

    public enum StateType
    {
        Idle,
        Move,
        Fall,
        Climbing,
        GetHit,
        Jump,
        Attack,
        Die
    }

}
