using Godot;

namespace GettingStartedWithGodot4;

public partial class SurvivorsGame : Node2D
{
    private static readonly PackedScene MobScene = GD.Load<PackedScene>("res://mob.tscn");
    private PathFollow2D _pathFollow = null!;

    public override void _Ready()
    {
        _pathFollow = GetNode<PathFollow2D>("%MobSpawnPathFollow");
    }

    private void OnMobSpawnTimerTimeout()
    {
        SpawnMob();
    }
    
    private void SpawnMob()
    {
        var mob = MobScene.Instantiate();
        
        _pathFollow.ProgressRatio = GD.Randf();
        
        (mob as Mob)?.GlobalPosition = _pathFollow.GlobalPosition;
        AddChild(mob);
    }
}