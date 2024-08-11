using Godot;

public partial class Entity : CharacterBody2D
{
    [Export] public float Speed { get; set; } = 300.0f;
    [Export] public AnimatedSprite2D animatedSprite;
    public Vector2 velocity;

    public void ChangeAnimation(string animationName)
    {
        animatedSprite.Play(animationName);
    }
}
