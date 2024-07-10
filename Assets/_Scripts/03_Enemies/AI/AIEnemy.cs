using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.AI
{
    public class AIEnemy : MonoBehaviour, IAgentInput
    {
        public Vector2 MovementVector {get; set;}

        public event Action OnAttack;
        public event Action OnJumpPressed;
        public event Action OnJumpReleased;
        public event Action<Vector2> OnMovement;
        public event Action OnWeaponChange;

        public void CallOnMovement(Vector2 input)
        {
            OnMovement?.Invoke(input);
        }

        public void CallAttack()
        {
            OnAttack?.Invoke();
        }
    }
}
