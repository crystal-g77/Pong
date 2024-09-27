using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text text;
    public GameObject player1;
    public GameObject player2;

    public GameObject ballToClone;  // Reference to the object that will be cloned
    public Vector3 spawnPosition = new Vector3(0, 1.6f, -0.25f);  // Position to spawn the clone
    public float createBallDelay = 1f;

    private GameObject ball = null;
    private bool goCreateBall = false;
    private float delayTimer = 0;

    private int[] score = new int[2];

    void Start()
    {
        score[0] = 0;
        score[1] = 0;
        text.SetText(score[0] + " : " + score[1]);

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
                ball = Instantiate(ballToClone, spawnPosition, Quaternion.identity);

                // Check if the cloned object has a Rigidbody, if not add one
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    // Add a Rigidbody component if the object doesn't have one
                    rb = ball.AddComponent<Rigidbody>();
                }

                goCreateBall = false;
            }
        }
    }

    public void scorePoint(int player) 
    {
        destroyBall() ;
        Debug.Log("Player " + (player) + " Scored!");
        ++score[player-1];
        text.SetText(score[0] + " : " + score[1]);
        createBall();
    }

    public Vector3 getBallPosition()
    {
        if(ball)
        {
            return ball.transform.position;
        }
        else
        {
            return Vector3.zero;
        }
    }

    private void createBall() 
    {
        goCreateBall = true;
        delayTimer = createBallDelay;
    }

    private void destroyBall() 
    {
        if(ball)
        {
            Destroy(ball.gameObject);
            ball = null;
        }
    }
}
