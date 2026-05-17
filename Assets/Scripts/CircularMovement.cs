using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public float radius = 5f; // Adjust the radius in the Unity Editor
    public float speed = 2f; // Adjust the speed in the Unity Editor

    private Vector3 initialPosition;
    private float angle = 0f;

    void Start()
    {
        // Store the initial position for reference
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Calculate the new position based on time, radius, and speed
        float x = initialPosition.x + radius * Mathf.Cos(angle);
        float z = initialPosition.z + radius * Mathf.Sin(angle);

        // Set the new position for the GameObject
        transform.position = new Vector3(x, transform.position.y, z);

        // Increment the angle based on time and speed
        angle += speed * Time.deltaTime;

        // Ensure the angle stays within a full circle (360 degrees)
        if (angle > 360f)
        {
            angle -= 360f;
        }
    }
}
