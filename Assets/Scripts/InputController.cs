using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : PlayerController
{

    //create private internal references
    private InputAction movement;

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

    //called when script enabled
    private void OnEnable()
    {
        if(player == 2)
        {
            
            Player2InputActions inputActions2 = new Player2InputActions(); //create new InputActions
            movement = inputActions2.Player.Movement; //get reference to movement action
        }
        else
        {
            Player1InputActions inputActions1 = new Player1InputActions(); //create new InputActions
            movement = inputActions1.Player.Movement; //get reference to movement action
        }
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
}
