using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : SingletonPattern<InputHandler>
{
    public Player Player;

    private CommandPattern forward;
    private CommandPattern stop;
    private CommandPattern jump;


    // Use this for initialization
    void Start()
    {
        forward = new MoveForwardCommand();
        stop = new StopCommand();
        jump = new JumpCommand();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            forward.Execute(Player);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            stop.Execute(Player);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump.Execute(Player);
        }
    }
}
