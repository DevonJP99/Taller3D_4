using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaPasiveState : EnemyBaseState
{
    [SerializeField]
    Transform position;
    float speedPassive = 10;
    List<EnemyBaseStateMachine> enemyDetecteds;
    //float radius = 0;

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        if (!position) position = transform;
        //radius = GetComponent<SphereCollider>().radius;
        manager.GetNavMeshAgent().speed = speedPassive;
        manager.GetNavMeshAgent().SetDestination(position.position);
        manager.OnReceiveDamage.AddListener(SwitchingState);
        //Debug.Log(radius);
        //RaycastHit[] objects_ = Physics.SphereCastAll(transform.position, radius, Vector3.up, 0);
        //for (int i = 0; i < objects_.Length; i++)
        //{
        //    if (objects_[i].collider.CompareTag("Enemy"))
        //    {
        //        EnemyBase ee = objects_[i].collider.GetComponent<EnemyBase>();
        //        ee.OnReceiveDamage.AddListener(this.SwitchingState);
        //        //enemiesRegistred.Add(objects_[i].collider.gameObject);
        //    }
        //}
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
