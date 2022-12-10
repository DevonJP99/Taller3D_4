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
    public Slider tamaño;
    public float dvValue;

    void Start()
    {
        maxStamina = stamina;
        tamaño.maxValue = maxStamina;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.U))
        {
            DecreaseTamño();
        }
    }
    private void DecreaseTamño()
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
