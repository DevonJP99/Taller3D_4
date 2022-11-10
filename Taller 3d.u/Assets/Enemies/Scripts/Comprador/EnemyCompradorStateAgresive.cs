using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCompradorStateAgresive : EnemyBaseAgresiveState
{
    //follow
    float agresiveSpeed = 17;

    //Attack
    int damage = 1;
    float deltaCooldown, atackCooldown = 3f;
    float rangeAtack = 5f;

    public override void EnterState(EnemyStateManager manager)
    {
        manager.GetNavMeshAgent().SetDestination(playerDetected.transform.position);
        manager.GetNavMeshAgent().speed = agresiveSpeed;
        //Debug.Log(manager.GetNavMeshAgent().speed);
    }

    public override void OnCollisionEnter(EnemyStateManager manager, Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager.GetNavMeshAgent().SetDestination(playerDetected.transform.position);
            playerDetected = collision.gameObject.GetComponent<PlayerStaticVariable>().transform;
        }
    }

    public override void OnTriggerEnter(EnemyStateManager manager, Collider collider)
    {
        /*if (collider.CompareTag("MeoObjecto"))
        {
            manager.GetNavMeshAgent().SetDestination(playerDetected.transform.position);
            playerDetected = null;
            manager.head.transform.localRotation = Quaternion.identity;
            manager.SwitchState(manager.pasive);
        }*/
        if (collider.CompareTag("Player"))
        {
            playerDetected = collider.transform;
            manager.GetNavMeshAgent().SetDestination(playerDetected.transform.position);
        }

    }

    public override void UpdateState(EnemyStateManager manager)
    {
        //llego  a su destino?
        if (Vector3.Distance(manager.transform.position, playerDetected.transform.position) < rangeAtack)
        {
            Atack();
            manager.GetNavMeshAgent().SetDestination(playerDetected.transform.position);
        }
        else if (Vector3.Distance(manager.transform.position, manager.GetNavMeshAgent().destination) < 0.35f)
        {
            Debug.Log("Me rindo quiero productos");
            playerDetected = null;
            manager.head.transform.localRotation = Quaternion.identity;
            manager.SwitchState(manager.pasive);
        }


        if (deltaCooldown >= 0)
        {
            deltaCooldown -= Time.deltaTime;
        }

        if (playerDetected) manager.head.transform.LookAt(manager.GetNavMeshAgent().destination);
    }

    private void Atack()
    {
        if (deltaCooldown < 0)
        {
            playerDetected.GetComponent<PlayerStaticVariable>().vida -= damage;
            deltaCooldown = atackCooldown;
            //Debug.Log(playerDetected.GetComponent<PlayerStaticVariable>().vida);
        }
    }
}
