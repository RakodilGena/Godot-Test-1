using Godot;

namespace GettingStartedWithGodot4;

public partial class AnimatedTree : StaticBody2D
{
	private AnimatedSprite2D _sprite = null!;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sprite =  GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
		if (GD.RandRange(0, 1) is 0)
			_sprite.FlipH = true;
		
		_sprite.Play("idle");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}