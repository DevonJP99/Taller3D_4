using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompulsivoBaseState : MonoBehaviour
{
    public abstract void EnterState(CompulsivoStateManager manager);

    public abstract void CollisionEnter(CompulsivoStateManager manager, Collision collision);

    public abstract void TriggerEnter(CompulsivoStateManager manager, Collider collider);

    public abstract void UpdateState(CompulsivoStateManager manager);
}
