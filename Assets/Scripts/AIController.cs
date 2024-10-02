using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : PlayerController
{
    public GameManager gameManager;

    protected override void DoUpdate()
    {
        Vector3 upperBound = c.bounds.center + new Vector3(0, c.bounds.extents.y, 0);
        Vector3 lowerBound = c.bounds.center - new Vector3(0, c.bounds.extents.y, 0);
        if(gameManager.getBallPosition().y > upperBound.y)
        {
            moveInput = Vector2.up;
        }
        else if(gameManager.getBallPosition().y < lowerBound.y)
        {
            moveInput = Vector2.down;
        }
        else
        {
            moveInput = Vector2.zero;
        }
    }
}
