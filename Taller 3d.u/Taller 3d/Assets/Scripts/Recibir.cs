using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recibir : MonoBehaviour
{
    PlayerStaticVariable compras;
    public int ComprasGuard=0;
    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        compras = GameObject.Find("Player").GetComponent<PlayerStaticVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        coins = MejorasStatic.coins;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            MejorasStatic.coins += (compras.compras + ComprasGuard) / 5;
            ComprasGuard = (compras.compras + ComprasGuard) % 5;
            compras.compras = 0;
            compras.puedesComprar = true;
        }
    }
    
        
    
}
