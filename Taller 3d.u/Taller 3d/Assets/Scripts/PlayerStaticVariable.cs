using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaticVariable : MonoBehaviour
{
    
    public int compras;
    public int Maxcompras;
    public bool puedesComprar=true;
    public int comprasprev=0;
    void Start()
    {
        Maxcompras = 10;
        if (MejorasStatic.mejorasDesbloqueadas[1])
        {
            Maxcompras += 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Objeto") && puedesComprar)
        {
            compras = compras + 1;
            
            
        }
        if (other.gameObject.CompareTag("Objeto") && compras >= Maxcompras)
        {
            puedesComprar = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            compras = compras - 1;
        }
    }



}
