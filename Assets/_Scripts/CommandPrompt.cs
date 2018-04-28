using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandPrompt : MonoBehaviour 
{
	public GameObject promptPrefab;
	public Transform cmdContent;
	private InputField currentPrompt;

	public void PromptEntry()
	{
		GameObject go = Instantiate (promptPrefab, cmdContent) as GameObject;
		currentPrompt = go.GetComponentInChildren<InputField>();
		currentPrompt.Select();
		currentPrompt.ActivateInputField();
	}

	public void ExecuteCommand(string command)
	{
		Debug.Log (command);
	}
}
