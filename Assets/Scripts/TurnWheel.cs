using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using HCIKonstanz.Colibri.Synchronization;

public class MoveWheel : MonoBehaviour
{
    public GameObject iceFloe;
    public GameObject wheel1;
    public Collider w1Collider;
    public Collider controller;
    private bool enteredObject1 = false;
    public GameObject ovrCameraRig;
    public bool move1=false;
    public bool move2 = false;


    void Update()
    {
        OVRInput.Update();
    }

    void FixedUpdate()
    {
        OVRInput.FixedUpdate();

        if (enteredObject1)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.0f)
            {
                ovrCameraRig.transform.SetParent(iceFloe.gameObject.transform);
                iceFloe.transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
                ovrCameraRig.transform.SetParent(null);
                float rotationAmount = 20f * Time.deltaTime;
                wheel1.transform.Rotate(-Vector3.right, rotationAmount);
                move1 = true;
            }
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                ovrCameraRig.transform.SetParent(iceFloe.gameObject.transform);
                iceFloe.transform.Translate(-Vector3.forward * 0.5f * Time.deltaTime);
                ovrCameraRig.transform.SetParent(null);
                float rotationAmount = 20f * Time.deltaTime;
                wheel1.transform.Rotate(Vector3.right, rotationAmount);
                move1 = true;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        enteredObject1 = true;
    }

    void OnTriggerExit(Collider other)
    {
        enteredObject1 = false;
    }
}
