using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private Vector3 lastVelocity;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        //rb.velocity = rb.velocity.normalized * speed;
        Vector3 initialDirection = new Vector3(randomNumber(.45f, .75f), randomNumber(.25f, .55f), 0).normalized;
        rb.velocity = initialDirection * speed;
        Debug.Log("Ball velocity: " + rb.velocity);
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

    private float randomNumber(float lower, float upper){
        float randomValue = Random.Range(lower, upper);
        if (Random.Range(0, 2) == 0)
        {
            randomValue *= -1;
        }
        return randomValue;
    }
}
