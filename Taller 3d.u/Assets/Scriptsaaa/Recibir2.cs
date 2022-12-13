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
            compras.puntajeScreen = compras.puntajeScreen + compras.puntaje;
            compras.puntaje = 0;
            MejorasStatic.pesado = false;
        }
    }
}
