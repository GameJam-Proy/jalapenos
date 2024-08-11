using Godot;

public partial class GameManager : Node2D
{
	public static Sprite2D dialogBox;
	public static bool isDialogBoxVisible = false;
	private static GameManager _instance;
	private int _currentScene;
	public static bool state = false; // Hacer la variable `state` estática

	private GameManager()
	{
		_currentScene = 0;
	}

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GameManager();
			}

			return _instance;
		}
	}

	public override void _Ready()
	{
		dialogBox = GetNode<Sprite2D>("DialogBox");
		dialogBox.Visible = false;
		if (state == false)
		{
			GetTree().ChangeSceneToFile("res://Scenes/Menu.tscn");	
		}
	}

	public void SetCurrentScene(int scene)
	{
		_currentScene = scene;
	}

	public int GetCurrentScene()
	{
		return _currentScene;
	}

	public static void ChangeVisibilityDialogBox()
	{
		dialogBox.Visible = !dialogBox.Visible;
	}
}
