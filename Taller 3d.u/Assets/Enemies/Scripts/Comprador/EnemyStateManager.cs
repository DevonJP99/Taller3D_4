using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : EnemyBase
{
    NavMeshAgent agent;
    EnemyBaseState current;

    [SerializeField]
    Transform[] pointsToGo;
    public Transform head;

    public EnemyBaseState pasive;
    public EnemyBaseAgresiveState agresive; 
    public EnemyStateWithObject hurry;

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }

    private void Start()
    {
        pasive = new EnemyCompradorStatePasive(pointsToGo);
        agresive = new EnemyCompradorStateAgresive();
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
        current.OnCollisionEnter(this, collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        current.OnTriggerEnter(this, other);
    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, (transform.position - Vector3.zero).normalized);
    }*/
}
