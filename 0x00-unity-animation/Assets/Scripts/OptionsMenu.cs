using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertY;

    public Button applyButton;
    public Button backButton;
    // public Button 

    void Start()
    {
        invertY.isOn = PlayerPrefs.GetInt("invertY", 0) == 1;
        applyButton.onClick.AddListener(Apply);
        backButton.onClick.AddListener(Back);
    }

    public void ToggleInvertY()
    {
        PlayerPrefs.SetInt("invertY", invertY.isOn ? 1 : 0);
    }

    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("lastScene"));
    }

    public void Apply()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
}
