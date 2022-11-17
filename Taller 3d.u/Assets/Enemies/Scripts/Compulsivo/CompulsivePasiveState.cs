using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompulsivePasiveState : EnemyBaseState
{
    [SerializeField]
    Transform position;
    float speedPassive = 10;

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        manager.GetNavMeshAgent().speed = speedPassive;
        manager.GetNavMeshAgent().SetDestination(position.position);
    }

    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {
        if (collision.gameObject.CompareTag(manager.name_player_tag))
        {
            PlayerStaticVariable playa = collision.gameObject.GetComponent<PlayerStaticVariable>();
            manager.playerDetected = playa;
            manager.SwitchState(manager.agresive);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        EnemyBaseStateMachine manager = GetComponent<EnemyBaseStateMachine>();
        if (other.CompareTag(manager.name_player_tag))
        {
            PlayerStaticVariable playa = other.GetComponent<PlayerStaticVariable>();
            Debug.Log(playa.PercentComprasFilled());
            if (playa.PercentComprasFilled() >= .5f)
            {
                manager.playerDetected = playa;
                manager.SwitchState(manager.agresive);
            }
        }
    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {
        //iddle animation
    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {

    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider collider)
    {
    }
}
