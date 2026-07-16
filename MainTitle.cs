using Godot;

namespace GettingStartedWithGodot4;

public partial class MainTitle : Node2D
{
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("escape"))
        {
            Core.ExitGame(this);
        }
    }

    private void OnPlayButtonClicked()
    {
        Core.SwitchToGameScene(this);
    }

    private void OnExitButtonClicked()
    {
        Core.ExitGame(this);
    }
}