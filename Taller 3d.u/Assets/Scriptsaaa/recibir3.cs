using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recibir3 : MonoBehaviour
{

    public int tutokey;

    PlayerStaticVariable compras;
    void Start()
    {
        compras = GameObject.Find("Cart Controller").GetComponent<PlayerStaticVariable>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cart Controller"))
        {
            tutokey = compras.cantiProc;
        }
    }
}
