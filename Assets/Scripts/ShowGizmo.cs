using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmo : MonoBehaviour
{
    public Color Color;
    public GizmoTypes Type;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color;
        switch (Type)
        {
            case GizmoTypes.cube:
                Gizmos.DrawWireCube(transform.position, transform.localScale);
                break;
            case GizmoTypes.sphere:
                Gizmos.DrawWireSphere(transform.position, transform.localScale.magnitude);
                break;
        }
  
    }

    public enum GizmoTypes
    {
        cube, sphere
    }
}
