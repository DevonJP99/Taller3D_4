using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recibir2 : MonoBehaviour
{
    PlayerStaticVariable compras;
    public string Name;
    private void Awake()
    {
        compras = GameObject.Find(Name).GetComponent<PlayerStaticVariable>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Name))
        {
            compras.compras = 0;
            MejorasStatic.coins = MejorasStatic.coins + compras.puntoMembresia;

            compras.puntoMembresia = 0;
        }
    }
}
