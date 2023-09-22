using Godot;

namespace Gardenblade.scripts.containers;

public partial class PrefabsContainer : Node
{
    [Export] private string _playerCharacter;

    [Export] public PackedScene PlayerCharacter { get; private set; }
}