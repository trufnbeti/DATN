using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class MenuController : MonoBehaviour
    {
        public GameObject menuPanel;
        public void ToggleMenu()
        {
            if(menuPanel.activeSelf == false || menuPanel.activeSelf == true && Time.timeScale == 0)
            {
                Time.timeScale = Time.timeScale == 0 ? 1 : 0;
                menuPanel.SetActive(!menuPanel.activeSelf);
            }
            
        }

        public void ResetTimeScale()
        {
            Time.timeScale = 1;
        }
    }
}
