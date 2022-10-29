using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GymbroStateManager : EnemyBase
{
    NavMeshAgent agent;
    GymbroBaseState current;

    public GymbroPasiveState pasive;
    public GymbroAgresiveState agresive;

    public NavMeshAgent GetNavMeshAgent()
    {
        return agent;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pasive = GetComponent<GymbroPasiveState>();
        agresive = GetComponent<GymbroAgresiveState>();
        current = pasive;
        current.EnterState(this);
    }

    private void Update()
    {
        current.UpdateState(this);
    }

    public void SwitchState(GymbroBaseState _new)
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
}
