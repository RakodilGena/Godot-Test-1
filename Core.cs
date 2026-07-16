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
        var nextScene = nextPackedScene.Instantiate();

        var tree = currentScene.GetTree();
        // 3. Add the new scene to the root tree
        tree.Root.AddChild(nextScene);

        // 4. Set it as the current active scene
        tree.CurrentScene = nextScene;

        // 5. Delete the old scene safely
        currentScene.QueueFree();
    }

    public static void ExitGame(Node currentScene)
    {
        currentScene.GetTree().Quit();
    }
}