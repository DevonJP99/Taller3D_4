using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprasAceleracion : MonoBehaviour
{
    public float timer = 60f;
    TankController velocity;

    PlayerStaticVariable compras;

    private void Awake()
    {
        velocity = GameObject.Find("Carrito").GetComponent<TankController>();

        compras = GameObject.Find("Carrito").GetComponent<PlayerStaticVariable>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && compras.compras >= 10)
        {
            timer -= Time.deltaTime;
            velocity.movementSpeed = 20;

            if(timer == 0)
            {
                velocity.movementSpeed = 10;
            }
        }
    }
}
