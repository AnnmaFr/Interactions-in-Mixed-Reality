using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HCIKonstanz.Colibri.Synchronization;

public class WheelDetectionScript : MonoBehaviour
{
    public GameMasterMemory gameMasterScript;
    public Collider controller;
    public GameObject wheel1;
    public GameObject wheel2;
    public Material woodMaterial;



    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        if (gameObject == wheel1)
            {
                gameMasterScript.wheel1entered = true;
                Sync.Send("wheel1", true);
            }

            if (gameObject == wheel2)
            {
                gameMasterScript.wheel2entered = true;
                Sync.Send("wheel2", true);
            }
    }

    void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<Renderer>().material = woodMaterial;
        if (gameObject == wheel1)
            {
                gameMasterScript.wheel1entered = false;
                Sync.Send("wheel1", false);
            }

            if (gameObject == wheel2)
            {
                gameMasterScript.wheel2entered = false;
                Sync.Send("wheel2", false);
            }
    }
}
