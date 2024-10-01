using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public TMP_Text scoreText;
    public GameObject player1;
    public GameObject player2;
    public GameOver gameOver;
    public Console console;

    public GameObject ballToClone;  // Reference to the object that will be cloned
    public Vector3 spawnPosition = new Vector3(0, 1.6f, -0.25f);  // Position to spawn the clone
    public float createBallDelay = 1f;
    public int maxScore = 5;
    public bool useAI = true;

    private GameObject ball = null;
    private bool goCreateBall = false;
    private float delayTimer = 0;

    private int[] score = new int[2];

    void Start()
    {
        gameOver.hide();
        console.hide();

        score[0] = 0;
        score[1] = 0;
        scoreText.SetText(score[0] + " : " + score[1]);

        bool temp;
        if(gameData.getUseAI(out temp))
        {
            useAI = temp;
        }    

        player2.GetComponent<InputController>().enabled = !useAI;
        player2.GetComponent<AIController>().enabled = useAI;

        createBall();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.C)) // Only process if Enter is pressed
        {
            console.show();
        }

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
        scoreText.SetText(score[0] + " : " + score[1]);
        if(score[0] == maxScore) 
        {
            gameOver.show("You Won!");
        }
        else if(score[1] == maxScore) 
        {
            gameOver.show("You Lost!");
        }
        else
        {
            createBall();
        }        
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
