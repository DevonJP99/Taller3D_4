using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager manager);
    public abstract void UpdateState(EnemyStateManager manager);
    public abstract void OnCollisionEnter(EnemyStateManager manager, Collision collision);
    public abstract void OnTriggerEnter(EnemyStateManager manager, Collider collider);
    public virtual void OnReceieveDamage(EnemyStateManager manager)
    {

    }
}
