using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void loadgame()
    {
        SceneManager.LoadScene("Zona de Pruebas");
    }

    public void loadOptions()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void loadLeaderBoard()
    {
        SceneManager.LoadScene("Puntaje");
    }
    public void loadMarket()
    {
        SceneManager.LoadScene("Market");
    }

    public void loadcredits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void exit()
    {
        SceneManager.LoadScene("Salir");
      //  Application.Quit();
    }

    public void AumentarCoins()
    {
        MejorasStatic.coins = MejorasStatic.coins + 5;
    }

}
