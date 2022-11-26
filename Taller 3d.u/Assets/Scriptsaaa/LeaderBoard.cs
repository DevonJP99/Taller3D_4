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

    List<Playerinfo> collectedstats;

    private void Start()
    {
        collectedstats = new List<Playerinfo>();
        LoadLeaderBoard();
    }
    public void SumbitButton()
    {
        //create object using values from imputfields, is done so that a name and score be moved 
        Playerinfo stats = new Playerinfo(userName.text, int.Parse(score.text));
        collectedstats.Add(stats);
        userName.text = "";
        score.text = "";
        SortStats();
    }
    void SortStats()
    {
        for(int i = collectedstats.Count-1;i>0;i++)
        {
            if(collectedstats[i].score>collectedstats[i-1].score)
            {
                Playerinfo tempinfo = collectedstats[i - 1];
                collectedstats[i - 1] = collectedstats[i];
                collectedstats[i] = tempinfo;
            }
        }
        UpdatePlayerPrefsString();
    }
    void UpdatePlayerPrefsString()
    {
        string stats = "";
        for(int i=0;i<collectedstats.Count;i++)
        {
            stats += collectedstats[i].name + ",";
            stats += collectedstats[i].score + ",";
        }
        PlayerPrefs.SetString("LeaderBoards", stats);
        UpdateLeaderBoardVisual();
    }
    void UpdateLeaderBoardVisual()
    {
        display.text = "";
        for (int i = 0; i < collectedstats.Count - 1; i++)
        {
            display.text += collectedstats[i].name + ":" + collectedstats[i].score + "/n";
        }
    }
    void LoadLeaderBoard()
    {
        string stats = PlayerPrefs.GetString("LeaderBoards", "");

        string[] stats2 = stats.Split(',');

        for(int i=0; i<stats2.Length-2;i+=2)
        {
            Playerinfo loadedinfo = new Playerinfo(stats2[i], int.Parse(stats2[i + 1]));

            collectedstats.Add(loadedinfo);
            UpdateLeaderBoardVisual();
        }
    }
    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
        display.text = "";
    }
}
