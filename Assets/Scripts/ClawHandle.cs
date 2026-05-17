using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawHandle : MonoBehaviour
{
    public GameObject clawPrefab;
    private GameObject claw;
    // Start is called before the first frame update
    void Start()
    {
        claw = Instantiate(clawPrefab, transform.position, Quaternion.identity);
        claw.transform.Rotate(0,0,-40);
        claw.transform.Translate(0.05f,0.05f,0);
        claw.transform.localScale = new Vector3(5,5,5);
        claw.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
