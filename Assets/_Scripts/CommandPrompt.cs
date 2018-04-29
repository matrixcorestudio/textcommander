using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPrompt : MonoBehaviour 
{
	public GameObject promptPrefab;
	public GameObject gpOutputPrefab;

	public Transform cmdContent;
	public List<string> availableCommands = new List<string>();

	private static string HELP_MESSAGE = "Ayuda";
	private static string UNK_MESSAGE = "Comando no identificado";


	public void PromptEntry()
	{
		Instantiate (promptPrefab, cmdContent);
	}

	public void ExecuteCommand(string command)
	{
		switch(command)
		{
		case "help":
			PrintToCmd (HELP_MESSAGE);
			break;
		case "list":
			PrintToCmd (ListCommands());
			break;
		default:
			PrintToCmd (UNK_MESSAGE);
			break;
		}
	}

	void PrintToCmd(string message)
	{	
		GameObject go = Instantiate (gpOutputPrefab, cmdContent) as GameObject;
		go.GetComponent<GeneralPurposeOutput>().Init (message);
	}

	string ListCommands()
	{
		string message = "Comandos disponibles:\n ";
		foreach (var item in availableCommands) 
		{
			message += item+"       ";
		}
		return message;
	}
}
