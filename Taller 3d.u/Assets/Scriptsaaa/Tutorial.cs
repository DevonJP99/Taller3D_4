using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
  
    public bool tutoComplete=false;
    public PlayerStaticVariable produc;
    // Start is called before the first frame update
    void Start()
    {
        produc = GameObject.Find("Cart Controller").GetComponent<PlayerStaticVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        Complete();
    }
    void Complete()
    {
        if(produc.cantiProc==3 )
        {
            if(produc.Equipment==true)
            {
                tutoComplete = true;
            }
        }
    }
    public void loadOptions()
    {
        SceneManager.LoadScene("zona de pruebas");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gate") && tutoComplete)
        {
            loadOptions();
        }
    }

}
