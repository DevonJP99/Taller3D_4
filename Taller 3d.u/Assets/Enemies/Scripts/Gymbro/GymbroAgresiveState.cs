using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymbroAgresiveState : GymbroBaseState
{
    public Transform head;
    public Player playerDetected;
    GymbroStateManager _manager;
    float tiempoMaximo = 3;
    float delta = 0;
    float atackspeed = 20;

    bool atacando = false;
    public override void CollisionEnter(GymbroStateManager manager, Collision collision)
    {
        //Dañar y sacar volando al player
    }

    public override void EnterState(GymbroStateManager manager)
    {
        delta = 0;
        _manager = manager;
    }

    public override void TriggerEnter(GymbroStateManager manager, Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Player playa = collider.gameObject.GetComponent<Player>();
            playerDetected = playa;
            head.transform.LookAt(playerDetected.transform);
            transform.LookAt(playerDetected.transform);
        }
    }

    public override void UpdateState(GymbroStateManager manager)
    {
        if (playerDetected )
        {
            if (delta < tiempoMaximo)
            {
                delta += Time.deltaTime;
            }
            else
            {
                Embestir();
            }
            Debug.Log(delta);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            delta = 0;
            playerDetected = null;
            _manager.SwitchState(_manager.pasive);
        }
    }

    public void Embestir()
    {
        RaycastHit hit;
        Debug.Log(head.position);
        Debug.Log(playerDetected.tag);
        Debug.DrawRay(head.position, playerDetected.transform.position - head.position, Color.black,1000);
        if (Physics.Raycast(head.position, playerDetected.transform.position - head.position,out hit,100,3))
        {
            Debug.Log(hit.collider);
        }
        playerDetected = null;
    }
}
