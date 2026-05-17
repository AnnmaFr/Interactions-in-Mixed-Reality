using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPositioning : MonoBehaviour
{
    public OVRHand hand;
    private bool isIndexFingerPinching;
    private bool enteredObject = false;
    public GameObject cubePos;
    public Collider rightHand;
    public Collider colliderCubePos;
    public Material material;


    // Start is called before the first frame update
    void Start()
    {
        //hand = GetComponent<OVRHand>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        OVRInput.FixedUpdate();
        isIndexFingerPinching = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);


        if (enteredObject)
        {
            if (isIndexFingerPinching)
            {
                cubePos.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                cubePos.transform.SetParent(rightHand.gameObject.transform);
            }
            else
            {
                cubePos.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
                cubePos.transform.SetParent(null);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other == colliderCubePos)
        {
            enteredObject = true;
            cubePos.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other == colliderCubePos)
        {
            enteredObject = false;
            cubePos.GetComponent<Renderer>().material = material;

        }

    }
}
