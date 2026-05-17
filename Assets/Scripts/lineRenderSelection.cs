using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRenderSelection : MonoBehaviour
{   
    public GameObject ray;
    private Renderer rend;    
    private bool enteredObject = false;
    // Start is called before the first frame update
    void Start()
    {
        rend = ray.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {   if(!OVRPlugin.GetHandTrackingEnabled()){
            gameObject.SetActive(true);
            if(enteredObject){
                rend.enabled = true;
            }
            else{
                rend.enabled = false;
            }  
        }
        else{
            rend.enabled = false;
            gameObject.SetActive(false);
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
