using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{
	public float speed = 3f;
	public float destroyTime = 7f;
	void Start()
	{
		Destroy (this.gameObject,destroyTime);
	}
	void Update()
	{
		transform.Translate(Vector3.left * Time.deltaTime * speed,Space.Self);
	}
}
