using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour 
{
	public Transform groundPlane;
	[Range(0.1f,1f)]
	public float moveTime = 1f;

	void Start()
	{
		StartCoroutine (ScrollWorldRoutine(Vector3.left));
	}

	IEnumerator ScrollWorldRoutine(Vector3 dir)
	{
		while (true) 
		{
			groundPlane.position += dir;
			yield return null;
			//yield return new WaitForSeconds (moveTime);
		}
	}
}
