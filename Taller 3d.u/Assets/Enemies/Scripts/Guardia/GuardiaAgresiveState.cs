using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaAgresiveState : GuardiaBaseState
{
    public  Player playerDetected;
    float agresivespeed;

    public override void CollisionEnter(GuardiaStateManager manager, Collision collision)
    {
        //throw new System.NotImplementedException();
    }

    public override void EnterState(GuardiaStateManager manager)
    {
        manager.GetNavMeshAgent().speed = agresivespeed;
        manager.GetNavMeshAgent().SetDestination(playerDetected.transform.position);
        //throw new System.NotImplementedException();
    }

    public override void TriggerEnter(GuardiaStateManager manager, Collider collider)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(GuardiaStateManager manager)
    {
        if (playerDetected)
        {
            manager.GetNavMeshAgent().SetDestination(playerDetected.transform.position);
        }
        //throw new System.NotImplementedException();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = null;
            GetComponent<GuardiaStateManager>().SwitchState(GetComponent<GuardiaStateManager>().pasive);
        }
    }
}
