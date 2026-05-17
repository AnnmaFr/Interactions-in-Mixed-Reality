using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positioningWithGravity : MonoBehaviour
{
    public Collider rightHand;
    private bool enteredObject = false;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
        OVRInput.Update();
    }

    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
        if(enteredObject){
            if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.0f){
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                gameObject.transform.SetParent(rightHand.gameObject.transform);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            else{
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
                gameObject.transform.SetParent(null);
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            } 
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        enteredObject = true;
        gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 0);            
    }
    void OnTriggerExit(Collider other)
    {
        enteredObject = false;
        gameObject.GetComponent<Renderer>().material.color = new Color(211, 211, 211);
    }
}
