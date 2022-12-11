using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducCaracter : MonoBehaviour
{
   
    public PlayerStaticVariable compras;
   
    public int size;
    public string Name;
    public int price;
    private int descuento;
    private int puntaje;
    private int actualPunt;
    public int a = 1;
    public bool pesado=false;
    /*public bool interactuable;
    /*public Renderer rend;
    
    public bool maldito = false;
    public int b;*/
    public int Descuento2;


    // Start is called before the first frame update
    private void Awake()
    {
        compras = GameObject.Find(Name).GetComponent<PlayerStaticVariable>();
        descuento = Descuento2* 10;
        Puntos();
        
    }
    void Start()
    {
        /*rend = GetComponent<Renderer>();*/
    }

    // Update is called once per frame
    void Update()
    {

        LimitOfers();
      

        /*if (compras.compras + size <= compras.Maxcompras && interactuable && Input.GetKeyDown(KeyCode.E) && MejorasStatic.ofertaslimitas == false)
        {
            compras.cantiProc++;
            compras.compras = compras.compras + size;
            rend.enabled = false;
            compras.puntaje = compras.puntaje + actualPunt;
            AutoDestruccion();
        }*/
        /*if (compras.compras + size <= compras.Maxcompras && interactuable && Input.GetKeyDown(KeyCode.E) && MejorasStatic.ofertaslimitas == true)
        {
            compras.compras = compras.compras + size;
            rend.enabled = false;
            compras.puntaje = compras.puntaje + actualPunt;
            compras.puntoMembresia = compras.puntoMembresia + 1;
            AutoDestruccion();
        }*/


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Name) && compras.compras + size <= compras.Maxcompras && pesado==false)
        {
            compras.cantiProc++;
            compras.compras = compras.compras + size;
            compras.puntaje = compras.puntaje + actualPunt;
            Destroy(gameObject);
        }
        else
        if (other.gameObject.CompareTag(Name) && compras.compras + size <= compras.Maxcompras && pesado==true)
        {
            compras.cantiProc++;
            compras.compras = compras.compras + size;
            compras.puntaje = compras.puntaje + actualPunt;
            Destroy(gameObject);
            MejorasStatic.pesado = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    public void Puntos()
    {
        puntaje = price + (price*(descuento)/100);
        actualPunt = puntaje;
    }
    public void LimitOfers()
    {
        if (MejorasStatic.ofertaslimitas == true )
        {
            a=2;
            actualPunt = puntaje * a;
            
            
        }
        else if(MejorasStatic.ofertaslimitas == false )
        {
            actualPunt = puntaje;
        } 
    } 
    
  
    
}
