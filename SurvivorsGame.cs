using Godot;

namespace GettingStartedWithGodot4;

public partial class SurvivorsGame : Node2D
{
    private static readonly PackedScene MobScene = GD.Load<PackedScene>("res://mob.tscn");

    private PathFollow2D _pathFollow = null!;
    private CanvasLayer _gameOver = null!;
    private Timer _gameOverTimer = null!;


    public override void _Ready()
    {
        _pathFollow = GetNode<PathFollow2D>("%MobSpawnPathFollow");
        _gameOver = GetNode<CanvasLayer>("%GameOverScreen");
        _gameOverTimer = GetNode<Timer>("%GameOverTimer");
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("escape"))
        {
            Core.SwitchToMenuScene(this);
        }
    }

    public void Unpause()
    {
        if (!_gameOverTimer.IsStopped())
            return;

        var tree = GetTree();
        tree.Paused = !tree.Paused;
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

    private void OnPlayerHealthDepleted()
    {
        _gameOver.Visible = true;
        GetTree().Paused = true;

        _gameOverTimer.Start(timeSec: 4);
    }

    private void OnGameOverTimeout()
    {
        GetTree().Paused = false;
        Core.SwitchToMenuScene(this);
    }
}