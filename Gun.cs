using Godot;

namespace GettingStartedWithGodot4;

public partial class Gun : Area2D
{
    public override void _PhysicsProcess(double delta)
    {
        var enemiesInRange = GetOverlappingBodies();

        if (enemiesInRange.Count > 0)
        {
            var target = enemiesInRange[0];
            LookAt(target.GlobalPosition);
        }
    }
}