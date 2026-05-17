using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRepresentation : MonoBehaviour
{
    public GameObject playerHead;
    public GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        playerHead.transform.SetParent(head.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
