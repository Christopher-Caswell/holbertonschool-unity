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

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(deltaY, deltaX, 0);
        transform.position = player.position + rotation * new Vector3(0, 0, -6.25f);
        transform.LookAt(player);
	}
}
