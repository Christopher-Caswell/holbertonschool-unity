using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    float startTime = 0f;
    bool timerStarted = true;

    public void Stop()
    {
        timerStarted = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            startTime += Time.deltaTime;
            timerText.text = $"{(int)startTime / 60}:{(startTime % 60).ToString("00.00")}";
        }
    }
}
