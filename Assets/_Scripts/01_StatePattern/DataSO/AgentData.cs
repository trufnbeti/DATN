using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName ="PlayerData",menuName ="Player/PlayerData")]
    public class AgentData : ScriptableObject
    {
        [Header("Basic data")]
        public int health = 2;
        [Header("Movement data")]
        [Space]
        public float maxSpeed = 5;
        public float acceleration = 50;
        public float deacceleration = 50;
        [Header("Jump data")]
        [Space]
        public float jumpSpeed = 10;
        public float gravityModifier = 3.5f; 
        public float lowJumpMultiplier = 5f;
        [Header("Climb data")]
        [Space]
        public float climbVerticalSpeed = 5;
        public float climbHorizontalSpeed = 2;
    }
}

