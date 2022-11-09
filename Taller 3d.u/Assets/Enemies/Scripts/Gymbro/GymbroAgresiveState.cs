using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymbroAgresiveState : GymbroBaseState
{
    public Transform head;
    float tiempoMaximo = 3;
    float delta = 0;

    public override void CollisionEnter(GymbroStateManager manager, Collision collision)
    {

    }

    public override void EnterState(GymbroStateManager manager)
    {
        //delta = 0;
        //_manager = manager;
        //atacando = false;
    }

    public override void TriggerEnter(GymbroStateManager manager, Collider collider)
    {
        //if (collider.gameObject.CompareTag("Player") && !atacando)
        /*if (collider.gameObject.CompareTag("Player"))
        {
            manager.playerDetected = collider.gameObject.GetComponent<PlayerStaticVariable>();
            head.transform.LookAt(manager.playerDetected.transform);
            transform.LookAt(manager.playerDetected.transform);
        }*/
    }

    public override void UpdateState(GymbroStateManager manager)
    {
        if (manager.playerDetected)
        {
            if (delta < tiempoMaximo)
            {
                delta += Time.deltaTime;
            }
            else
            {
                manager.SwitchState(manager.embestida);
                delta = 0;
            }
            head.transform.LookAt(manager.playerDetected.transform);
            transform.LookAt(manager.playerDetected.transform);
            Debug.Log(delta);
        }
    }

    public override void TriggerExit(GymbroStateManager manager, Collider other)
    {
        if (manager.playerDetected.gameObject == other.gameObject)
        {
            manager.playerDetected = null;
            manager.SwitchState(manager.pasive);
        }
    }
}
