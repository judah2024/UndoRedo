using System.Collections.Generic;

public static class CommandManager
{
    private static Stack<ICommand> stkUndo = new Stack<ICommand>();
    private static Stack<ICommand> stkRedo = new Stack<ICommand>();

    public static void ExecuteCommand(ICommand inCommand)
    {
        stkRedo.Clear();
        stkUndo.Push(inCommand);
        inCommand.Execute();
    }

    public static void UndoCommand()
    {
        if (stkUndo.Count > 0)
        {
            ICommand command = stkUndo.Pop();
            stkRedo.Push(command);
            command.Undo();
        }
    }

    public static void RedoCommand()
    {
        if (stkRedo.Count > 0)
        {
            ICommand command = stkRedo.Pop();
            stkUndo.Push(command);
            command.Execute();
        }
    }
}
