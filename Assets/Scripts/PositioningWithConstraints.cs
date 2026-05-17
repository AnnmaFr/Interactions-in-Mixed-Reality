using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositioningWithConstraints : MonoBehaviour
{
    private bool enteredObject = false;
    public Collider rightHand;
    private float xMin = 0.0f, xMax = 1.0f;
    private float zMin = -0.5f, zMax = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        OVRInput.FixedUpdate();
        if (enteredObject)
        {
            if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0.0f){
                Vector3 controllerPos = rightHand.transform.position;
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                float xPos = Mathf.Clamp(controllerPos.x, xMin, xMax);
                float zPos = Mathf.Clamp(controllerPos.z, zMin, zMax);
                transform.position = new Vector3(xPos, transform.position.y, zPos);
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
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
        gameObject.GetComponent<Renderer>().material.color = new Color(128, 128, 128);
    }
}
