using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimals : MonoBehaviour
{
    public float moveSpeed = 3f; 
    public float moveDistance = 5f; 

    private bool movingForward = true;

    private Vector3 initialPosition;


    void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        float newPosition = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        transform.position = initialPosition + Vector3.forward * newPosition;
    }

    //void Update()
    //{
    //    if (movingForward)
    //        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    //    else
    //        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    //    if (Mathf.Abs(transform.position.z) >= moveDistance)
    //    {
    //        movingForward = !movingForward;
    //    }
    //}
}
