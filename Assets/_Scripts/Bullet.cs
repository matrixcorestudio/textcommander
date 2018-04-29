using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int force = 3;
    private Transform t;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<RectTransform>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        t.Translate(Vector3.right * force);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
