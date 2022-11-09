using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GuardiaBaseState : MonoBehaviour
{
    public abstract void EnterState(GuardiaStateManager manager);

    public abstract void CollisionEnter(GuardiaStateManager manager, Collision collision);

    public abstract void TriggerEnter(GuardiaStateManager manager, Collider collider);
    public abstract void TriggerExit(GuardiaStateManager manager, Collider collider);

    public abstract void UpdateState(GuardiaStateManager manager);
}
