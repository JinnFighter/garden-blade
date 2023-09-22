using Godot;

namespace Gardenblade.scripts.containers;

public partial class LevelDataContainer : Node
{
    [Export] public Node3D PlayerSpawnPoint { get; private set; }
    [Export] public Node3D CharactersLayer { get; private set; }
}