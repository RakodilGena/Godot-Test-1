using Godot;

namespace GettingStartedWithGodot4;

public partial class Bullet : Area2D
{
    private const float
        SPEED = 1000f,
        RANGE = 1200f;

    private const int DAMAGE = 1;

    private float _traveledDistance;

    public override void _PhysicsProcess(double delta)
    {
        var direction = Vector2.Right.Rotated(Rotation);
        var traveled = SPEED * (float)delta;

        Position += direction * traveled;
        _traveledDistance += traveled;

        if (_traveledDistance > RANGE)
        {
            QueueFree();
        }
    }

    private void OnBodyEntered(PhysicsBody2D body)
    {
        QueueFree();

        if (body.HasMethod("TakeDamage"))
        {
            body.Call("TakeDamage", DAMAGE);
        }
    }
}