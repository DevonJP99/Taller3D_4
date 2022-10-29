using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompulsivePasiveState : CompulsivoBaseState
{
    [SerializeField]
    Transform position;
    float speedPassive = 10;
    CompulsivoStateManager man;
    public override void EnterState(CompulsivoStateManager manager)
    {
        manager.GetNavMeshAgent().speed = speedPassive;
        manager.GetNavMeshAgent().SetDestination(position.position);
        man = manager;
    }

    public override void CollisionEnter(CompulsivoStateManager manager, Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStaticVariable playa = collision.gameObject.GetComponent<PlayerStaticVariable>();
            manager.agresive.playerDetected = playa;
            manager.SwitchState(manager.agresive);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStaticVariable playa = other.GetComponent<PlayerStaticVariable>();
            Debug.Log(playa.PercentComprasFilled());
            if (playa.PercentComprasFilled() >= .5f)
            {
                man.agresive.playerDetected = playa;
                man.SwitchState(man.agresive);
            }
        }
    }

    public override void UpdateState(CompulsivoStateManager manager)
    {
        //iddle animation
    }

    public override void TriggerEnter(CompulsivoStateManager manager, Collider collider)
    {

    }
}
