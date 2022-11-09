using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymbroEmbestirState : GymbroBaseState
{
    [SerializeField]
    float speedEmbestida = 20;
    public Vector3 direction;
    int damage = 20;

    public override void CollisionEnter(GymbroStateManager manager, Collision collision)
    {
        if (collision.collider.gameObject.isStatic)
        {
            manager.SwitchState(manager.pasive);
        }
        else
        {
            collision.rigidbody.AddForce((transform.forward).normalized, ForceMode.Force);
            if (collision.collider.CompareTag("Player"))
            {
                collision.collider.GetComponent<PlayerStaticVariable>().vida -= damage;
            }
        }
    }

    public override void EnterState(GymbroStateManager manager)
    {
        direction = manager.playerDetected.transform.position - transform.position;
        direction.Normalize();
        manager.GetNavMeshAgent().SetDestination(transform.position + direction);
    }

    public override void TriggerEnter(GymbroStateManager manager, Collider collider)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(GymbroStateManager manager)
    {
        throw new System.NotImplementedException();
    }

    public override void TriggerExit(GymbroStateManager manager, Collider collider)
    {
        throw new System.NotImplementedException();
    }
}
