using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeRemaingDisplayer : MonoBehaviour
{
    public Text TimerText;

    public Timer Timer;

    public void Update()
    {
        if (TimerText)
        {
            TimerText.text = String.Format("{0}", Timer.TimeCount);
        }
    } 
}
