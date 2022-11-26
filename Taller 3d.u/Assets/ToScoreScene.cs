using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ToScoreScene : MonoBehaviour
{
    public string ScoreSceneName = "Score";
    public float secondsToScore = 60 * 5;

    Text hud;
    float delt = 0;
    // Start is called before the first frame update
    void Start()
    {
        hud = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        delt += Time.deltaTime;
        hud.text = "" + (int)((secondsToScore - delt)/60)  + ":" + (int)((secondsToScore - delt)%60);
        if (secondsToScore <= delt)
        {
            SceneManager.LoadScene(ScoreSceneName);
        }
    }
}
