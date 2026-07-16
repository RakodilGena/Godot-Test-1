namespace GettingStartedWithGodot4;

using Godot;

public partial class SoundManager : Node
{
    public static SoundManager Instance { get; private set; } = null!;

    public override void _Ready()
    {
        Instance = this;
    }

    public void PlaySoundAt(
        AudioStream stream,
        Vector2 position,
        float volumeDb = 0f)
    {
        var player = new AudioStreamPlayer2D();
        AddChild(player);
        player.Stream = stream;
        player.GlobalPosition = position;
        player.VolumeDb = volumeDb;
        player.Play();
        player.Finished += player.QueueFree;
    }
}