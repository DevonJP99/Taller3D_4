using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoRend : MonoBehaviour
{
    public PlayerStaticVariable player;

    public GameObject sprite1;
    public GameObject sprite2;
    public GameObject sprite3;

    private void Start()
    {
        player = GameObject.Find("Cart Controller").GetComponent<PlayerStaticVariable>();
    }

    public void Update()
    {
        Tamaño();
    }

    private void Tamaño()
    {
        if(0 < player.compras)
            {
            sprite1.SetActive(false);
            sprite2.SetActive(true);
            }
        else if (player.compras == 50)
             {
            sprite2.SetActive(false);
            sprite3.SetActive(true);
             }
        else if (player.compras == 0)
             {
            sprite1.SetActive(true);
            sprite2.SetActive(false);
            sprite3.SetActive(false);
             }
    }
}
