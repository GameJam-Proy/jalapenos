using System.Collections.Generic;

public abstract class MovementHandler<T>
{
    protected Dictionary<string, T> commands = new Dictionary<string, T>();

    public void AddCommand(string key, T command)
    {
        commands.Add(key, command);
    }
}
