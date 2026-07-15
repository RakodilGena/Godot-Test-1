using Godot;

namespace GettingStartedWithGodot4.characters.happy_boo;

public partial class HappyBoo : Node2D
{
    private AnimationPlayer _animationPlayer = null!;

    public override void _Ready()
    {
        // Fetches the node by its name in the scene hierarchy
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public void PlayIdleAnimation()
    {
        _animationPlayer.Play("idle");
    }


    public void PlayWalkAnimation()
    {
        _animationPlayer.Play("walk");
    }
}