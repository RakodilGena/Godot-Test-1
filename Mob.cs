using GettingStartedWithGodot4.characters.slime;
using Godot;

namespace GettingStartedWithGodot4;

public partial class Mob : CharacterBody2D
{
    private static readonly PackedScene SmokeScene =
        GD.Load<PackedScene>("res://smoke_explosion/smoke_explosion.tscn");

    private static readonly AudioStream[] DamagedSounds =
    [
        GD.Load<AudioStream>("res://sounds/ouch.mp3"),
        GD.Load<AudioStream>("res://sounds/ah.mp3"),
        GD.Load<AudioStream>("res://sounds/oi.mp3"),
        GD.Load<AudioStream>("res://sounds/oioioi.mp3"),
        GD.Load<AudioStream>("res://sounds/oof.mp3"),
    ];

    private static readonly AudioStream DeadSound =
        GD.Load<AudioStream>("res://sounds/death.mp3");

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

        PlayDamagedSound();

        if (_health <= 0)
        {
            Die();
        }
    }

    private void PlayDamagedSound()
    {
        var index = GD.RandRange(0, DamagedSounds.Length - 1);
        var sound = DamagedSounds[index];

        SoundManager.PlaySoundAt(
            sound,
            GlobalPosition);
    }

    private void Die()
    {
        QueueFree();

        var smoke = SmokeScene.Instantiate();
        var parent = GetParent();
        parent.AddChild(smoke);
        (smoke as Node2D)?.GlobalPosition = GlobalPosition;

        SoundManager.PlaySoundAt(
            DeadSound,
            GlobalPosition);
    }
}