using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GroundMover GroundMover;
    public Vector2 JumpForce;

    private Rigidbody2D rb2D;
    private bool jumping = false;
    private bool doubleJumping = false;

    // Use this for initialization
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jumping)
        {
            Debug.Log("Touched floor, reset jumping");
            jumping = false;
            doubleJumping = false;
        }
    }

    public void MoveForward()
    {
        GroundMover.StartMoving();
    }

    public void Stop()
    {
        GroundMover.StopMoving();
    }

    public void Jump()
    {
        if (!jumping)
        {
            jumping = true;
            rb2D.AddForce(JumpForce, ForceMode2D.Impulse);
        }
    }
}
