using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardCommand : CommandPattern
{
    public override void Execute(Player player)
    {
        player.MoveForward();
        Debug.Log("Moving Forward");
    }
}

public class StopCommand : CommandPattern
{
    public override void Execute(Player player)
    {
        player.Stop();
        Debug.Log("Stop moving");
    }
}