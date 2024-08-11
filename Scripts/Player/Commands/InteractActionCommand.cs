using Godot;

public class InteractActionCommand : IPlayerCommand<Player>
{
    private TextDisplayer textDisplayer;

    public InteractActionCommand()
    {
        textDisplayer = new TextDisplayer();
    }

    public void Execute(Player player, double delta)
    {
        if (Input.IsActionJustPressed("action") && player.isOnInteractableItem && player.interactableItemText != string.Empty)
        {
            textDisplayer.ShowDialogBox(player.interactableItemText, player.GetParent<Node2D>());
            GameManager.dialogBox.Visible = true;
        }
    }

    private bool IsCollidingWithInteractableItem(Player player)
    {
        var collisions = player.GetSlideCollisionCount();

        for (int i = 0; i < collisions; i++)
        {
            var collision = player.GetSlideCollision(i);
            if (collision.GetCollider() is InteractableItem)
                return true;
        }

        return false;
    }
}
