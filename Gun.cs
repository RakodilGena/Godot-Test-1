using System;
using Godot;

namespace GettingStartedWithGodot4;

public partial class Gun : Area2D
{
    private static readonly PackedScene BilletScene = GD.Load<PackedScene>("res://bullet.tscn");

    private Marker2D _shootingPoint = null!;

    private bool _lockedOnEnemy;

    public override void _Ready()
    {
        _shootingPoint = GetNode<Marker2D>("%ShootingPoint");
    }

    public override void _PhysicsProcess(double delta)
    {
        var enemiesInRange = GetOverlappingBodies();

        if (enemiesInRange.Count > 0)
        {
            var target = enemiesInRange[0];
            LookAt(target.GlobalPosition);
            _lockedOnEnemy = true;
        }
        else
        {
            _lockedOnEnemy = false;
        }
    }

    private void OnTimerTimeout()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (_lockedOnEnemy is false)
            return;

        if (BilletScene.Instantiate() is not Bullet bullet)
            throw new NullReferenceException("bullet is null");

        Console.WriteLine("shooting!");

        bullet.GlobalPosition = _shootingPoint.GlobalPosition;
        bullet.GlobalRotation = _shootingPoint.GlobalRotation;
        _shootingPoint.AddChild(bullet);
    }
}