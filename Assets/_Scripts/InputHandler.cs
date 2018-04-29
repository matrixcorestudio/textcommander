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

    void Start()
    {
        forward = new MoveForwardCommand();
        stop = new StopCommand();
        jump = new JumpCommand();
        shoot = new ShootCommand();
        slash = new SlashCommand();
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
