using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompulsivoAgresiveState : EnemyBaseState 
{
    //follow
    float agresiveSpeed = 17;

    //Attack
    int damage = 1;
    float deltaCooldown, atackCooldown = 3f;
    float rangeAtack = 1.5f;

    //public PlayerStaticVariable playerDetected;

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
        manager.GetNavMeshAgent().speed = agresiveSpeed;
    }

    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {
        //throw new System.NotImplementedException();
    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {
        if (collider.CompareTag(manager.name_player_tag))
        {
            manager.playerDetected = collider.GetComponent<PlayerStaticVariable>();
            manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
        }
    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {
        if (manager.playerDetected)
        {
            manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
            if (Vector3.Distance(manager.transform.position, manager.playerDetected.transform.position) < rangeAtack)
            {
                Atack();
            }
        }
        
        if (Vector3.Distance(manager.transform.position, manager.GetNavMeshAgent().transform.position) < .1f && !manager.playerDetected)
        {
            manager.SwitchState(manager.pasive);
        }
    }

    public override void TriggerExit(EnemyBaseStateMachine manager,Collider other)
    {
        if (other.CompareTag(manager.name_player_tag))
        {
            manager.playerDetected = null;
        }
    }

    private void Atack()
    {
        if (deltaCooldown < 0)
        {
            GetComponent<EnemyBaseStateMachine>().playerDetected.vida -= damage;
            deltaCooldown = atackCooldown;
            Debug.Log(GetComponent<EnemyBaseStateMachine>().playerDetected.vida);
        }
    }
}
