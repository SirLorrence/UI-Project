using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GameObject;

public class DamageZone : MonoBehaviour
{
    private GameObject player;
    private void Start() => player = FindWithTag("Player");
    private void OnTriggerStay(Collider other)=> player.GetComponent<PlayerController>().healthValue -= 5* Time.deltaTime;
}
