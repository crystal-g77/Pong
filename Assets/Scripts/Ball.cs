using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;
    private Vector3 lastVelocity;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Store the current velocity before any physics updates
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall")) 
        {
            Debug.Log("Ball collided with: " + collision.gameObject.name);

            // Reflect only in the X and Y directions
            Vector3 reflectDirection = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);

            // Keep the Z component the same
            reflectDirection.z = lastVelocity.z;

            // Set the new velocity while maintaining the speed
            rb.velocity = reflectDirection.normalized * speed;

            // If there is a double bounce...
            lastVelocity = rb.velocity;      
        }
    }

    public void setSpeed(float s)
    {
        speed = s;
    }
}
