using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public PlayerPath playerPath;
    public MeshRenderer mesh;

    void Awake()
    {
        playerPath = GetComponent<PlayerPath>();
        mesh = GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            RunMoveCommand(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            RunMoveCommand(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            RunMoveCommand(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RunMoveCommand(Vector3.right);
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CommandManager.RedoCommand();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CommandManager.UndoCommand();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RunColorCommand(Color.red);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RunColorCommand(Color.green);

        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RunColorCommand(Color.blue);
        }
    }

    public void RunMoveCommand(Vector3 dir)
    {
        ICommand command = new MoveCommand(this, dir);
        CommandManager.ExecuteCommand(command);
    }

    public void RunColorCommand(Color color)
    {
        ICommand command = new ColorCommand(this, color);
        CommandManager.ExecuteCommand(command);
    }
    
    public void Move(Vector3 dir)
    {
        Vector3 newPosition = transform.position + dir;
        transform.position = newPosition;
    }

    public void SetColor(Color color)
    {
        mesh.material.color = color;
    }
}
