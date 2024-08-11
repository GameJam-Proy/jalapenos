using Godot;

public class MoveDownCommand : IPlayerCommand<Player>
{
    public void Execute(Player player, double delta)
    {
        player.Position = new Vector2(player.Position.X, player.Position.Y + 3);
        player.ChangeAnimation("down_walk");
    }
}
