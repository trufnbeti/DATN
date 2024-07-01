using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class PointsPickable : Pickable
    {
        public UnityEvent OnPickUp;
        [SerializeField]
        private int pointsToAdd = 1;

        public override void PickUp(Agent player)
        {
            PlayerPoints playerPoints = player.GetComponent<PlayerPoints>();
            playerPoints.Add(pointsToAdd);
            
        }
    }
}
