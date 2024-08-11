using Godot;

public abstract partial class InteractableItem : Area2D
{
	[Export] public string dialogText = string.Empty;
	protected TextDisplayer textDisplayer;
	protected string Text { get; set; }
	protected GameManager gameManager;

	public override void _Ready()
	{
		gameManager = GetParent().GetParent<GameManager>();
		Connect("body_entered", new Callable(this, "OnBodyEntered"));
		Connect("body_exited", new Callable(this, "OnBodyExited"));
		textDisplayer = new TextDisplayer();
	}

	public override void _Process(double delta)
	{
	}

	public virtual void OnBodyEntered(Node2D body)
	{
		if (body is Player player)
		{
			player.isOnInteractableItem = true;
			player.interactableItemText = dialogText;
		}
			
		textDisplayer.ShowTextAsync(
			Text,
			body.Position,
			new Vector2(Position.X, Position.Y - 50),
			body,
			
			0.1f, 0.1f
		);

	}

	public void OnBodyExited(Node2D body)
	{
		if (body is Player player)
		{
			player.isOnInteractableItem = false;
			player.interactableItemText = string.Empty;
		}

		textDisplayer.HideText();
	}
}
