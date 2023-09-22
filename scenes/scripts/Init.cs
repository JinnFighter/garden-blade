using Godot;
using Leopotam.Ecs;

namespace Gardenblade.scenes.scripts;

public partial class Init : Node
{
	private EcsSystems _systems;

	private EcsWorld _world;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CreateServices();
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
