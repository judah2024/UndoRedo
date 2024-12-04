using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Player player;
    private Vector3 dir;

    public MoveCommand(Player inPlayer, Vector3 inDir)
    {
        player = inPlayer;
        dir = inDir;
    }
    
    public void Execute()
    {
        player.Move(dir);
        player.playerPath.AddPath(player.transform.position);
    }

    public void Undo()
    {
        player.playerPath.RemovePath();
        player.Move(-dir);
    }
}
