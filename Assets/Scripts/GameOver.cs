using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TMP_Text msgText;

    public void show(string msg) {
        msgText.text = msg;
        gameObject.SetActive(true);
    }  

    public void hide() {
        gameObject.SetActive(false);
    }  
}
