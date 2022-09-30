using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void loadgame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void loadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void loadLeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void exit()
    {
        Application.Quit();
    }
}
