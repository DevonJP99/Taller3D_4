using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class cerrarvideo : MonoBehaviour
{
    public VideoPlayer video;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }
    void Start()
    {

    }

    void Update()
    {
        saltarcreditos();
    }

    void CheckOver (VideoPlayer vp)
    {
       /* if(Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("Menu");
        }
        else
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene("Menu");
        }*/
        gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    void saltarcreditos()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
