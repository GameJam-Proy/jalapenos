using Godot;

public class StopCommand : IPlayerCommand<Player>
{
    public void Execute(Player player, double delta)
    {
        float horizontalDirection = Input.GetAxis("left", "right");
        float verticalDirection = Input.GetAxis("up", "down");

//         if (horizontalDirection == 0)
//         {
//             player.velocity.X = Mathf.MoveToward(player.Velocity.X, 0, player.Speed);
//             player.ChangeAnimation("default");
//         }
// 
//         if (verticalDirection == 0)
//         {
//             player.velocity.Y = Mathf.MoveToward(player.Velocity.Y, 0, player.Speed);
//             player.ChangeAnimation("default");
//         }

        if (horizontalDirection == 0 && verticalDirection == 0)
        {
			player.velocity.X = Mathf.MoveToward(player.Velocity.X, 0, player.Speed);
            player.velocity.Y = Mathf.MoveToward(player.Velocity.Y, 0, player.Speed);
            player.ChangeAnimation("default");
        }

    }
}
