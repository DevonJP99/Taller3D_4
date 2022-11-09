using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymbroEmbestirState : GymbroBaseState
{
    /// <summary>
    /// tag used to recognice the actula ground and diferiate from a stall or anotehr building
    /// </summary>
    [SerializeField]
    string groundTag = "Ground";
    [SerializeField]
    float speedEmbestida = 20;
    int damage = 20;

    public override void CollisionEnter(GymbroStateManager manager, Collision collision)
    {
        if (collision.collider.gameObject.isStatic && !collision.collider.CompareTag(groundTag))
        {
            Debug.Log(collision.collider.name);
            manager.SwitchState(manager.pasive);
        }
        else
        {
            collision.rigidbody?.AddForce((transform.forward).normalized, ForceMode.Force);
            if (collision.collider.CompareTag("Player"))
            {
                collision.collider.GetComponent<PlayerStaticVariable>().vida -= damage;
            }
        }
    }

    public override void EnterState(GymbroStateManager manager)
    {
        manager.GetNavMeshAgent().SetDestination(transform.position + transform.forward.normalized * 5);
        manager.GetNavMeshAgent().speed = speedEmbestida;
        Debug.Log("Embesteindo");
        Debug.Log("transform.forward");
    }

    public override void TriggerEnter(GymbroStateManager manager, Collider collider)
    {

    }

    public override void UpdateState(GymbroStateManager manager)
    {
        //Debug.Log(collision.collider.name);
        manager.GetNavMeshAgent().SetDestination(transform.position + transform.forward.normalized * 5);
    }

    public override void TriggerExit(GymbroStateManager manager, Collider collider)
    {
    }
}
