using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompradorStateManager : EnemyBaseStateMachine
{
    [SerializeField]
    Collider cart;
    float force = 50;
    float horizontal_force = 200;

    public void ReceiveDamage(int damage_received, PlayerStaticVariable player)
    {
        //aniamtion destroy
        //OnReceiveDamage?.Invoke(damage_received, player);
        Destroy(gameObject, 1);
        //unables ai, gravity
        //actives traigger or no collider
        // force
        GetComponent<NavMeshAgent>().isStopped = true;
        GetComponent<NavMeshAgent>().enabled = false;
        cart.enabled = false;
        self.enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().angularVelocity = Vector3.up * horizontal_force;
        //GetComponent<Rigidbody>().velocity = (transform.position - player.transform.position).normalized * force; 
        GetComponent<Rigidbody>().AddForce((transform.position - player.transform.position).normalized * force, ForceMode.Impulse); 
    }
}
