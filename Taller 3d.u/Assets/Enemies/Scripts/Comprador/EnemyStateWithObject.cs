using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateWithObject : EnemyBaseState
{
    GameObject _object;
    float speedHurry = 21;
    float beforeDetroyObject = 5f;
    Vector3 direction;
    float deltacooldown;

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        deltacooldown = beforeDetroyObject;
        direction = manager.transform.position - _object.transform.position;
        direction.y = 0;
        direction.Normalize();
        manager.GetNavMeshAgent().SetDestination(_object.transform.position);
        manager.GetNavMeshAgent().speed = speedHurry;
    }

    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {

    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            direction = manager.transform.position - collider.transform.position;
            direction.y = 0;
            direction.Normalize();
            manager.GetNavMeshAgent().SetDestination(manager.transform.position + direction * 2);
        }
    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {
        if (deltacooldown > 0)
        {
            deltacooldown -= Time.deltaTime;
            manager.GetNavMeshAgent().SetDestination(manager.transform.position + direction * 2);
        }
    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider collider)
    {
        //throw new System.NotImplementedException();
    }

    /*
public override void OnReceieveDamage(EnemyBaseStateMachine manager)
{
   base.OnReceieveDamage(manager);
   _object.transform.position = manager.transform.position;
   direction.y = 1;
   direction.z *= -1;
   direction.x *= -1;
   _object.GetComponent<Rigidbody>().AddForce(direction.normalized, ForceMode.VelocityChange);
}*/
}
