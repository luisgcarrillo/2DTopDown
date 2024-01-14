using Godot;
using System;

public partial class EnemySpawner : Node2D
{
	[Export] PackedScene enemy_scene;
	[Export] Node2D[] spawn_points;
	[Export] float SPS = 1f;
	Player player;
	

	float spawnRate;
	float time_until_spawn = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		spawnRate = 1 / SPS;
		player = (Player)GetTree().Root.GetNode("World").GetNode("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (time_until_spawn > spawnRate)
		{
			Spawn();
			time_until_spawn = 0;
		}
		else
		{
			time_until_spawn += (float)delta;
		}
	}

	private void Spawn()
	{
		if (player != null)
		{
			RandomNumberGenerator rng = new RandomNumberGenerator();
			Vector2 location = spawn_points[rng.Randi() % spawn_points.Length].GlobalPosition;
			enemy myEnemy = (enemy)enemy_scene.Instantiate();
			myEnemy.GlobalPosition = location;
			GetTree().Root.AddChild(myEnemy);
			//myEnemy.Shot += GetNode<ScoreLabel>("Control/ScoreLabel").OnEnemyShot;
		}
	}
}






