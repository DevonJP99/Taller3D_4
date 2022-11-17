using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCompradorStatePasive : EnemyBaseState
{
    //carrito ya que carrito no tiene que ser hijo del enemigo es su propio obejto
    [SerializeField]
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
   
    public override void EnterState(EnemyBaseStateMachine manager)
    {
        Debug.Log("Que me voy pa un aisle");

        randomCooldown();
        inAisle = false;
        pointIndex = 0;
        manager.GetNavMeshAgent().speed = pasiveSpeed;
        manager.GetNavMeshAgent().SetDestination(randomAisleSpace());
    }

    public override void UpdateState(EnemyBaseStateMachine manager)
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


    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {
        if (collision.gameObject.CompareTag(manager.name_player_tag))
        {
            PlayerStaticVariable playa = collision.gameObject.GetComponent<PlayerStaticVariable>();
            manager.playerDetected = playa;
            Debug.Log("HEY TE ENCONTREE");
            manager.SwitchState(manager.agresive);
        }
    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {
        if (collider.gameObject.CompareTag(manager.name_player_tag))
        {
            PlayerStaticVariable playa = collider.gameObject.GetComponent<PlayerStaticVariable>();
            //float aux = playa.PercentComprasFilled();
            //if (Random.value < aux || aux == 1)
            //{

            //}
            //Debug.Log(playa.espacioCarrito);
            manager.playerDetected = playa;
            Debug.Log("HEY TE ENCONTREE");
            manager.SwitchState(manager.agresive);
        }
    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider collider)
    {
        //throw new System.NotImplementedException();
    }
}
