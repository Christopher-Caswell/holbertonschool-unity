using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer timer;
    
    /// <summary>
    /// On trigger enter/exit calls a reference to collision with another object
    /// </summary>
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == timer.gameObject)
        {
            timer.enabled = true;
        }
    }
}
