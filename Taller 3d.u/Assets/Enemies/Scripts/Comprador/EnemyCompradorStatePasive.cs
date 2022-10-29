using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCompradorStatePasive : EnemyBaseState
{
    //carrito ya que carrito no tiene que ser hijo del enemigo es su propio obejto
    Transform[] pointsToGo;
    int pointIndex = 0;
    float pasiveSpeed = 10;

    
    float maxCooldown = 5, minCooldown = 1;
    float cooldown = 5;
    bool inAisle = false;
    
    void randomCooldown()
    {
        cooldown = Random.Range(minCooldown, maxCooldown);
    }
    

    public EnemyCompradorStatePasive(Transform[] _pointsToGo)
    {
        pointsToGo = _pointsToGo;
    }

    public override void EnterState(EnemyStateManager manager)
    {
        Debug.Log("Que me voy pa un aisle");

        randomCooldown();
        inAisle = false;
        pointIndex = 0;
        manager.GetNavMeshAgent().speed = pasiveSpeed;
        manager.GetNavMeshAgent().SetDestination(randomAisleSpace());
    }

    public override void UpdateState(EnemyStateManager manager)
    {
        if (inAisle)
        {
            if (cooldown <= 0)
            {
                manager.GetNavMeshAgent().SetDestination(randomAisleSpace());
                inAisle = false;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
        else
        {
            float deltaDiference = .6f;
            if (Vector3.Distance(manager.transform.position, manager.GetNavMeshAgent().destination) < deltaDiference)
            {
                randomCooldown();
                inAisle = true;
            }
        }

        /*if (Vector3.Distance(manager.transform.position, manager.GetNavMeshAgent().destination) < .1f)
        {
            manager.GetNavMeshAgent().SetDestination(randomAisleSpace());
        }*/
    }

    Vector3 randomAisleSpace()
    {
        return pointsToGo[pointIndex = Random.Range(0, pointsToGo.Length)].position;
    }


    public override void OnCollisionEnter(EnemyStateManager manager, Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform playa = collision.transform;
            manager.agresive.playerDetected = playa;
            Debug.Log("HEY TE ENCONTREE");
            manager.SwitchState(manager.agresive);
        }
    }

    public override void OnTriggerEnter(EnemyStateManager manager, Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerStaticVariable playa = collider.gameObject.GetComponent<PlayerStaticVariable>();
            float aux = playa.PercentComprasFilled();
            if (Random.value < aux || aux == 1)
            {
                //Debug.Log(playa.espacioCarrito);
                manager.agresive.playerDetected = playa.transform;
                Debug.Log("HEY TE ENCONTREE");
                manager.SwitchState(manager.agresive);
            }
        }
    }
}
