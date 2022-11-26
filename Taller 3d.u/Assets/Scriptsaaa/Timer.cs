using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timero;
    public TextMeshProUGUI timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("temporizador").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timero -= Time.deltaTime;
        timer.text = timero.ToString("f0");
        if(timero==0)
        {
            ScoreScene();
        }
    }
    public void ScoreScene()
    {
        SceneManager.LoadScene("Puntaje");
    }
}
