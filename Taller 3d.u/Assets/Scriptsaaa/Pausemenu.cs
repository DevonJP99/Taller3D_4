using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
     [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    public bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }
    public void Pausa()
    {
        {
        Time.timeScale = 0f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(true);
            GameIsPaused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(false);
        GameIsPaused = false;
        Cursor.visible = false;
    }
}
