using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Collider player;
    public Timer timer;
    public Text timerText;

    public GameObject winCanvas;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer.Stop();
            timer.Win();
            timerText.fontSize = 95;
            timerText.color = Color.green;
            Time.timeScale = 0;
            winCanvas.SetActive(true);
        }
    }
}
