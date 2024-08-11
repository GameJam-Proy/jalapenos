public partial class Player : Entity
{
    private InputHandler movementHandler;
    private TextDisplayer textDisplayer;
    public bool isOnInteractableItem = false;
    public string interactableItemText;

    public override void _Ready()
    {
        textDisplayer = new TextDisplayer();
        movementHandler = new InputHandler();
        movementHandler.AddCommand("left", new MoveLeftCommand());
        movementHandler.AddCommand("right", new MoveRightCommand());
        movementHandler.AddCommand("up", new MoveUpCommand());
        movementHandler.AddCommand("down", new MoveDownCommand());
        movementHandler.AddCommand("action", new InteractActionCommand());
    }

	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;
        
        movementHandler.HandleInput(this, delta);

		Velocity = velocity;
		MoveAndSlide();
	}
}
