using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    private float rotationY;
    private float rotationX;
    private float minX = -60;
    private float maxX = 60;

    private Vector3 offset;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        offset = this.gameObject.transform.position - player.transform.position ;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))Cursor.lockState = CursorLockMode.Locked;
        rotationX += Input.GetAxis("Mouse Y");
        rotationY += Input.GetAxis("Mouse X");
        
        

        rotationX =Mathf.Clamp(rotationX, minX, maxX);

        
        player.transform.localEulerAngles = new Vector3(0,rotationY,0);
        this.gameObject.transform.localEulerAngles = new Vector3(-rotationX,rotationY,0);
    }

    private void LateUpdate()
    {
        this.gameObject.transform.position = player.transform.position + offset;
    }
}
