using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBounds : MonoBehaviour
{
    [SerializeField]
    private Bounds bounds;

    private void LateUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 clampedPosition = bounds.ClosestPoint(currentPosition);
        transform.position = clampedPosition;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(bounds.center, bounds.size);

    }
#endif
}
