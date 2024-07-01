using System;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public interface IPlayerInputPlatformer
    {
        Vector2 MovementVector { get; }

        event Action OnAttack;
        event Action OnJumpPressed;
        event Action OnJumpReleased;
        event Action OnMenu;
    }
}