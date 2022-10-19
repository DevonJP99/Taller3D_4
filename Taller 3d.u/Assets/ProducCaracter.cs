using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducCaracter : MonoBehaviour
{
    public PlayerStaticVariable compras;
    public int size;
    public int price;
    public int descuento;
    public int puntaje;
    public bool interactuable;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (compras.compras + size <= compras.Maxcompras && interactuable && Input.GetKeyDown(KeyCode.E))
        {
            compras.compras = compras.compras + size;
            rend.enabled = false;
            compras.puntaje = compras.puntaje + puntaje;
        }
    }
    private void Awake()
    {
        compras = GameObject.Find("Player").GetComponent<PlayerStaticVariable>();
        descuento = Random.Range(1,11)*10;
        Puntos();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactuable = true;
        }
       
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactuable = false;
        }
    }
    public void Puntos()
    {
        puntaje = price +(price* descuento)/100;
    }
}
