using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptLine : MonoBehaviour 
{
	CommandPrompt cmd;
	void Start()
	{
		cmd = FindObjectOfType<CommandPrompt>();
	}
	public void NewEntry(string command)
	{
		if (!string.IsNullOrEmpty (command)) 
		{
			cmd.ExecuteCommand(command);	
		}
		cmd.PromptEntry();
	}
}
