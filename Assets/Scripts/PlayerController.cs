using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int player = 1;
    public float speed = 40f;
    public float rayDistance = 0.5f; // Distance to check for walls

    //create private internal references
    private Player1InputActions inputActions1;
    private Player2InputActions inputActions2;
    private InputAction movement;
    private Vector2 moveInput;     // Stores movement input
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //get rigidbody, responsible for enabling collision with other colliders
        inputActions1 = new Player1InputActions(); //create new InputActions
        inputActions2 = new Player2InputActions(); //create new InputActions
    }

    //called when script enabled
    private void OnEnable()
    {
        if(player == 2)
            movement = inputActions2.Player.Movement; //get reference to movement action
        else
            movement = inputActions1.Player.Movement; //get reference to movement action
        movement.Enable();
        movement.performed += OnMove;
        movement.canceled += OnMoveCanceled;
    }

    //called when script disabled
    private void OnDisable()
    {
        movement.performed -= OnMove;
        movement.canceled -= OnMoveCanceled;
        movement.Disable();
    }

    // Called when movement input is performed
    void OnMove(InputAction.CallbackContext context)
    {
        // Read Vector2 input (WASD or left stick)
        moveInput = context.ReadValue<Vector2>();
    }

    // Called when movement input is canceled (released)
    void OnMoveCanceled(InputAction.CallbackContext context)
    {
        // Reset movement input to zero when no input is provided
        moveInput = Vector2.zero;
    }

    private void Update()
    {
        Vector3 v3 = new Vector3(0, moveInput.y, 0) * speed * Time.deltaTime; //convert to 3d space
        Vector3 newPosition = Utils.calculateNewPosition(rb.position, moveInput, speed, rayDistance, GetComponent<Collider>().bounds.extents);
        rb.MovePosition(newPosition);
    }

}
