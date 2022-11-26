using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    PlayerStaticVariable life;
    public Image barraVida;
    public float actualVida;
    public float maxVida;
    void Start()
    {
        life= GameObject.Find("Cart Controller").GetComponent<PlayerStaticVariable>();
        maxVida = life.vida;
    }

    // Update is called once per frame
    void Update()
    {
        actualVida = life.vida;
        barraVida.fillAmount = actualVida / maxVida;
    }
}
