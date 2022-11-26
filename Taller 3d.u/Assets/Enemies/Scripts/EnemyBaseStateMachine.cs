using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseStateMachine : EnemyBase
{
    NavMeshAgent agent;
    EnemyBaseState current;
    
    public EnemyBaseState pasive;
    public EnemyBaseState agresive;

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        current = pasive;
        current.EnterState(this);
    }

    private void Update()
    {
        current.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState _new)
    {
        current = _new;
        current.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        current.CollisionEnter(this, collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        current.TriggerEnter(this, other);
    }

    private void OnTriggerExit(Collider other)
    {
        current.TriggerExit(this, other);
    }
}
