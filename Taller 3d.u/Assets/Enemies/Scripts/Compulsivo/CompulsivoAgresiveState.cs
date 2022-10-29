using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompulsivoAgresiveState : CompulsivoBaseState
{
    //follow
    float agresiveSpeed = 17;

    //Attack
    int damage = 1;
    float deltaCooldown, atackCooldown = 3f;
    float rangeAtack = 1.5f;

    public PlayerStaticVariable playerDetected;

    public override void EnterState(CompulsivoStateManager manager)
    {
        manager.GetNavMeshAgent().SetDestination(playerDetected.transform.position);
        manager.GetNavMeshAgent().speed = agresiveSpeed;
    }

    public override void CollisionEnter(CompulsivoStateManager manager, Collision collision)
    {
        //throw new System.NotImplementedException();
    }

    public override void TriggerEnter(CompulsivoStateManager manager, Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerDetected = collider.GetComponent<PlayerStaticVariable>();
            manager.GetNavMeshAgent().SetDestination(playerDetected.transform.position);
        }
    }

    public override void UpdateState(CompulsivoStateManager manager)
    {
        if (playerDetected)
        {
            manager.GetNavMeshAgent().SetDestination(playerDetected.transform.position);
            if (Vector3.Distance(manager.transform.position, playerDetected.transform.position) < rangeAtack)
            {
                Atack();
            }
        }
        
        if (Vector3.Distance(manager.transform.position, manager.GetNavMeshAgent().transform.position) < .1f && !playerDetected)
        {
            manager.SwitchState(manager.pasive);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = null;
        }
    }

    private void Atack()
    {
        if (deltaCooldown < 0)
        {
            playerDetected.vida -= damage;
            deltaCooldown = atackCooldown;
            Debug.Log(playerDetected.vida);
        }
    }
}
