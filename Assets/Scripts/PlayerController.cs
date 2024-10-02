using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int player = 1;
    public float speed = 50f;
    public float rayDistance = 0.5f; // Distance to check for walls

    protected Vector2 moveInput;     // Stores movement input

    private Rigidbody rb;
    private Collider c;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); //get rigidbody, responsible for enabling collision with other colliders'
        c = GetComponent<Collider>();
    }


    // Update is called once per frame
    void Update()
    {
        DoUpdate();
        Vector3 v3 = new Vector3(0, moveInput.y, 0) * speed * Time.deltaTime; //convert to 3d space
        Vector3 newPosition = Utils.calculateNewPosition(rb.position, moveInput, speed, rayDistance, c.bounds.extents);
        rb.MovePosition(newPosition);
    }

    protected virtual void DoStart() {
    }
    
    protected virtual void DoUpdate() {
    }
}
