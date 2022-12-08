using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    [Header("opciones")]
    public Slider brillo;
    public Toggle pantalla;
    public Slider musica;
    public Slider volumefx;
    public AudioMixer mixed;
    public AudioSource fxsource;
    public AudioClip clipsound;

    [Header("paneles")]
    public GameObject panelprincipal;
    public GameObject panelopciones;
    public GameObject panelpuntaje;
    public GameObject panelsalida;

    private void Awake()
    {
        volumefx.onValueChanged.AddListener(changevolumeFX);
        musica.onValueChanged.AddListener(changevolumeMaster);
    }
    public void openpanel(GameObject panel)
    {
        panelprincipal.SetActive(false);
        panelopciones.SetActive(false);
        panelpuntaje.SetActive(false);
        panelsalida.SetActive(false);

        panel.SetActive(true);
        playsound();
    }

    public void changevolumeMaster(float v)
    {
        mixed.SetFloat("VolMaster",v);
    }

    public void changevolumeFX(float v)
    {
        mixed.SetFloat("VolFX", v);
    }

    public void playsound()
    {
        fxsource.PlayOneShot(clipsound);
    }


    public void loadgame()
    {
        SceneManager.LoadScene("Zona de Pruebas");
    }

    public void loadcredits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void salir()
    {
        Application.Quit();
    }

    public void tuto()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
