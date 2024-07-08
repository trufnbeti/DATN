using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Platformer
{
    public class ContinueButton : MonoBehaviour
    {
        public SceneManagement sceneManagement;
        public Button continueButton;

        private int levelIndex = -1;

        public UnityEvent OnLevelLoaded;

        private void Awake()
        {
            if (sceneManagement == null)
                sceneManagement = FindObjectOfType<SceneManagement>();
            continueButton = GetComponent<Button>();
        }

        private void Start()
        {
            levelIndex = SaveSystem.Level;
            if(levelIndex > -1)
            {
                continueButton.onClick.AddListener(() => sceneManagement.LoadSceneWithIndex(levelIndex));
                continueButton.interactable = true;
                OnLevelLoaded?.Invoke();
            }
        }
    }
}
