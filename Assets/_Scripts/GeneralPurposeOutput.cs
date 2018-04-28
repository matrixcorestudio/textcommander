using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralPurposeOutput : MonoBehaviour 
{
	public Text messageText;

	public void Init(string message)
	{
		messageText.text = message;
	}
}
