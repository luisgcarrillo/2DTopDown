using Godot;
using System;

public partial class Gun : Node2D
{
	[Export] PackedScene bullet_scene;
	[Export] float bullet_speed = 600f;
	[Export] float bps = 5f;
	
	 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("Shoot")){
			RigidBody2D bullet = bullet_scene.Instantiate<RigidBody2D>();
			bullet.Rotation = GlobalRotation;
			bullet.GlobalPosition = GlobalPosition;
			bullet.LinearVelocity = bullet.Transform.X * bullet_speed;
			
			GetTree().Root.AddChild(bullet);
			
		}
	}
}
