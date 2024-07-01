using Platformer.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIMeleeAttackDetector : MonoBehaviour, IAIDetector
{
    public LayerMask targetLayer;

    public UnityEvent<GameObject> OnPlayerDetected;

    [Header("Gizmo parameters")]
    [Range(.1f, 1)]
    public float radius;
    public Color gizmoColor = Color.green;
    public bool showGizmos = true;

    [field: SerializeField]
    public bool PlayerDetected
    {
        get;
        private set;
    }

    private void Update()
    {
        var collider = Physics2D.OverlapCircle(transform.position, radius, targetLayer);
        PlayerDetected = collider != null;
        if (PlayerDetected)
            OnPlayerDetected?.Invoke(collider.gameObject);
    }

    private void OnDrawGizmos()
    {
        if (showGizmos)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position, radius);
        }
    }

    public bool GetDetectorValue()
    {
        return PlayerDetected;
    }
}
