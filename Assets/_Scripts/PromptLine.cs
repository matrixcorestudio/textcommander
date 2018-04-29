using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptLine : MonoBehaviour 
{
	[SerializeField] Text bashText;
	private CommandPrompt cmd;
	private InputField field;
	void Awake()
	{
		cmd = FindObjectOfType<CommandPrompt>();
		field = GetComponentInChildren<InputField>();
	}
	void Start()
	{
		field.Select();
		field.ActivateInputField();
	}

	public void Init(string bashText)
	{
		if (this.bashText != null) 
		{
			this.bashText.text = bashText;
		}
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
