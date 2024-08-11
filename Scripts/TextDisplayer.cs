using System.Threading.Tasks;
using Godot;

public class TextDisplayer
{
    public Label label;
    public Label dialogLabel;
    public GameManager gameManager;

    public TextDisplayer()
    {
        gameManager = GameManager.Instance;
    }

    public void ShowTextAsync(string text, Vector2 fromPosition, Vector2 toPosition, Node2D parent, float duration, float velocity)
    {
        label = new Label();
        label.ZIndex = 2;
        SetLabelSettings(label, "#fff");
        Vector2 newPosition = new Vector2(fromPosition.X, fromPosition.Y - 50);
        label.Text = text;
        label.Position = newPosition;
        parent.GetParent().CallDeferred("add_child", label);
    }

    private static void SetLabelSettings(Label label, string hex)
    {
        LabelSettings labelSettings = new LabelSettings();
        labelSettings.Font = ResourceLoader.Load<Font>("res://Assets/Fonts/ONESIZE_.TTF");
        labelSettings.FontColor = new Color(hex);
        labelSettings.FontSize = 16;
        label.LabelSettings = labelSettings;
    }

    public async void ShowDialogBox(string text, Node2D parent)
    {
        dialogLabel = new Label(){ 
            CustomMinimumSize = new Vector2(1024, 30),
            VerticalAlignment = (VerticalAlignment) 1,
            HorizontalAlignment = (HorizontalAlignment) 1,
        };

        dialogLabel.ZIndex = 2;
        SetLabelSettings(dialogLabel, "#000");
        dialogLabel.Position = new Vector2(50, 20);
        parent.GetParent().CallDeferred("add_child", dialogLabel);
        await DisplayDialogBox(text, parent, dialogLabel);
        dialogLabel.QueueFree();
        GameManager.ChangeVisibilityDialogBox();
    }

    public async Task DisplayDialogBox(string text, Node2D parent, Label label)
    {
        string currentText = "";
        int currentChar = 0;

        while (currentChar < text.Length)
        {
            currentText += text[currentChar];
            dialogLabel.Text = currentText;
            currentChar++;
            await parent.ToSignal(parent.GetTree().CreateTimer(0.05f), "timeout");
        }

        await parent.ToSignal(parent.GetTree().CreateTimer(2), "timeout");
    }

    public void HideText()
    {
        label.QueueFree();
    }

}
