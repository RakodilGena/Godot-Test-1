using GettingStartedWithGodot4.characters.slime;
using Godot;

namespace GettingStartedWithGodot4;

public partial class Mob : CharacterBody2D
{
    private static readonly PackedScene SmokeScene = GD.Load<PackedScene>("res://smoke_explosion/smoke_explosion.tscn");
    
    private int _health = 5;
    private Slime _slime = null!;
    private Player _player = null!;
    

    public override void _Ready()
    {
        _slime = GetNode<Slime>("Slime");
        _player = GetNode<Player>("/root/Game/Player");

        _slime.PlayWalk();
    }

    public override void _PhysicsProcess(double delta)
    {
        var direction = GlobalPosition.DirectionTo(_player.GlobalPosition);

        Velocity = direction * 300;

        MoveAndSlide();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        _slime.PlayHurt();

        if (_health <= 0)
        {
            QueueFree();
            
            var smoke = SmokeScene.Instantiate();
            var parent=  GetParent();
            parent.AddChild(smoke);
            (smoke as Node2D)?.GlobalPosition = GlobalPosition;
        }
    }
}