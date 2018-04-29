using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : SingletonPattern<InputHandler>
{
    public Player Player;

    private CommandPattern forward;
    private CommandPattern stop;
    private CommandPattern jump;
    private CommandPattern shoot;
    private CommandPattern slash;


    // Use this for initialization
    void Start()
    {
        forward = new MoveForwardCommand();
        stop = new StopCommand();
        jump = new JumpCommand();
        shoot = new ShootCommand();
        slash = new SlashCommand();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot.Execute(Player);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            slash.Execute(Player);
        }
    }

    public void MoveForward()
    {
        forward.Execute(Player);
    }

    public void Stop()
    {
        stop.Execute(Player);
    }

    public void Jump()
    {
        jump.Execute(Player);
    }

    public void Shoot()
    {
        shoot.Execute(Player);
    }

    public void Slash()
    {
        slash.Execute(Player);
    }
}
