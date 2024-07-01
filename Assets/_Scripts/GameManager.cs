using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public CameraManager cameraManager;
        public RespawnPointManager spawnPointManager;
        public Agent player;
        private SceneManagement sceneManagement;

        private void Awake()
        {
            if (cameraManager == null)
                cameraManager = FindObjectOfType<CameraManager>();
            if (spawnPointManager == null)
                spawnPointManager = FindObjectOfType<RespawnPointManager>();
            if (player == null)
                player = FindObjectOfType<PlayerInputPlatformer>().GetComponentInChildren<Agent>();
            sceneManagement = FindObjectOfType<SceneManagement>();
        }

        private void Start()
        {
            LoadSavedData();
            player.gameObject.SetActive(false);

            spawnPointManager.Respawn(player.gameObject);
            cameraManager.SetCameraTarget(player.transform);
        }

        private static void LoadSavedData()
        {
            var savingScripts = FindObjectsOfType<MonoBehaviour>().OfType<ISavingData>();
            foreach (var item in savingScripts)
            {
                item.LoadData();
            }
        }

        public void RespawnPlayer()
        {
            spawnPointManager.Respawn(player.gameObject);
            player.InitializeAgent(true);
        }

        public void SaveGameData()
        {
            var savingScripts = FindObjectsOfType<MonoBehaviour>().OfType<ISavingData>();
            foreach (var item in savingScripts)
            {
                item.SaveData();
            }
            SaveSystem.SaveGameData(sceneManagement.GetNextLevelIndex());
            
        }
    }
}
