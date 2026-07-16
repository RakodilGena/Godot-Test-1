using System;
using Godot;

namespace GettingStartedWithGodot4;

public partial class Gun : Area2D
{
    private static readonly PackedScene BilletScene = GD.Load<PackedScene>("res://bullet.tscn");

    private Marker2D _shootingPoint = null!;
    private Area2D _aimingRange = null!;

    private bool _lockedOnEnemy;

    public override void _Ready()
    {
        _shootingPoint = GetNode<Marker2D>("%ShootingPoint");
        _aimingRange = GetNode<Area2D>("%AimingRange");
    }

    public override void _PhysicsProcess(double delta)
    {
        var enemiesInAimingRange = _aimingRange.GetOverlappingBodies();

        if (enemiesInAimingRange.Count > 0)
        {
            var target = enemiesInAimingRange[0];
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
        if (!_lockedOnEnemy)
            return;

        //check if theres someone in FIRING, not in AIMING range. 
        if (!HasOverlappingBodies())
            return;

        if (BilletScene.Instantiate() is not Bullet bullet)
            throw new NullReferenceException("bullet is null");

        bullet.GlobalPosition = _shootingPoint.GlobalPosition;
        bullet.GlobalRotation = _shootingPoint.GlobalRotation;
        _shootingPoint.AddChild(bullet);
    }
}