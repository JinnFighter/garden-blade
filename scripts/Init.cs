using Gardenblade.scripts.containers;
using Gardenblade.scripts.gameplay.player;
using Godot;
using Leopotam.Ecs;

namespace Gardenblade.scripts;

public partial class Init : Node3D
{
    [Export] private LevelDataContainer _levelDataContainer;
    [Export] private PrefabsContainer _prefabsContainer;
    private EcsSystems _systems;

    private EcsWorld _world;

    // Called when the node enters the scene tree for the first time.

    public override void _EnterTree()
    {
        CreateServices();
    }

    public override void _Ready()
    {
        InitServices();
        GD.Print("READY");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        _systems?.Run();
    }

    private void CreateServices()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
    }

    public override void _ExitTree()
    {
        DestroyServices();
    }

    private void InitServices()
    {
        _systems
            //Add init systems here:
            .Add(new CreatePlayerSystem())
            //Inject services here:
            .Inject(_prefabsContainer)
            .Inject(_levelDataContainer)
            .Init();
    }

    private void DestroyServices()
    {
        _systems?.Destroy();
        _systems = null;

        _world?.Destroy();
        _world = null;
    }
}