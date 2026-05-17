using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCrankScript : MonoBehaviour
{
    public GameObject handle;
    public Collider controller;
    private bool enteredObject = false;
    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
    }

    void FixedUpdate(){
        lastPosition = handle.transform.position;
        OVRInput.FixedUpdate();
        if(enteredObject){
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.0f){
                gameObject.transform.LookAt(controller.transform.position);
                gameObject.transform.RotateAround(gameObject.transform.position,Vector3.forward, Time.deltaTime * Vector3.Distance(handle.transform.position, lastPosition));
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        enteredObject = true;  
    }

    void OnTriggerExit(Collider other)
    {
        enteredObject = false;
    }
}
