using System;
using UnityEngine;
using UnityEngine.UI;

public class GameLoopInfoDisplayer : MonoBehaviour
{
    public Text ScoreText;

    public GameLoop GameLoop;

    public void Update()
    {
        if (ScoreText)
        {
            ScoreText.text = String.Format("{0}", GameLoop.PlayerCurrentScore);
        }
    } 
}
