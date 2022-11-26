using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStaticVariable : MonoBehaviour
{
    ProducCaracter producCarac;
    public GameObject weapon;
    public int cantiProc;
    public int compras;
    public int Maxcompras;
    public bool puedesComprar=true;
    public int vida;
    public int puntaje;
    public int puntoMembresia;
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI Espacio;
    public TextMeshProUGUI health;
    public TextMeshProUGUI puntoMembres;
    public int a;
    public bool Equipment;

    public bool interactuable=false;
    void Start()
    {
        Maxcompras = 25;
       
        textMesh = GameObject.Find("Puntos").GetComponent<TextMeshProUGUI>();
        Espacio = GameObject.Find("Espacio").GetComponent<TextMeshProUGUI>();
        health = GameObject.Find("Vida").GetComponent<TextMeshProUGUI>();
        puntoMembres = GameObject.Find("Membre").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = puntaje.ToString();
        Espacio.text = compras.ToString()+ "/" + Maxcompras.ToString();
        health.text = vida.ToString();
        puntoMembres.text = MejorasStatic.coins.ToString() ;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            compras = compras > 0 ? compras - 1 : 0;
        }
        if (collision.gameObject.CompareTag("Gun") && Input.GetKeyDown(KeyCode.E))
        {
            weapon.SetActive(true);
            Equipment = true;
        }

    }

    public float PercentComprasFilled()
    {
        return (float)((float)compras / (float)Maxcompras);
    }
}
