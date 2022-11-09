using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaAgresiveState : GuardiaBaseState
{
    float agresivespeed;

    public override void CollisionEnter(GuardiaStateManager manager, Collision collision)
    {
    }

    public override void EnterState(GuardiaStateManager manager)
    {
        manager.GetNavMeshAgent().speed = agresivespeed;
        manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
    }

    public override void TriggerEnter(GuardiaStateManager manager, Collider collider)
    {
    }

    public override void UpdateState(GuardiaStateManager manager)
    {
        if (manager.playerDetected)
        {
            manager.GetNavMeshAgent().SetDestination(manager.playerDetected.transform.position);
        }
    }

    public override void TriggerExit(GuardiaStateManager manager, Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.playerDetected = null;
            GetComponent<GuardiaStateManager>().SwitchState(GetComponent<GuardiaStateManager>().pasive);
        }
    }
}
