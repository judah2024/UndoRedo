using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCommand : ICommand
{
    private Player player;
    private Color color;
    private Color prevColor;

    public ColorCommand(Player inPlayer, Color inColor)
    {
        player = inPlayer;
        color = inColor;
        prevColor = player.mesh.material.color;
    }
    public void Execute()
    {
        player.SetColor(color);
    }

    public void Undo()
    {
        player.SetColor(prevColor);
    }
}
