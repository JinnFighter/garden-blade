using Gardenblade.scripts.containers;
using Godot;
using Leopotam.Ecs;

namespace Gardenblade.scripts.gameplay.player;

public class CreatePlayerSystem : IEcsInitSystem
{
    private readonly LevelDataContainer _levelDataContainer = null;
    private readonly PrefabsContainer _prefabsContainer = null;

    private readonly EcsWorld _world = null;

    public void Init()
    {
        var entity = _world.NewEntity();
        ref var player = ref entity.Get<PlayerComponent>();
        var playerView = _prefabsContainer.PlayerCharacter.Instantiate<PlayerView>();
        _levelDataContainer.CharactersLayer.AddChild(playerView);
        playerView.GlobalPosition = _levelDataContainer.PlayerSpawnPoint.GlobalPosition;
        player.PlayerView = playerView;
        GD.Print("Spawned player");
    }
}