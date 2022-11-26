using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public bool tutoComplete=false;
    public PlayerStaticVariable produc;
    public recibir3 key;
    void Start()
    {
        produc = GameObject.Find("Cart Controller").GetComponent<PlayerStaticVariable>();
        key = GameObject.Find("Auto").GetComponent<recibir3>();
    }

    // Update is called once per frame
    void Update()
    {
        Complete();
    }
    void Complete()
    {
        if(key.tutokey == 3 )
        {
            if(produc.Equipment==true)
            {
                tutoComplete = true;
            }
        }
    }
    public void loadOptions()
    {
        SceneManager.LoadScene("Zona de Pruebas");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gate") && tutoComplete)
        {
            loadOptions();
        }
    }

}
