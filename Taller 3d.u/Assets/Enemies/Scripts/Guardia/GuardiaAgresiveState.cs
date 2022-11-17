using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaAgresiveState : EnemyBaseState
{
    float agresivespeed;
    float atakRadius = 5;
    float damage = 10;

    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {
    }

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        manager.GetNavMeshAgent().speed = agresivespeed;
        manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {

    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {
        if (manager.playerDetected)
        {
            manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
            if (Vector3.Distance(manager.GetNavMeshAgent().destination,transform.position) < atakRadius)
            {
                manager.playerDetected.vida -= 10;
                Debug.Log("Stunear al player"); 
            }
        }
    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.playerDetected = null;
            GetComponent<EnemyBaseStateMachine>().SwitchState(GetComponent<EnemyBaseStateMachine>().pasive);
        }
    }
}
