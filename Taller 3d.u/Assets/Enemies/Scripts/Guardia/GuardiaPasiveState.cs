using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiaPasiveState : EnemyBaseState
{
    [SerializeField]
    Transform position;
    float speedPassive = 10;
    //float radius = 0;

    //public List<GameObject> enemiesRegistred;

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        //radius = GetComponent<SphereCollider>().radius;
        manager.GetNavMeshAgent().speed = speedPassive;
        manager.GetNavMeshAgent().SetDestination(position.position);
        //manager.OnReceiveDamage.AddListener(SwitchingState);
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
        if (collider.CompareTag("Enemy"))
        {
            EnemyBase enem = collider.GetComponent<EnemyBase>();
            enem.OnReceiveDamage.AddListener(this.SwitchingState);
            //enemiesRegistred.Add(enem.gameObject);
        }
    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyBase enem = other.GetComponent<EnemyBase>();
            Debug.LogError(enem.OnReceiveDamage);

            //enem.OnReceiveDamage.AddListener(this.SwitchingState);
            //enemiesRegistred.Remove(enem.gameObject);
        }
    }

    void SwitchingState(int damage, PlayerStaticVariable player)
    {
        EnemyBaseStateMachine man = GetComponent<EnemyBaseStateMachine>();
        man.playerDetected = player;
        man.SwitchState(man.agresive);
        man.OnReceiveDamage.RemoveListener(SwitchingState);
    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            EnemyBase enem = collider.GetComponent<EnemyBase>();
            enem.OnReceiveDamage.RemoveListener(this.SwitchingState);
            Debug.LogError(enem.OnReceiveDamage);
        }
    }
}
