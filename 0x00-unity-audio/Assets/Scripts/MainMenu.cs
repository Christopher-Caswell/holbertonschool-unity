
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
public AudioMixer masterMixer;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    public void Start()
    {
        Cursor.visible = true;
        masterMixer.GetFloat("bgmVol", out float bgmVol);
        masterMixer.GetFloat("sfxVol", out float sfxVol);
        PlayerPrefs.SetFloat("bgmVol", bgmVol);
        PlayerPrefs.SetFloat("sfxVol", sfxVol);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Level Selection based on a string input saved in Unity UX
    /// </summary>
    public void LevelSelect(int level) 
    {
        SceneManager.LoadScene("Level" + level.ToString("00"));
    }

    /// <summary>
    /// Load the options menu
    /// </summary>
    public void Options() {
        PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Options");
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    public void Exit() {
        Debug.Log("Exited");
        Application.Quit();
    }

    private float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
        {
            dB = 20.0f * Mathf.Log10(linear);
        }
        else
        {
            dB = -144.0f;
        }

        return dB;
    }
}
