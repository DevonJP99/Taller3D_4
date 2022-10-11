using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public int vida;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            vida = vida - 5;

            if(vida == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
