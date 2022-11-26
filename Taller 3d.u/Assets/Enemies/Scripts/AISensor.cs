using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    public float distance = 10;
    public float angle = 10;
    public float height = 10;
    public Color meshColor = Color.black;
    public LayerMask layerMask;

    public List<Collider> Scan()
    {
        //return Physics.OverlapSphereNonAlloc(transform.position,distance,,layer,QueryTriggerInteraction.Collide);
        return new List<Collider>(Physics.OverlapSphere(transform.position,distance, layerMask, QueryTriggerInteraction.Collide));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = meshColor;
        Gizmos.DrawSphere(transform.position,distance);
    }
}
