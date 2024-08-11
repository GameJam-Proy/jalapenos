using System.Collections.Generic;
using Godot;

public partial class DialogText : Node2D
{
    public List<string> text { get; set; }
    private float typeSpeed = 0.1f;
    private float readTime = 2;
    private string currentText;
    private int currentChar;
    private int currentMessage;
    private Label label;

    public DialogText()
    {
        text = new List<string>();
        text.Add("<Las sábanas están desgastadas y el colchón parece hundido y viejo. Es hora de reemplazarlos>");
        StartDialog(label);
    }

    public void ShowDialogBox(List<string> text, Node2D parent)
    {
        label = new Label();
        SetLabelSettings(label);
        label.Text = "";
        label.Position = new Vector2(100, 100);
        parent.GetParent().CallDeferred("add_child", label);

        StartDialog(label);
    }

    private void SetLabelSettings(Label label)
    {
        LabelSettings labelSettings = new LabelSettings();
        labelSettings.Font = ResourceLoader.Load<Font>("res://Assets/Fonts/ONESIZE_.TTF");
        labelSettings.FontColor = new Color("#FFF");
        labelSettings.FontSize = 24;
        label.LabelSettings = labelSettings;
    }

    private async void StartDialog(Label label)
    {
        currentMessage = 0;
        currentText = "";
        currentChar = 0;

        await ToSignal(GetTree().CreateTimer(typeSpeed), "timeout");


        while (currentMessage < text.Count)
        {
            while (currentChar < text[currentMessage].Length)
            {
                currentText += text[currentMessage][currentChar];
                label.Text = currentText;
                currentChar++;
                await ToSignal(GetTree().CreateTimer(typeSpeed), "timeout");
            }

            await ToSignal(GetTree().CreateTimer(readTime), "timeout");

            currentMessage++;
            currentChar = 0;
            currentText = "";
            label.Text = currentText;
        }
        StopDialog();
    }

    public void StopDialog()
    {
        QueueFree();
    }
}
