using Godot;

namespace GettingStartedWithGodot4.characters.slime;

public partial class Slime : Node2D
{
    private AnimationPlayer _animationPlayer = null!;

    public override void _Ready()
    {
        // Fetches the node by its name in the scene hierarchy
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }


    public void PlayWalk()
    {
        _animationPlayer.Play("walk");
    }

    public void PlayHurt()
    {
        _animationPlayer.Play("hurt");
        _animationPlayer.Queue("walk");
    }
}