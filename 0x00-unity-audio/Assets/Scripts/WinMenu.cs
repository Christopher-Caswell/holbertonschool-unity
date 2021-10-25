using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public string nextScene;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    public void Start()
    {
        Cursor.visible = true;
    }

    /// <summary>
    /// Main Menu button reference
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Next Level button reference
    /// </summary>
    public void Next()
    {
        SceneManager.LoadScene(nextScene);
    }
}
