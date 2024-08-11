using Godot;

public class MoveRightCommand : IPlayerCommand<Player>
{
    public void Execute(Player player, double delta)
    {
        player.Position = new Vector2(player.Position.X + 3, player.Position.Y);
        player.animatedSprite.FlipH = false;
        player.ChangeAnimation("horizontal_walk");
    }
}
