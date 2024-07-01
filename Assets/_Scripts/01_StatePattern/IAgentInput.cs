using System;
using UnityEngine;

namespace Platformer
{
    public interface IAgentInput
    {
        Vector2 MovementVector { get; }

        event Action OnAttack;
        event Action OnJumpPressed;
        event Action OnJumpReleased;
        event Action<Vector2> OnMovement;
        event Action OnWeaponChange;
    }
}