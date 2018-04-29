using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public int ammo = 0;
    public int slashes = 0;
    public bool slashing = false;

    //public GroundMover GroundMover;
    public Vector2 JumpForce;
    public Transform Parent;
    public GameObject Bullet;
    public GameObject BulletSpawner;

    public delegate void KillPlayer();
    public event KillPlayer OnPlayerKilled;

    public delegate void Win();
    public event Win OnWin;

    private Rigidbody2D rb2D;
    private bool jumping = false;

    // Use this for initialization
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            //DIE
            if (OnPlayerKilled != null)
            {
                OnPlayerKilled();
            }
            Debug.Log("You die!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jumping)
        {
            Debug.Log("Touched floor, reset jumping");
            jumping = false;
        }
    }

    public void BossKilled()
    {
        Debug.Log("Congratulations, you win!");
        if (OnWin != null)
        {
            OnWin();
        }
    }

    public void Jump()
    {
        if (!jumping)
        {
            jumping = true;
            rb2D.AddForce(JumpForce, ForceMode2D.Impulse);
        }
    }

    public void Shoot()
    {
        if (ammo > 0)
        {            
            --ammo;
            Instantiate(Bullet, BulletSpawner.transform.position, Quaternion.identity, Parent);
        }
    }

    public void Slash()
    {
        if (slashes > 0 && !slashing)
        {
            --slashes;
            slashing = true;
        }
    }
}
