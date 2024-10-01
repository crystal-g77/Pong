using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Console : MonoBehaviour
{
    public TMP_InputField  inputField;
    public TextMeshProUGUI outputText;
    public string helpCommand = "Available Commands: help, clear";

    void Start()
    {
        outputText.text += ">" + helpCommand + "\n>";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Only process if Enter is pressed
        {
            hide();
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
            ProcessCommand(command);
            inputField.text = ""; // Clear input after submission
        }
    }

    private void ProcessCommand(string command)
    {
        // Here you will parse the entered command and execute logic
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
        else
        {
            outputText.text += "\n>Unknown command: " + command;
            outputText.text += "\n>";
        }
    }
}
