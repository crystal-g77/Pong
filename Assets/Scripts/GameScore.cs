using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public CreateBall createBallScript;

    private int[] score = new int[2];

    void Start()
    {
        score[0] = 0;
        score[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scorePoint(int player) 
    {
        Debug.Log("Player " + (player) + " Scored!");
        ++score[player-1];
        Debug.Log(score[0] + " : " + score[1]);
        createBallScript.createBall();
    }
}
