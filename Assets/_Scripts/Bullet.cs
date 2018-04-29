using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int moveForce = 3;
    public int damage = 2;
    private Transform t;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<RectTransform>();
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
		t.Translate(Vector3.left * moveForce,Space.Self);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.CompareTag ("Player")) 
		{
			return;
		}
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss>().health -= damage;
        }

        Destroy(gameObject);
    }
}
