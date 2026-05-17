using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocketScritp : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody m_Rigidbody = other.GetComponent<Rigidbody>();
        Vector3 direction = gameObject.transform.position - m_Rigidbody.position;

        m_Rigidbody.AddForce(direction * 200f);
        other.gameObject.layer = LayerMask.NameToLayer("Exit Pocket");
    }

    void OnTriggerExit(Collider other)
    {
        other.gameObject.layer = LayerMask.NameToLayer("Default");
        other.GetComponent<Rigidbody>().useGravity = true;
    }
}
