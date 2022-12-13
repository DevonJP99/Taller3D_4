using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerOutline : MonoBehaviour
{
    public GameObject effect;

    public void Start()
    {
        effect.GetComponent<Outline>();
    }

    public void Update()
    {
        Lima();
    }

    public void Lima()
    {
        if(MejorasStatic.ofertaslimitas == false)
        {
            effect.SetActive(false);
        }

        if(MejorasStatic.ofertaslimitas == true)
        {
            effect.SetActive(true);
        }
    }
}
