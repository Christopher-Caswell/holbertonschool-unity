using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertY;

    public Button applyButton;
    public Button backButton;
    // public Button
    public Slider bgm;
    public static float bgmSlide = 1f;

    public Slider sfx;
    public static float sfxSlide = 1f;

    public AudioMixer mixer;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (PlayerPrefs.GetInt("InvertY") == 1)
        {
            invertY.isOn = true;
        }
        else
        {
            invertY.isOn = false;
        }
        applyButton.onClick.AddListener(Apply);
        backButton.onClick.AddListener(Back);
        bgm.value = bgmSlide;
        sfx.value = sfxSlide;
    }

    /// <summary>
    /// Goes back to Main Menu wihtout applying changes
    /// </summary>
    public void Back()
    {
        SetBGMVol(PlayerPrefs.GetFloat("BGMVolume"));
        SetSFXVol(PlayerPrefs.GetFloat("BGMVolume"));
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastScene"));
    }

    /// <summary>
    /// Applies the changes to the options then loads the Main Menu
    /// </summary>
    public void Apply()
    {
        if (invertY.isOn)
        {
            PlayerPrefs.SetInt("invertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("invertY", 0);
        }
        PlayerPrefs.SetFloat("BGMVolume", bgm.value);
        PlayerPrefs.SetFloat("BGMVolume", sfx.value);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Sets the BGM volume.
    /// </summary>
    public void SetBGMVol(float sliderValue)
    {
        bgmSlide = sliderValue;
        mixer.SetFloat("bgmVol", LinearToDecibel(sliderValue));
        PlayerPrefs.SetFloat("bgmVol", sliderValue);
    }

    /// <summary>
    /// Sets and saves the SFX volume.
    /// </summary>
    public void SetSFXVol(float sliderValue)
    {
        sfxSlide = sliderValue;
        mixer.SetFloat("sfxVol", LinearToDecibel(sliderValue));
        PlayerPrefs.SetFloat("sfxVol", sliderValue);
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
