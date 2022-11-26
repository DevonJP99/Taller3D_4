using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
  
    public bool tutoComplete;
    public PlayerStaticVariable produc;
    // Start is called before the first frame update
    void Start()
    {
        produc = GameObject.Find("CartController").GetComponent<PlayerStaticVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Complete()
    {
        if(produc.cantiProc==3 )
        {
            if(produc.Equipment==true)
            {
                
            }
        }
    }
    public void loadOptions()
    {
        SceneManager.LoadScene("zona de pruebas");
    }
}
