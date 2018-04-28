using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GroundMover GroundMover;
    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void MoveForward()
    {
        GroundMover.StartMoving();
    }

    public void Stop()
    {
        GroundMover.StopMoving();
    }
}
