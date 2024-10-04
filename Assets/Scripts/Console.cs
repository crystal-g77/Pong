using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Console : MonoBehaviour
{
    public TMP_InputField  inputField;
    public TextMeshProUGUI outputText;
    public string helpCommand = "Available Commands: help, clear, bgcolour <hex colour>, ballspeed <int>";

    void Start()
    {
        outputText.text += ">" + helpCommand + "\n>";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            hide();
            Time.timeScale = 1;
        }
    }

    public void show() {
        gameObject.SetActive(true);
    }  

    public void hide() {
        gameObject.SetActive(false);
    }  

    public void OnCommandEntered(string command)
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Only process if Enter is pressed
        {
            processCommand(command);
            inputField.text = ""; // Clear input after submission
        }
    }

    private void processCommand(string command)
    {
        // Here you will parse the entered command and execute logic
        string[] splitCommand = command.Split(' ');
        outputText.text += "\n>" + command; // Display the entered command in the console

        if (command.ToLower() == "help")
        {
            outputText.text += "\n>" + helpCommand;
            outputText.text += "\n>";
        }
        else if (command.ToLower() == "clear")
        {
            outputText.text = "";
        }
        else if(splitCommand[0] == "bgcolour")
        {
            if(GameManager.Instance != null)
            {
                Color c;
                if(ColorUtility.TryParseHtmlString(splitCommand[1], out c))
                {
                    GameManager.Instance.setBGColour(c);                    
                    outputText.text += "\n>Background colour changed to: " + splitCommand[1];
                    outputText.text += "\n>";
                }
                else
                {
                    outputText.text += "\n>Unknown colour: " + splitCommand[1];
                    outputText.text += "\n>";
                }
            }
        }
        else if(splitCommand[0] == "ballspeed")
        {
            if(GameManager.Instance != null)
            {      
                int num;
                if (int.TryParse(splitCommand[1], out num))
                {          
                    GameManager.Instance.setBallSpeed(num);
                    outputText.text += "\n>Ball speed changed to: " + splitCommand[1];
                    outputText.text += "\n>";
                }
                else
                {
                    outputText.text += "\n>Unknown speed: " + splitCommand[1];
                    outputText.text += "\n>";
                }
            }
        }
        else
        {
            outputText.text += "\n>Unknown command: " + command;
            outputText.text += "\n>";
        }
    }
}
