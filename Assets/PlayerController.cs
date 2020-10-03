using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Vector3 movement;
    private Rigidbody rb;
    public float speed = 5f;
    private float walkSpeed = 5f;
    private float sprintSpeed = 10f;
    [SerializeField] private float staminaValue;
    private const float MAX_STAMINA = 10;
    private bool isGrounded;


    public float healthValue;
    private const float MAX_HEALTH = 100;
    public bool isRunning;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        staminaValue = MAX_STAMINA;
        healthValue = MAX_HEALTH;
    }

    private void Start()
    {
        UI_Manager.Instance.SetStaminaBar(MAX_STAMINA);
        UI_Manager.Instance.SetHealthBar(MAX_HEALTH);
    }


    // Update is called once per frame
    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        Jump();
        run();
        movement = (x * transform.right + y * transform.forward);
    }

    private void FixedUpdate() => rb.MovePosition(transform.position + (movement * (speed * Time.deltaTime)));

    private void LateUpdate()
    {
        UI_Manager.Instance.UpdateStaminaBar(staminaValue);
        UI_Manager.Instance.UpdateHealthBar(healthValue);
    }

    void run()
    {
        if (Input.GetKey(KeyCode.LeftShift)) SetRunning(true);
        else SetRunning(false);
        if (isRunning)
        {
            staminaValue -= (Time.deltaTime * 2);
            if (staminaValue < 0)
            {
                staminaValue = 0;
                SetRunning(false);
            }
        }
        else if (staminaValue < MAX_STAMINA) staminaValue += Time.deltaTime;
    }

    void SetRunning(bool canRun)
    {
        this.isRunning = canRun;
        speed = (canRun) ? sprintSpeed : walkSpeed;
    }


    void Jump()
    {
        Vector3 rayLenght = new Vector3(0, -2, 0);
        float hitDistance = 1.3f;
        isGrounded = (Physics.Raycast(transform.position, rayLenght, hitDistance)) ? true : false;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
}