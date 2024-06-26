using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class SpawnHelper : MonoBehaviour
    {
        private RespawnPointManager manager;

        private void Awake()
        {
            manager = FindObjectOfType<RespawnPointManager>();

        }

        public void RespawnPlayer()
        {
            manager.Respawn(gameObject);
        }

        public void ResetPlayer()
        {
            manager.ResetAllSpawnPoints();
            manager.Respawn(gameObject);
        }
    }
}
