using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPrompt : MonoBehaviour
{
    public GameObject promptPrefab;
    public GameObject gpOutputPrefab;

    public Transform cmdContent;
    private static string HELP_MESSAGE = "Ayuda";
    private static string UNK_MESSAGE = "Comando no identificado";
    private InputHandler inputHandler;
    private string lastUsed;
    private PromptLine currentLine;

    void Awake()
    {
        inputHandler = InputHandler.Instance;
    }

    void Start()
    {
        inputHandler.Player.OnPlayerKilled += (() =>
        {
            PrintToCmd("You lose!");
            GameManager.Instance.ReloadGame();
        });
        inputHandler.Player.OnWin += (() => PrintToCmd("You won!"));
    }

    public void PromptEntry()
    {
        GameObject go = Instantiate(promptPrefab, cmdContent) as GameObject;
        currentLine = go.GetComponent<PromptLine>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentLine.field.text = lastUsed;
        }
    }

    public void ExecuteCommand(string command)
    {
        switch (command.ToLower())
        {
            case "help":
                PrintToCmd(HELP_MESSAGE);
                break;
            case "list":
                PrintToCmd(ListCommands());
                break;
            case "up":
            case "jump":
                inputHandler.Jump();
                break;
            case "slash":
                inputHandler.Slash();
                break;
            case "shoot":
                inputHandler.Shoot();
                break;
            case "exit":
                GameManager.Instance.ExitGame();
                break;
            default:
                PrintToCmd(UNK_MESSAGE);
                break;
        }
        lastUsed = command.ToLower();
    }

    void PrintToCmd(string message)
    {
        GameObject go = Instantiate(gpOutputPrefab, cmdContent) as GameObject;
        go.GetComponent<GeneralPurposeOutput>().Init(message);
    }

    string ListCommands()
    {
        string message = "Comandos disponibles:\n ";
        foreach (var item in GameManager.Instance.availableCommands)
        {
            message += item + "       ";
        }
        return message;
    }
}
