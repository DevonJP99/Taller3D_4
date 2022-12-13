using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DavidJalbert;
public class PlayerStaticVariable : MonoBehaviour
{
    TinyCarController controll;
    ProducCaracter producCarac;
    //public GameObject weapon;
    public int cantiProc;
    public int compras;
    public int Maxcompras;
    public bool puedesComprar=true;
    public int vida;
    public int puntaje;
    public int puntajeScreen;
    public int puntoMembresia;
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI Espacio;
    /*public TextMeshProUGUI health;*/
    /*public TextMeshProUGUI puntoMembres;*/
    public int a;
    public bool Equipment;

    public bool interactuable=false;


    private void Awake()
    {
        Time.timeScale = 1f;
        MejorasStatic.puntoT = 0;
    }
    void Start()
    {

        controll = GameObject.Find("Cart Controller").GetComponent<TinyCarController>();
        textMesh = GameObject.Find("Puntos").GetComponent<TextMeshProUGUI>();
        Espacio = GameObject.Find("Espacio").GetComponent<TextMeshProUGUI>();
        /*health = GameObject.Find("Vida").GetComponent<TextMeshProUGUI>();*/
        /*puntoMembres = GameObject.Find("Membre").GetComponent<TextMeshProUGUI>();*/
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(MejorasStatic.sprint); 
        textMesh.text = puntajeScreen.ToString();
        Espacio.text = compras.ToString() + "/" + Maxcompras.ToString();
        /*health.text = vida.ToString();*/
        /*puntoMembres.text = MejorasStatic.coins.ToString();*/
      
        puntajemasalto();

    }
   /* private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Gun") && Input.GetKeyDown(KeyCode.E)
        {
            weapon.SetActive(true);
            Equipment = true;
        }
    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            weapon.SetActive(true);
            Equipment = true;
        }
    }*/
    private void OnTriggerExit(Collider other)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            compras = compras > 0 ? compras - 1 : 0;
        }

    }

    public float PercentComprasFilled()
    {
        return (float)((float)compras / (float)Maxcompras);
    }

    public void puntajemasalto()
    {
        if(MejorasStatic.mejorP < puntaje)
        {
            MejorasStatic.mejorP = puntaje;
        }
    }
    
}
