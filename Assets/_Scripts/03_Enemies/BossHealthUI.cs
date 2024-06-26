using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class BossHealthUI : MonoBehaviour
    {
        public GameObject healthPanel;
        public Slider slider;

        public void Initialize(int val)
        {
            slider.maxValue = val;
        }

        public void SetHealth(int val)
        {
            slider.value = val;
        }

        public void ToggleHealthPanel(bool val)
        {
            healthPanel.SetActive(val);
        }
    }
}
