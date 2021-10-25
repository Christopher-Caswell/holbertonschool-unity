using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CutsceneController : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject playa;
    public GameObject CutSceneCamera;
    public GameObject Timer;
    public Animator animator;
    public AudioMixer audioMixer;
    public AudioMixer masterMixer;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        masterMixer.GetFloat("bgmVol", out float bgmVol);
        masterMixer.GetFloat("sfxVol", out float sfxVol);
        // audioMixer.SetFloat("bgmVol", PlayerPrefs.GetFloat("bgmVol", Mathf.Log10(1f) * 20f));
        // audioMixer.SetFloat("sfxVol", PlayerPrefs.GetFloat("sfxVol", Mathf.Log10(1f) * 20f));
       // enable CutsceneCamera
	   CutSceneCamera = GameObject.Find("CutsceneCamera");
       PlayerPrefs.SetFloat("bgmVol", bgmVol);
       PlayerPrefs.SetFloat("sfxVol", sfxVol);
       PlayerPrefs.Save();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
    	if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
			{
				Debug.Log("Animation done");
				Timer.gameObject.SetActive(true);
				CutSceneCamera.gameObject.SetActive(false);
				MainCamera.gameObject.SetActive(true);
				playa.GetComponent<PlayerController>().enabled = true;
			}
    }
}
