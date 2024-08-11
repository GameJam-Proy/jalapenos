using Godot;

public partial class GameManager : Node2D
{
    public static Sprite2D dialogBox;
    public static bool isDialogBoxVisible = false;
    private static GameManager _instance;
    private int _currentScene;

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

