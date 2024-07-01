using Platformer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointManager : MonoBehaviour
{
    List<RespawnPoint> respawnPoints = new List<RespawnPoint>();
    RespawnPoint currentRespawnPoint;

    private void Awake()
    {
        
        foreach (Transform item in transform)
        {
            respawnPoints.Add(item.GetComponent<RespawnPoint>());
        }
        currentRespawnPoint = respawnPoints[0];
    }

    public void UpdateRespawnPoint(RespawnPoint newSpawnPoint)
    {
        currentRespawnPoint.DisableRespawnPoint();
        currentRespawnPoint = newSpawnPoint;
    }

    public void Respawn(GameObject objectToRespawn)
    {
        
        RespawnAt(currentRespawnPoint, objectToRespawn);
        objectToRespawn.SetActive(true);
    }

    private void RespawnAt(RespawnPoint spawnPoint, GameObject playeGO)
    {
        
        spawnPoint.SetPlayerGO(playeGO);
        spawnPoint.RespawnPlayer();
    }

    public void ResetAllSpawnPoints()
    {
        foreach (var item in respawnPoints)
        {
            item.ResetRespawnPoint();
        }
        currentRespawnPoint = respawnPoints[0];
    }
}
