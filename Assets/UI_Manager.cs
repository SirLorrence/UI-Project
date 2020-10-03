using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Slider staminaBar;
    public Slider healthBar;

    private static UI_Manager _instance;

    public static UI_Manager Instance
    {
        get
        {
            if(_instance == null) Debug.Log("No game manager in scene");
            return _instance;
        }  
    }
    private void Awake()
    {
        _instance = this;
    }  
    public void SetStaminaBar(float maxValue) => staminaBar.maxValue = maxValue;
    public void UpdateStaminaBar(float sprintValue) => staminaBar.value = sprintValue;
    public void SetHealthBar(float maxValue) => healthBar.maxValue = maxValue;
      public void UpdateHealthBar(float sprintValue) => healthBar.value = sprintValue;
    
    
}
