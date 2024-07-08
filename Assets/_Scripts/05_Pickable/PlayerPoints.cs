using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class PlayerPoints : MonoBehaviour, ISavingData
    {
        
        public UnityEvent<int> OnPointsValueChange;
        public UnityEvent OnPickUpPoints;
        private int points = 0;

        public int Points { get => points; private set => points = value; }

        public void Add(int amount)
        {
            Points += amount;
            OnPickUpPoints?.Invoke();
            OnPointsValueChange?.Invoke(Points);
        }

        public void SaveData()
        {
            SaveSystem.Point = Points;
        }

        public void LoadData()
        {
            Points = SaveSystem.Point;
            OnPointsValueChange?.Invoke(Points);
        }
    }
}
