using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
 
    public Transform player;

    public Vector3 offset;

    float deltaX = 0.0f;
    float deltaY = 0.0f;
    
	void Start()
	{
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        deltaX += Input.GetAxisRaw("Mouse X");
        deltaY = Mathf.Clamp(deltaY - Input.GetAxisRaw("Mouse Y"), -30f, 60f);
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(deltaY, deltaX, 0);
        transform.position = player.position + rotation * new Vector3(0, 0, -6.25f);
        transform.LookAt(player);
	}
}
