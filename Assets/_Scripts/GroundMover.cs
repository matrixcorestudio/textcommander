using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour 
{
	public Transform groundPlane;
	[Range(0.1f,1f)]
	public float moveTime = 1f;

    private bool isWorldMoving = false;

    public void StartMoving()
    {
        if (!isWorldMoving)
        {
            Debug.Log("ZA WARUDO, MOVE AGAIN");
            isWorldMoving = true;
            StartCoroutine(ScrollWorldRoutine(Vector3.left));
        }
    }

    public void StopMoving()
    {
        if (isWorldMoving)
        {
            Debug.Log("ZA WARUDO, TOKI WO TOMARE!");
            isWorldMoving = false;
            StopCoroutine(ScrollWorldRoutine(Vector3.left));
        }
    }

	IEnumerator ScrollWorldRoutine(Vector3 dir)
	{
		while (isWorldMoving)
		{
            groundPlane.position += dir;
			yield return null;
			//yield return new WaitForSeconds (moveTime);
		}
	}
}
