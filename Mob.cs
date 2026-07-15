using GettingStartedWithGodot4.characters.slime;
using Godot;

namespace GettingStartedWithGodot4;

public partial class Mob : CharacterBody2D
{
    private Slime _slime = null!;
    private Player _player = null!;

    public override void _Ready()
    {
        _slime = GetNode<Slime>("Slime");
        _player = GetNode<Player>("/root/Game/Player");
    }

    public override void _PhysicsProcess(double delta)
    {
        var direction = GlobalPosition.DirectionTo(_player.GlobalPosition);

        Velocity = direction * 300;

        MoveAndSlide();
    }
}