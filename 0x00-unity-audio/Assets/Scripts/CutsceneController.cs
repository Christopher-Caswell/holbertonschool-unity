using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject playa;
    public GameObject CutSceneCamera;
    public GameObject Timer;
    public Animator animator;

    // Use this for initialization
    void Start()
    {
       // enable CutsceneCamera
	   CutSceneCamera = GameObject.Find("CutsceneCamera");
    }

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
