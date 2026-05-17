using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class nearPositioningController : MonoBehaviour
{
    public Collider rightHand;
    public Collider leftHand;
    private bool enteredObject = false;
    private bool selected = false;
    public GameObject head;
    public GameObject handRRep;
    public GameObject handLRep;
    public GameObject headRep;
    private bool trigger = false;
    private bool previousTrigger = false;


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


        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.0f)
        {
            trigger = true;
        }
        else
        {
            trigger = false;
        }

        if (enteredObject)
        {
            if (trigger && !previousTrigger)
            {
                selected = !selected;
            }
            
        }
        if (selected)
        {
            headRep.transform.position = head.transform.position;
            handLRep.transform.position = leftHand.transform.position;
            handRRep.transform.position = rightHand.transform.position;

            handRRep.transform.rotation = rightHand.transform.rotation;
            handRRep.transform.Rotate(Vector3.up, 180f);
            handLRep.transform.rotation = leftHand.transform.rotation;
            handLRep.transform.Rotate(Vector3.up, 180f);

            //rightHand.gameObject.GetComponent<MeshRenderer>().enabled = false;
            //leftHand.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        //else
        //{

        //    rightHand.gameObject.GetComponent<MeshRenderer>().enabled = true;
        //    leftHand.gameObject.GetComponent<MeshRenderer>().enabled = true;
        //}
        previousTrigger = trigger;

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
