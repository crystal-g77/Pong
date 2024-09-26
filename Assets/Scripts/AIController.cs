using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public int player = 1;
    public float speed = 40f;
    public float rayDistance = 0.5f; // Distance to check for walls

    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //get rigidbody, responsible for enabling collision with other colliders
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
