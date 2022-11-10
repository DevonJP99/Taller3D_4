using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    


    public static GameManager Instance { get; private set; }

    public int cañonAmmo = 10;

    private void Awake()
    {
        Instance = this;
       
    }

   
}
