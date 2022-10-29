using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompulsivoStateManager : EnemyBase
{
    NavMeshAgent agent;
    CompulsivoBaseState current;

    public CompulsivePasiveState pasive;
    public CompulsivoAgresiveState agresive;

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pasive = GetComponent<CompulsivePasiveState>();
        agresive = GetComponent<CompulsivoAgresiveState>();
        current = pasive;
        current.EnterState(this);
    }

    private void Update()
    {
        current.UpdateState(this);
    }

    public void SwitchState(CompulsivoBaseState _new)
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
    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, (transform.position - Vector3.zero).normalized);
    }*/
}
