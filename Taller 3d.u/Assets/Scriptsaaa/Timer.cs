using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    PlayerStaticVariable player;
    public float timero;
    public TextMeshProUGUI timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("temporizador").GetComponent<TextMeshProUGUI>();
        player= GameObject.Find("Cart Controller").GetComponent<PlayerStaticVariable>();
    }

    // Update is called once per frame
    void Update()
    {
        timero -= Time.deltaTime;
        timer.text = timero.ToString("f0");
        if(timero<0)
        {
            MejorasStatic.totalP = MejorasStatic.totalP + player.cantiProc;
            MejorasStatic.puntoT = MejorasStatic.puntoT + player.puntaje;
            ScoreScene();
        }
    }
    public void ScoreScene()
    {
        SceneManager.LoadScene("Puntaje");
    }
}
