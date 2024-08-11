using Godot;

public class InputHandler : MovementHandler<IPlayerCommand<Player>>
{
    private StopCommand _stopCommand;

    public InputHandler()
    {
        _stopCommand = new StopCommand();
    }

    public void HandleInput(Player player, double delta)
    {
        _stopCommand.Execute(player, delta);

        foreach (var command in commands)
        {
            if (Input.IsActionJustPressed(command.Key) || Input.IsActionPressed(command.Key))
            {
                command.Value.Execute(player, delta);
            }
        }
    }
}
