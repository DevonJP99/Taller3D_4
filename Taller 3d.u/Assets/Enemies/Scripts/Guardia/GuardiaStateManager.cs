using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardiaStateManager : EnemyBase
{
    NavMeshAgent agent;
    GuardiaBaseState current;

    public GuardiaPasiveState pasive;
    public GuardiaAgresiveState agresive;

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pasive = GetComponent<GuardiaPasiveState>();
        agresive = GetComponent<GuardiaAgresiveState>();
        current = pasive;
        current.EnterState(this);
    }

    private void Update()
    {
        current.UpdateState(this);
    }

    public void SwitchState(GuardiaBaseState _new)
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
