using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class RespawnPoint : MonoBehaviour
{
    public GameObject playerGO;
    public float yLimit = -15;

    [field: SerializeField]
    private UnityEvent OnSpawnPointActivated { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.playerGO = collision.gameObject;
            OnSpawnPointActivated?.Invoke();
            
        }
        
    }

    private void Start()
    {
        OnSpawnPointActivated.AddListener(() => GetComponentInParent<RespawnPointManager>().UpdateRespawnPoint(this));
    }

    public void RespawnPlayer()
    {
        playerGO.transform.position = transform.position;
    }

    public void SetPlayerGO(GameObject player)
    {
        playerGO = player;
        GetComponent<Collider2D>().enabled = false;
    }

    public void DisableRespawnPoint()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    public void ResetRespawnPoint()
    {
        playerGO = null;
        GetComponent<Collider2D>().enabled = true;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(Selection.activeObject == gameObject)
        {
            Gizmos.color = Color.red;
            var collider = GetComponent<BoxCollider2D>();
            Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
        }
    }
#endif
}
