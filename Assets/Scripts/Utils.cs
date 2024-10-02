using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Utils
{
    public static Vector3 calculateNewPosition(Vector3 oldPosition, Vector2 moveInput, float speed, float rayDistance, Vector3 bounds)
    {
        Vector3 v3 = new Vector3(0, moveInput.y, 0) * speed * Time.deltaTime; //convert to 3d space
        Vector3 newPosition = oldPosition + v3;

        // Check for wall collisions using raycasting
        RaycastHit hit;
        if (Physics.Raycast(oldPosition, v3.normalized, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Wall")) // Check if the hit object is a wall
            {
                // Calculate the edge position based on the wall's normal
                Vector3 edgePosition = hit.point;
                edgePosition.y += hit.normal.y * bounds.y;

                // Move the paddle to the edge of the wall instead of the intended position
                newPosition = edgePosition;
            }
        }

        return newPosition;
    }

    public static float randomNumber(float lower, float upper){
        float randomValue = Random.Range(lower, upper);
        if (Random.Range(0, 2) == 0)
        {
            randomValue *= -1;
        }
        return randomValue;
    }
}
