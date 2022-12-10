using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FillCarrito : MonoBehaviour
{
    public float stamina;
    public float maxStamina;
    public Slider tama�o;
    public float dvValue;

    void Start()
    {
        maxStamina = stamina;
        tama�o.maxValue = maxStamina;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.U))
        {
            DecreaseTam�o();
        }
    }
    private void DecreaseTam�o()
    {
        if(stamina!=0)
        {
            stamina -= dvValue * Time.deltaTime;
        }
    }
    private void IncreaTam()
    {
        stamina += dvValue * Time.deltaTime;
    }

}
