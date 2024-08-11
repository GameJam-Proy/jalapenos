using Godot;

public class MoveLeftCommand: IPlayerCommand<Player>
{
    public void Execute(Player player, double delta)
    {
        player.Position = new Vector2(player.Position.X - 3, player.Position.Y);
//         player.velocity.X = player.Speed * -1;
        player.animatedSprite.FlipH = true;
        player.ChangeAnimation("horizontal_walk");
    }
}
