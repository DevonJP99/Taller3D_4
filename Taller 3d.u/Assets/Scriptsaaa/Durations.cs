using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durations : MonoBehaviour
{
    [SerializeField] TimerPRo timer1;
    public int tim;
    private void  Start()
    {
        timer1.SetDuration(tim).Begin();
    }
}
