using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBall : MonoBehaviour
{
    public GameObject ballToClone;  // Reference to the object that will be cloned
    public Vector3 spawnPosition = new Vector3(0, 1.6f, -0.25f);  // Position to spawn the clone
    public Vector3 initialVelocity = new Vector3(-7, -2, 0);  // Initial velocity for the clone
    public float createBallDelay = 1f;

    private bool goCreateBall = false;
    private float delayTimer = 0;

    void Start() 
    {
        createBall();
    }

    void Update() 
    {
        if(goCreateBall) 
        {
            delayTimer -= Time.deltaTime;
            if(delayTimer <= 0f) 
            {
                // Instantiate (clone) the object at the specified spawn position and default rotation
                GameObject ball = Instantiate(ballToClone, spawnPosition, Quaternion.identity);

                // Check if the cloned object has a Rigidbody, if not add one
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    // Add a Rigidbody component if the object doesn't have one
                    rb = ball.AddComponent<Rigidbody>();
                }

                // Apply the initial velocity to the Rigidbody
                rb.velocity = initialVelocity;

                goCreateBall = false;
            }
        }
    }

    public void createBall() {
        goCreateBall = true;
        delayTimer = createBallDelay;
    }
}
