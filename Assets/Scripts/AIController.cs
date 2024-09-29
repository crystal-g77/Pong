using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : PlayerController
{
    public GameManager gameManager;

    protected override void DoUpdate()
    {
        if(gameManager.getBallPosition().y > transform.position.y)
        {
            moveInput = Vector2.up;
        }
        else if(gameManager.getBallPosition().y < transform.position.y)
        {
            moveInput = Vector2.down;
        }
        else
        {
            moveInput = Vector2.zero;
        }
    }
}
