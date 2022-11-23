using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerinfo
{
    public string name;
    public int score;
    public Playerinfo(string name , int score )
    {
        this.name = name;
        this.score = score;
    }
}

public class LeaderBoard : MonoBehaviour
{
    public InputField userName;
    public InputField score;
    public InputField display;

    private void Start()
    {
        
    }
    public void SumbitButton()
    {

    }
}
