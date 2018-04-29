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
        t = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        t.Translate(Vector3.left * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            --collision.gameObject.GetComponent<Player>().health;
        }
    }
}
