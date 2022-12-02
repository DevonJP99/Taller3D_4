using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaAgresiveState : EnemyBaseState
{
    public Transform entrancePosition;
    float agresivespeed = 20;

    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {
        if (collision.gameObject.CompareTag(manager.name_player_tag))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            collision.transform.rotation = Quaternion.identity;
            collision.gameObject.transform.position = entrancePosition.position;
            int comm = collision.gameObject.GetComponent<PlayerStaticVariable>().compras;
            collision.gameObject.GetComponent<PlayerStaticVariable>().compras = comm > 0 ? (int)(comm /2) : 0; 
            manager.playerDetected = null;
            GetComponent<EnemyBaseStateMachine>().SwitchState(GetComponent<EnemyBaseStateMachine>().pasive);
        }
    }

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        manager.GetNavMeshAgent().speed = agresivespeed;
        Debug.Log(manager.playerDetected);
        manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {

    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {
        
    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider other)
    {
        if (other.CompareTag(manager.name_player_tag))
        {
            manager.playerDetected = null;
            manager.SwitchState(manager.pasive);
        }
    }
}
