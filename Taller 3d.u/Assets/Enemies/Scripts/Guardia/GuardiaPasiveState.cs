using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaPasiveState : EnemyCompradorStatePasive
{

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {
        if (collider.gameObject.CompareTag(manager.name_player_tag))
        {
            manager.SwitchState(manager.agresive);
        }
    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider collider)
    {
       
    }

    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {
        if (inAisle)
        {
            manager.GetNavMeshAgent().SetDestination(randomAisleSpace());
            inAisle = false;
        }
        else
        {
            float deltaDiference = .6f;
            if (Vector3.Distance(manager.transform.position, manager.GetNavMeshAgent().destination) < deltaDiference)
            {
                inAisle = true;
            }
        }

        /*if (Vector3.Distance(manager.transform.position, manager.GetNavMeshAgent().destination) < .1f)
        {
            manager.GetNavMeshAgent().SetDestination(randomAisleSpace());
        }*/
    }
}
