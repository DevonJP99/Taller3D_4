using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : MonoBehaviour
{
    public abstract void EnterState(EnemyBaseStateMachine manager);
    public abstract void UpdateState(EnemyBaseStateMachine manager);
    public abstract void CollisionEnter(EnemyBaseStateMachine manager, Collision collision);
    public abstract void TriggerEnter(EnemyBaseStateMachine manager, Collider collider);
    public abstract void TriggerExit(EnemyBaseStateMachine manager, Collider collider);
}
