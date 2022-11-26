using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymbroPasiveState : EnemyBaseState
{
    Vector3 direction;
    float speedPassive = 10;

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        manager.GetNavMeshAgent().speed = speedPassive;
        Vector2 ww = Random.insideUnitCircle;
        direction = new Vector3(ww.x, 0, ww.y);
        manager.GetNavMeshAgent().SetDestination(transform.position + direction);
        //Debug.Log(direction);
    }

    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerStaticVariable>())
        {
            manager.playerDetected =  collision.gameObject.GetComponent<PlayerStaticVariable>();
            manager.SwitchState(manager.agresive);
        }
        else
        {
            Vector3 aux = collision.GetContact(0).normal;
            aux.y = 0;
            aux.Normalize();
            direction = aux;
            //Debug.Log(direction);
        }

    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {
        if (collider.gameObject.GetComponent<PlayerStaticVariable>())
        {
            manager.playerDetected = collider.GetComponent<PlayerStaticVariable>();
            manager.SwitchState(manager.agresive);
        }
    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {
        manager.GetNavMeshAgent().SetDestination(transform.position + direction);
    }
    public override void TriggerExit(EnemyBaseStateMachine manager, Collider collider)
    {
       
    }
}