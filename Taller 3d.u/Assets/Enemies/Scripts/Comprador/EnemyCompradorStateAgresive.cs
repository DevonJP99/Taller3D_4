using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCompradorStateAgresive : EnemyBaseState
{
    //follow
    float agresiveSpeed = 17;

    //Attack
    int damage = 1;
    float deltaCooldown, atackCooldown = 3f;
    float rangeAtack = 5f;

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
        manager.GetNavMeshAgent().speed = agresiveSpeed;
        //Debug.Log(manager.GetNavMeshAgent().speed);
    }

    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {
        if (collision.gameObject.CompareTag(manager.name_player_tag))
        {
            manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
            manager.playerDetected = collision.gameObject.GetComponent<PlayerStaticVariable>();
        }
    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {
        
        if (collider.CompareTag(manager.name_player_tag))
        {
            manager.playerDetected = collider.GetComponent<PlayerStaticVariable>();
            manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
        }

    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider collider)
    {
        //throw new NotImplementedException();
    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {
        //llego  a su destino?
        if (Vector3.Distance(manager.transform.position, manager.playerDetected.transform.position) < rangeAtack)
        {
            Atack(manager.playerDetected);
            manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
        }
        else if (Vector3.Distance(manager.transform.position, manager.GetNavMeshAgent().destination) < 0.35f)
        {
            Debug.Log("Me rindo quiero productos");
            manager.playerDetected = null;
            //manager.head.transform.localRotation = Quaternion.identity;
            manager.SwitchState(manager.pasive);
        }


        if (deltaCooldown >= 0)
        {
            deltaCooldown -= Time.deltaTime;
        }

        //if (manager.playerDetected) manager.head.transform.LookAt(manager.GetNavMeshAgent().destination);
    }

    private void Atack(PlayerStaticVariable play)
    {
        if (deltaCooldown < 0)
        {
            play.vida -= damage;
            deltaCooldown = atackCooldown;
            //Debug.Log(playerDetected.GetComponent<PlayerStaticVariable>().vida);
        }
    }
}
