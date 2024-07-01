using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class SceneManagementHelper : MonoBehaviour
    {
        SceneManagement manager;

        private void Awake()
        {
            
            manager = FindObjectOfType<SceneManagement>();
            Debug.Log("LoadmenuButton awake. Manager is "+manager);
        }

        public void LoadMenu()
        {
            manager.LoadMenu();
        }

        public void RestartLevel()
        {
            manager.RestartCurrentLevel();
        }
    }
}
