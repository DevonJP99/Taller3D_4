using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GymbroBaseState : MonoBehaviour
{
    public abstract void EnterState(GymbroStateManager manager);

    public abstract void CollisionEnter(GymbroStateManager manager, Collision collision);

    public abstract void TriggerEnter(GymbroStateManager manager, Collider collider);
    public abstract void TriggerExit(GymbroStateManager manager, Collider collider);

    public abstract void UpdateState(GymbroStateManager manager);
}
