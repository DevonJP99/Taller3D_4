using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducCaracter : MonoBehaviour
{
    public PlayerStaticVariable compras;
    public int size;
    public string Name;
    public int price;
    public int descuento;
    public int puntaje;
    public int actualPunt;
    public bool interactuable;
    public Renderer rend;
    public int a = 1;
    public bool maldito = false;
    public int b;
    public int MaxDescuento;
    public int MinDescuento;


    // Start is called before the first frame update
    private void Awake()
    {
        compras = GameObject.Find(Name).GetComponent<PlayerStaticVariable>();
        descuento = Random.Range(MinDescuento, MaxDescuento) * 10;
        Puntos();
        b = Random.Range(1,10);
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        LimitOfers();

        if (compras.compras + size <= compras.Maxcompras && interactuable && Input.GetKeyDown(KeyCode.E) && MejorasStatic.ofertaslimitas == false)
        {
            compras.cantiProc++;
            compras.compras = compras.compras + size;
            rend.enabled = false;
            compras.puntaje = compras.puntaje + actualPunt;
            AutoDestruccion();
        }
        if (compras.compras + size <= compras.Maxcompras && interactuable && Input.GetKeyDown(KeyCode.E) && MejorasStatic.ofertaslimitas == true)
        {
            compras.compras = compras.compras + size;
            rend.enabled = false;
            compras.puntaje = compras.puntaje + actualPunt;
            compras.puntoMembresia = compras.puntoMembresia + 1;
            AutoDestruccion();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Name))
        {
            interactuable = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Name)
        {
            interactuable = false;
        }
    }
    public void Puntos()
    {
        puntaje = price +(price* descuento)/100;
        actualPunt = puntaje;
    }
    public void LimitOfers()
    {
        if (MejorasStatic.ofertaslimitas == true && MejorasStatic.Si)
        {
            a=2;
            actualPunt = puntaje * a;
            MejorasStatic.Si = false;
            
        }
        else if(MejorasStatic.ofertaslimitas == false && MejorasStatic.Si==false)
        {
            actualPunt = puntaje;
        } 
    }

    public void ObjetoMaldito()
    {
        if(b%7 == 0)
        {
            maldito = true;
        }
    }
    public void AutoDestruccion()
    {
        Destroy(gameObject);
    }
}
