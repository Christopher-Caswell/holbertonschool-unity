using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float startTime = 0f;
    bool timerStarted = true;

    public Text winText;

    public void Stop()
    {
        timerStarted = false;        
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (timerStarted)
        {
            startTime += Time.deltaTime;
            timerText.text = $"{(int)startTime / 60}:{(startTime % 60).ToString("00.00")}";
        }
    }

    /// <summary>
    /// Win replaces the timer text with a win message.
    /// </summary>
    public void Win()
    {
        winText.text = timerText.text;
        timerText.text = "";
    }
}
