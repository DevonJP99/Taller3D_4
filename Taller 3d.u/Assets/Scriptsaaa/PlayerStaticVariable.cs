using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStaticVariable : MonoBehaviour
{
    ProducCaracter producCarac;
    public int compras;
    public int Maxcompras;
    public bool puedesComprar=true;
    public int vida;
    public int puntaje;
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI Espacio;
    public TextMeshProUGUI health;
    public bool interactuable=false;
    void Start()
    {
        Maxcompras = 25;
        if (MejorasStatic.mejorasDesbloqueadas[1])
        {
            Maxcompras += 5;
        }
        textMesh = GameObject.Find("Puntos").GetComponent<TextMeshProUGUI>();
        Espacio = GameObject.Find("Espacio").GetComponent<TextMeshProUGUI>();
        health = GameObject.Find("Vida").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = puntaje.ToString();
        Espacio.text = compras.ToString();
        health.text = vida.ToString();
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

            compras = compras - 1;
        }
       
    }
}
