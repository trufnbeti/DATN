using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class SceneManagement : MonoBehaviour
    {
        [SerializeField]
        private int level_1SceneBuildIndex, menuSceneBuildIndex, winSceneBuildIndex;

        private void Awake()
        {
            var result = FindObjectsOfType<SceneManagement>();
            foreach (var manager in result)
            {
                if (manager != this)
                    Destroy(manager.gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public void RestartCurrentLevel()
        {
            LoadSceneWithIndex(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadStartLevel()
        {
            LoadSceneWithIndex(level_1SceneBuildIndex);
        }

        public void LoadNextLevel()
        {
            LoadSceneWithIndex(GetNextLevelIndex());
        }

        public void LoadMenu()
        {
            LoadSceneWithIndex(menuSceneBuildIndex);
        }

        public void LoadWinScreen()
        {
            LoadSceneWithIndex(winSceneBuildIndex);
        }

        public void LoadLoseScreen()
        {
            //LoadSceneWithIndex(loseSceneBuildIndex);
        }

        public void LoadSceneWithIndex(int index)
        {
            SceneManager.LoadScene(index);
        }

        public int GetNextLevelIndex()
        {
            int index = SceneManager.GetActiveScene().buildIndex + 1;
            if(index < SceneManager.sceneCountInBuildSettings)
            {
                return index;
            }
            else
            {
                return winSceneBuildIndex;
            }
            
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
