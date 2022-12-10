using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprasVisuales : MonoBehaviour
{
    /*public List<GameObject> Objetos;*/
    
    public Renderer rend;
    public int a;
    PlayerStaticVariable compras;
    // Start is called before the first frame update
    void Start()
    {
        compras= GameObject.Find("Cart Controller").GetComponent<PlayerStaticVariable>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        calCompras();
    }
    public void calCompras()
    {
        if(compras.compras>=a)
        {
            rend.enabled = true;
        }
        else if(compras.compras<=a)
        {
            rend.enabled = false;
        }
    }
}
