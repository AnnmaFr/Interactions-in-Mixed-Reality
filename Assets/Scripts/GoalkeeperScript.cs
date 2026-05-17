using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperScript : MonoBehaviour
{
    private bool enteredObject = false;
    private bool selected = false;
    public GameObject head;
    public GameObject handRRep;
    public GameObject handLRep;
    public GameObject headRep;
    private bool trigger = false;
    private bool previousTrigger = false;
    public Collider goalkeeperCube;

    public OVRHand handR;
    public OVRHand handL;
    private bool isIndexFingerPinchingR;
    private bool isIndexFingerPinchingL;


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
        isIndexFingerPinchingR = handR.GetFingerIsPinching(OVRHand.HandFinger.Index);
        isIndexFingerPinchingL = handL.GetFingerIsPinching(OVRHand.HandFinger.Index);


        //Vector3 headsetPosition = InputTracking.GetLocalPosition(XRNode.Head);

        if (isIndexFingerPinchingR || isIndexFingerPinchingL)
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
            handLRep.transform.position = handL.transform.position;
            handRRep.transform.position = handR.transform.position;

            handRRep.transform.rotation = handR.transform.rotation;
            handRRep.transform.Rotate(Vector3.up, 180f);
            handLRep.transform.rotation = handL.transform.rotation;
            handLRep.transform.Rotate(Vector3.up, 180f);
            handRRep.transform.Rotate(Vector3.right, 180f);

            handR.GetComponent<SkinnedMeshRenderer>().enabled = false; 
            handL.GetComponent<SkinnedMeshRenderer>().enabled = false;
            handR.GetComponent<OVRMeshRenderer>().enabled = false;
            handL.GetComponent<OVRMeshRenderer>().enabled = false;



            //if (gameObject.GetComponent<Collider>() == goalkeeperCube)
            //{
            //    handRRep.transform.Rotate(Vector3.right, f);
            //    handLRep.transform.Rotate(Vector3.right, 270f);
            //}

            //headRep.transform.SetParent(head.gameObject.transform);
            //handLRep.transform.SetParent(leftHand.gameObject.transform);
            //handRRep.transform.SetParent(rightHand.gameObject.transform);
        }
        else
        {

            handR.GetComponent<SkinnedMeshRenderer>().enabled = true;
            handL.GetComponent<SkinnedMeshRenderer>().enabled = true;
            handR.GetComponent<OVRMeshRenderer>().enabled = true;
            handL.GetComponent<OVRMeshRenderer>().enabled = true;
        }
        //else
        //{
        //    headRep.transform.SetParent(null);
        //    handLRep.transform.SetParent(null);
        //    handRRep.transform.SetParent(null);
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
