using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Compras : MonoBehaviour
{
    public float time;
    public float timerepeat;
    public float timer;
    public TextMeshProUGUI Ofertas;
    
    private void Start()
    {
        Ofertas = GameObject.Find("Ofertas").GetComponent<TextMeshProUGUI>();
        StartCoroutine(Sale());
    }
    private void Update()
    {
        //InvokeRepeating("ofertas", time, timerepeat);
       
    }
    private void ofertas()
    {
        MejorasStatic.ofertaslimitas = true;
        MejorasStatic.Si = true;
        Ofertas.text = "Han empezado las ofertas limitadas";       
    }

    IEnumerator Sale()
    {
        yield return new WaitForSeconds(time);
        MejorasStatic.ofertaslimitas = true;
        MejorasStatic.Si = true;
        Ofertas.text = "Han empezado las ofertas limitadas";

        yield return new WaitForSeconds(timerepeat);
        Ofertas.text = "Han terminado las ofertas limitadas ";
        MejorasStatic.ofertaslimitas = false;
        MejorasStatic.Si = false;


    }

}
