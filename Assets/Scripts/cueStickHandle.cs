using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cueStickHandle : MonoBehaviour
{
    public GameObject cueStickGhost;
    public Rigidbody cueStickRigidBody;
    public Collider rightHand;
    public GameObject leftHand;
    private bool rightTrigger = false;
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
        if(rightTrigger && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) != 0.0f){ //check if right controller still holds on to cue stick
            gameObject.transform.position = rightHand.transform.position;
            if((OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) != 0.0f)){    //check if cue stick should be rotated towards left controller
                gameObject.transform.LookAt(leftHand.transform.position);
                gameObject.transform.RotateAround(transform.position, transform.right, 90);
            }
        }
        cueStickRigidBody.MovePosition(cueStickGhost.transform.position);
        cueStickRigidBody.MoveRotation(cueStickGhost.transform.rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) != 0.0f)
            rightTrigger = true;
        else
            rightTrigger = false;
    }

    void OnTriggerExit(Collider other)
    {
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) != 0.0f)
            rightTrigger = true;
        else
            rightTrigger = false;
    }
}
