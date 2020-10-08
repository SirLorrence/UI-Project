using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Slider staminaBar;
    public Slider healthBar;

    public PostProcessProfile playerVignette;

    private static UI_Manager _instance;

    public static UI_Manager Instance
    {
        get
        {
            if (_instance == null) Debug.Log("No game manager in scene");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        DamageVignette();
    }

    #region Player Stats

    public void SetStaminaBar(float maxValue) => staminaBar.maxValue = maxValue;
    public void UpdateStaminaBar(float sprintValue) => staminaBar.value = sprintValue;
    public void SetHealthBar(float maxValue) => healthBar.maxValue = maxValue;
    public void UpdateHealthBar(float sprintValue) => healthBar.value = sprintValue;

    #endregion

    private void DamageVignette()
    {
        var temp = 1 - healthBar.value / 100;
        playerVignette.GetSetting<Vignette>().intensity.value = temp;
    }
}