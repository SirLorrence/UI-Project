using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class ButtonPress : MonoBehaviour
{
 public Text buttonText;

    public GameObject BananaObject;
    // Start is called before the first frame update
    void Start() => buttonText.enabled = false;
    private void OnTriggerStay(Collider other)
    {
        buttonText.enabled = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
            BananaObject.GetComponent<MeshRenderer>().enabled = false;
            BananaObject.GetComponentInChildren<ParticleSystem>().Play();
        }
    }
    private void OnTriggerExit(Collider other) => buttonText.enabled = false;
}
