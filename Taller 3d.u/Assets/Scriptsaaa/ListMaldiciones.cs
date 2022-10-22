using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListMaldiciones : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement move;
    void Start()
    {
        move = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pereza()
    {
        move.ActualmoveSpeed = move.ActualmoveSpeed * 0.5f;

    }
    public void lujuria()
    { 
      
    }
}
