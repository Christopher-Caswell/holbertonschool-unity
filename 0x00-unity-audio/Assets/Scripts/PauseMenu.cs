using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public Button resumeButton;
    public Button restartButton;
    public Button quitButton;
    public Button menuButton;
    public Button optionsButton;

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    void Start()
    {
        Button resume = resumeButton.GetComponent<Button>();
        resume.onClick.AddListener(Resume);

        Button restart = restartButton.GetComponent<Button>();
        restart.onClick.AddListener(Restart);

        Button quit = quitButton.GetComponent<Button>();
        quit.onClick.AddListener(Quit);

        Button MenuButton = menuButton.GetComponent<Button>();
        MenuButton.onClick.AddListener(MainMenu);

        Button OptionsButton = optionsButton.GetComponent<Button>();
        OptionsButton.onClick.AddListener(Options);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        paused.TransitionTo(.01f);
    }

    void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        unpaused.TransitionTo(.01f);
    }

    void Restart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        unpaused.TransitionTo(.01f);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Who lives in a pineapple under the sea");
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Esponja Bob Pantalones Quadrados");
        unpaused.TransitionTo(.01f);

    }

    void Options()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Options");
        unpaused.TransitionTo(.01f);
    }

    void Quit()
    {
        PlayerPrefs.Save();
        Application.Quit();
        Debug.Log("Quit");
    }
}
