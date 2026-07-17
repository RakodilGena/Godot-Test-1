using System;
using GettingStartedWithGodot4.characters.happy_boo;
using Godot;

namespace GettingStartedWithGodot4;

public partial class Player : CharacterBody2D
{
    private float _health = 100f;
    private const float DAMAGE_RATE_PER_ENEMY = 500f, MAX_HEALTH = 100f;

    private HappyBoo _happyBoo = null!;
    private Area2D _hurtBox = null!;
    private ProgressBar _healthBar = null!;


    [Signal]
    public delegate void HealthDepletedEventHandler();

    public override void _Ready()
    {
        _happyBoo = GetNode<HappyBoo>("HappyBoo");
        _hurtBox = GetNode<Area2D>("%HurtBox");
        _healthBar = GetNode<ProgressBar>("%HealthBar");
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

        var overlappingMobs = _hurtBox.GetOverlappingBodies();
        if (overlappingMobs.Count > 0)
        {
            _health -= DAMAGE_RATE_PER_ENEMY * overlappingMobs.Count * (float)delta;
            _healthBar.SetValue(_health / MAX_HEALTH * 100);

            if (_health <= 0f)
            {
                EmitSignalHealthDepleted();
            }
        }
    }
}