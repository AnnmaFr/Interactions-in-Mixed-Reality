using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiSelection : MonoBehaviour
{
    private bool selected = false;
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
    }

    void OnTriggerEnter(Collider other)
    {
        if(!selected){
            selected = !selected;
            gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
        else{
            selected = !selected;
            gameObject.GetComponent<Renderer>().material.color = new Color(128, 128, 128);
        }
                    
    }
    void OnTriggerExit(Collider other)
    {

    }
}
