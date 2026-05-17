using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScaling : MonoBehaviour
{
    public OVRHand handRight;
    public OVRHand handLeft;
    private bool isPinchingRight = false;
    private bool isPinchingLeft = false;

    private bool enteredObject = false;
    public GameObject cubeScale;
    public Collider colliderCubeScale;
    public Material material;

    private Vector3 initialScale;
    public float scaleFactor;


    // Start is called before the first frame update
    void Start()
    {
        initialScale = cubeScale.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        OVRInput.FixedUpdate();

        isPinchingLeft = handLeft.GetFingerIsPinching(OVRHand.HandFinger.Index);
        isPinchingRight = handRight.GetFingerIsPinching(OVRHand.HandFinger.Index);

        Vector3 leftHandPosition = handLeft.PointerPose.position;
        Vector3 rightHandPosition = handRight.PointerPose.position;

        if (enteredObject)
        {
            if (isPinchingLeft && isPinchingRight)
            {
                cubeScale.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                cubeScale.transform.localScale = initialScale * (Vector3.Distance(leftHandPosition, rightHandPosition) / scaleFactor);
            }
            else
            {
                cubeScale.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
       if(other == colliderCubeScale)
        {
            enteredObject = true;
            cubeScale.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other == colliderCubeScale)
        {
            enteredObject = false;
            cubeScale.GetComponent<Renderer>().material = material;
        }
    }
}
