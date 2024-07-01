using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class MovementData : MonoBehaviour
    {
        public float currentSpeed = 0;
        public Vector2 currentVelocity = Vector2.zero;
        public int horizontalMovementDirection = 0;
    }
}
