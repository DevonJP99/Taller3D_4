using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
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
    public void loadMarket()
    {
        SceneManager.LoadScene("Market");
    }

    public void exit()
    {
        Application.Quit();
    }
}
