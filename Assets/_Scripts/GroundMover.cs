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
        else
        {
            Debug.Log("ZA WARUDO is already moving, cannot move again!");
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
        else
        {
            Debug.Log("ZA WARUDO is not moving already!");
        }
    }

	IEnumerator ScrollWorldRoutine(Vector3 dir)
	{
        Debug.Log("Starting movement routine");
		while (isWorldMoving)
		{
            Debug.Log("World is moving...");
            groundPlane.position += dir;
			yield return null;
			//yield return new WaitForSeconds (moveTime);
		}
	}
}
