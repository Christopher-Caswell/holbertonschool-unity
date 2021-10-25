using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
 
    public Transform player;

    public Vector3 offset;

    public bool isInverted;

    float deltaX = 0.0f;
    float deltaY = 0.0f;
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
	void Start()
	{
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (PlayerPrefs.GetInt("isInverted") == 1)
        {
            isInverted = true;
        }
        else
        {
            isInverted = false;
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        deltaX += Input.GetAxisRaw("Mouse X");

        if (isInverted)
        {
        deltaY = Mathf.Clamp(deltaY + Input.GetAxisRaw("Mouse Y"), -30, 60);
        }
        else
        {
        deltaY = Mathf.Clamp(deltaY - Input.GetAxisRaw("Mouse Y"), -30f, 60f);
        }
    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(deltaY, deltaX, 0);
        transform.position = player.position + rotation * new Vector3(0, 0, -6.25f);
        transform.LookAt(player);
	}
}
