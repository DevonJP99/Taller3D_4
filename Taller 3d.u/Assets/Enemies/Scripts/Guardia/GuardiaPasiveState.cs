using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaPasiveState : EnemyBaseState
{
    [SerializeField]
    Transform position;
    float speedPassive = 10;

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        Debug.Log("Awa");
        //position = transform.position;
        manager.GetNavMeshAgent().speed = speedPassive;
        manager.GetNavMeshAgent().SetDestination(position.position);
        manager.OnReceiveDamage.AddListener(SwitchingState);
    }


    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {

    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            EnemyBase enem = collider.GetComponent<EnemyBase>();
            enem.OnReceiveDamage.AddListener(this.SwitchingState);
            //enemiesRegistred.Add(enem.gameObject);
        }
    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {
        
    }

    public void SwitchingState(int damage, PlayerStaticVariable player)
    {
        Debug.Log(damage + " " + player.name);
        EnemyBaseStateMachine man = GetComponent<EnemyBaseStateMachine>();
        man.playerDetected = player;
        man.SwitchState(man.agresive);
        man.OnReceiveDamage.RemoveListener(SwitchingState);
    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider collider)
    {
        
    }
}
