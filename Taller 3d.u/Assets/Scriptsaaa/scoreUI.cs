using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreUI : MonoBehaviour
{
    public TextMeshProUGUI totalP;
    public TextMeshProUGUI puntoT;
    public TextMeshProUGUI mejorP;
    void Start()
    {
        totalP = GameObject.Find("totalP").GetComponent<TextMeshProUGUI>();
        puntoT = GameObject.Find("puntoT").GetComponent<TextMeshProUGUI>();
        mejorP = GameObject.Find("mejorP").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        totalP.text = MejorasStatic.totalP.ToString();
        puntoT.text = MejorasStatic.puntoT.ToString();
        mejorP.text = MejorasStatic.mejorP.ToString();
    }
}
