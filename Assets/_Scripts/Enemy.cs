using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int force = 1;
    private Transform t;

    // Use this for initialization
    void Start()
	{
		t = GetComponent<RectTransform> ();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<Player>();
            if (player.slashing)
            {
                player.slashing = false;
                Destroy(gameObject);
            }
            else
            {
                --player.health;
            }
        }
    }
}
