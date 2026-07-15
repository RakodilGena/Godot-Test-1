using GettingStartedWithGodot4.characters.happy_boo;
using Godot;

namespace GettingStartedWithGodot4;

public partial class Player : CharacterBody2D
{
    private HappyBoo _happyBoo = null!;

    public override void _Ready()
    {
        _happyBoo = GetNode<HappyBoo>("HappyBoo");
    }

    public override void _PhysicsProcess(double delta)
    {
        var direction = Input.GetVector(
            "move_left",
            "move_right",
            "move_up",
            "move_down");

        Velocity = direction * 600;
        MoveAndSlide();

        if (Velocity.LengthSquared() > 0)
        {
            _happyBoo.PlayWalkAnimation();
        }
        else
        {
            _happyBoo.PlayIdleAnimation();
        }
    }
}