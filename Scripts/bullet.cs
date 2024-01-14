using Godot;
using System;
using System.Diagnostics;

public partial class bullet : RigidBody2D
{

	private CustomSignals _customSignals;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		RigidBody2D myBullet = GetNode<RigidBody2D>("Bullet");
		//myBullet.Connect("BodyEntered", _on_body_entered);
		Timer timer = GetNode<Timer>("Timer");
		timer.Timeout += () => QueueFree();
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.

	public override void _Process(double delta)
	{
	}
	public void _on_body_entered(Node body)
	{
		if (body.IsInGroup("Enemy"))
		{
			body.QueueFree();
			QueueFree();
		}
	
	}


}


