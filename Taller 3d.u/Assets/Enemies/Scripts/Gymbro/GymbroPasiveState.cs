using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymbroPasiveState : GymbroBaseState
{
    Vector3 direction;
    float speedPassive = 10;

    public override void EnterState(GymbroStateManager manager)
    {
        manager.GetNavMeshAgent().speed = speedPassive;
        Vector2 ww = Random.insideUnitCircle;
        direction = new Vector3(ww.x, 0, ww.y);
        manager.GetNavMeshAgent().SetDestination(transform.position + direction);
        //Debug.Log(direction);
    }

    public override void CollisionEnter(GymbroStateManager manager, Collision collision)
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
            Debug.Log(direction);
        }

    }

    public override void TriggerEnter(GymbroStateManager manager, Collider collider)
    {
        if (collider.gameObject.GetComponent<PlayerStaticVariable>())
        {
            manager.playerDetected = collider.GetComponent<PlayerStaticVariable>();
            manager.SwitchState(manager.agresive);
        }
    }

    public override void UpdateState(GymbroStateManager manager)
    {
        manager.GetNavMeshAgent().SetDestination(transform.position + direction);
    }
    public override void TriggerExit(GymbroStateManager manager, Collider collider)
    {
       
    }
}