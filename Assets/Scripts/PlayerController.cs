using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int player = 1;
    public float speed = 50f;
    public float rayDistance = 0.5f; // Distance to check for walls

    protected Vector2 moveInput;     // Stores movement input
    protected Rigidbody rb;

    protected Bounds combinedBounds = new Bounds();

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); //get rigidbody, responsible for enabling collision with other colliders'
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        doUpdate();
        combinedBounds = calculateBounds();
        Vector3 newPosition = Utils.calculateNewPosition(rb.position, moveInput, speed, rayDistance, combinedBounds.extents);
        rb.MovePosition(newPosition);
    }
    
    protected virtual void doUpdate() {
    }

    Bounds calculateBounds()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            bounds.Encapsulate(col.bounds);
        }
        return bounds;
    }

     void OnDrawGizmos()
    {
        if (combinedBounds.size != Vector3.zero)
        {
            // Draw the combined bounds for debugging
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(combinedBounds.center, combinedBounds.size);
        }
    }
}
