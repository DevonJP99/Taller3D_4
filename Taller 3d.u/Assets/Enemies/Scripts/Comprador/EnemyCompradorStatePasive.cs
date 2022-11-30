using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCompradorStatePasive : EnemyBaseState
{
    //carrito ya que carrito no tiene que ser hijo del enemigo es su propio obejto
    public List<Transform> pointsToGo;
    int pointIndex = 0;
    float pasiveSpeed = 10;

    float maxCooldown = 5, minCooldown = 1;
    float cooldown = 5;
    protected bool inAisle = false;

    void randomCooldown()
    {
        cooldown = Random.Range(minCooldown, maxCooldown);
    }

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        //manager.OnReceiveDamage.AddListener(SwitchingAgresive);

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

    protected Vector3 randomAisleSpace()
    {
        pointIndex = (int)(Random.value * pointsToGo.Count);
        while (pointsToGo[pointIndex] == null)
        {
            pointsToGo.RemoveAt(pointIndex);
            pointIndex = (int)(Random.value * pointsToGo.Count);
        }
        return pointsToGo[pointIndex].position;
    }

    
    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {
        /*if (collision.gameObject.CompareTag(manager.name_player_tag))
        {
            PlayerStaticVariable playa = collision.gameObject.GetComponent<PlayerStaticVariable>();
            //SwitchingAgresive(0, playa);
        }*/
    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {
        /*if (collider.gameObject.CompareTag(manager.name_player_tag))
        {
            PlayerStaticVariable playa = collider.gameObject.GetComponent<PlayerStaticVariable>();
            //SwitchingAgresive(0, playa);
        }*/
    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider collider)
    {
        //throw new System.NotImplementedException();
    }
    /*
    public void SwitchingAgresive(int damage, PlayerStaticVariable player)
    {
        EnemyBaseStateMachine manager = GetComponent<EnemyBaseStateMachine>();
        manager.playerDetected = player;
        Debug.Log("HEY TE ENCONTREE");
        manager.SwitchState(manager.agresive);
    }*/
}
