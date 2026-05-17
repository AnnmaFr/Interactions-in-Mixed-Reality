using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleSelectionScript : MonoBehaviour
{
    public Collider rightHand;
    private bool selected = false;
    private bool enteredObject = false;
    private bool previousTrigger = false;
    private bool trigger = false;
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
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.0f){
            trigger = true;
        }
        else{
            trigger = false;
        }

        if(enteredObject){
            if(trigger && !previousTrigger){
                selected = !selected;
            }
            if(selected){
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                
            }
            else{
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            } 
        }
        previousTrigger = trigger;
        
    }

    void OnTriggerEnter(Collider other)
    {
        enteredObject = true;
        if(!selected)
            gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 0);            
    }
    void OnTriggerExit(Collider other)
    {
        enteredObject = false;
        if(!selected)
            gameObject.GetComponent<Renderer>().material.color = new Color(128, 128, 128);
    }
}
