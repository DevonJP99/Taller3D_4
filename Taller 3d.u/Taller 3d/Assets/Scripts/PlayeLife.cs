using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayeLife : MonoBehaviour
{
    static public float lifeMax = 100;
     public float currentLife;
    public Image barraDeVida;

    void Start()
    {
        currentLife = lifeMax;
    }

        void Update()
        {
            currentLife = Mathf.Clamp(currentLife, 0, lifeMax);
            //reduccion de fillamount por milisegundos (efecto visual)
            barraDeVida.fillAmount = currentLife / lifeMax;

            if (currentLife <= 0)
            {

                if (StaticVariables.invulnerability == false)
                {

                    //Invoke("ChangeScene", 0.9f);
                    Destroy(gameObject, 1f);
                }
            }

    

         }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("2");
            currentLife -= 10;  
        }
    }
}
