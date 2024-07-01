using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Platformer.UI
{
    public class PointsUI : MonoBehaviour
    {
        private TextMeshProUGUI pointsText;

        public UnityEvent OnTextChange;

        private void Awake()
        {
            pointsText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetPoints(int val)
        {
            pointsText.SetText(val.ToString());
            OnTextChange?.Invoke();
        }
    }
}

