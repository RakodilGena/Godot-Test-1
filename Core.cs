using Godot;

namespace GettingStartedWithGodot4;

internal static class Core
{
    private static readonly PackedScene MenuScene = GD.Load<PackedScene>("res://main_title.tscn");
    private static readonly PackedScene GameScene = GD.Load<PackedScene>("res://survivors_game.tscn");

    public static void SwitchToGameScene(
        Node currentScene)
    {
        SwitchToScene(currentScene, GameScene);
    }

    public static void SwitchToMenuScene(
        Node currentScene)
    {
        SwitchToScene(currentScene, MenuScene);
    }

    private static void SwitchToScene(
        Node currentScene,
        PackedScene nextPackedScene)
    {
        currentScene.GetTree().ChangeSceneToPacked(nextPackedScene);
    }

    public static void ExitGame(Node currentScene)
    {
        currentScene.GetTree().Quit();
    }
}