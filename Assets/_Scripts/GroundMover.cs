﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour 
{
	public float speed = 3f;
	void Update()
	{
		transform.Translate(Vector3.left * Time.deltaTime * speed,Space.Self);
	}
}
