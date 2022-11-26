using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaAgresiveState : EnemyBaseState
{
    float agresivespeed = 20;
    float atakRadius = 5;
    public int damage = 10;

    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {

    }

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        manager.GetNavMeshAgent().speed = agresivespeed;
        //Debug.Log(manager.playerDetected);
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
                manager.GetNavMeshAgent().destination = transform.position;
                /*manager.playerDetected.vida -= damage;
                Debug.Log("Stunear al player"); */
            }
        }
    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider other)
    {
        if (other.CompareTag(manager.name_player_tag))
        {
            manager.playerDetected = null;
            GetComponent<EnemyBaseStateMachine>().SwitchState(GetComponent<EnemyBaseStateMachine>().pasive);
        }
    }
}
