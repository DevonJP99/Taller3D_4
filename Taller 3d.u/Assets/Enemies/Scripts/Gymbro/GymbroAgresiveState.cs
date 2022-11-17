using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymbroAgresiveState : EnemyBaseState
{
    public Transform head;
    float tiempoMaximo = 3;
    float delta = 0;

    public override void CollisionEnter(EnemyBaseStateMachine manager, Collision collision)
    {

    }

    public override void EnterState(EnemyBaseStateMachine manager)
    {
        //delta = 0;
        //_manager = manager;
        //atacando = false;
    }

    public override void TriggerEnter(EnemyBaseStateMachine manager, Collider collider)
    {
        //if (collider.gameObject.CompareTag("Player") && !atacando)
        /*if (collider.gameObject.CompareTag("Player"))
        {
            manager.playerDetected = collider.gameObject.GetComponent<PlayerStaticVariable>();
            head.transform.LookAt(manager.playerDetected.transform);
            transform.LookAt(manager.playerDetected.transform);
        }*/
    }

    public override void UpdateState(EnemyBaseStateMachine manager)
    {
        if (manager.playerDetected)
        {
            if (delta < tiempoMaximo)
            {
                delta += Time.deltaTime;
            }
            else
            {
                manager.SwitchState(((GymbroStateManager)manager).embestida);
                delta = 0;
            }
            head.transform.LookAt(manager.playerDetected.transform);
            transform.LookAt(manager.playerDetected.transform);
            Debug.Log(delta);
        }
    }

    public override void TriggerExit(EnemyBaseStateMachine manager, Collider other)
    {
        if (manager.playerDetected.gameObject == other.gameObject)
        {
            manager.playerDetected = null;
            manager.SwitchState(manager.pasive);
        }
    }
}
