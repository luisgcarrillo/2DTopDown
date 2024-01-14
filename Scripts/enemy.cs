using Godot;
using System;
using System.Diagnostics;
public partial class enemy : CharacterBody2D
{
	Player player;
	[Signal]
	public delegate void ShotEventHandler();
	
	[Export] float speed = 400f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = (Player)GetTree().Root.GetNode("World").GetNode("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (player != null)
		{
			LookAt(player.GlobalPosition);
			Vector2 direction = (player.GlobalPosition - GlobalPosition).Normalized();
			Velocity = direction * speed;
		}
		else
		{
			Velocity = Vector2.Zero;
		}
		MoveAndSlide();
	}
	
	private void _on_hitbox_body_entered(Node2D body)
{
	if(body.IsInGroup("Player")){
		body.QueueFree();
	}
	
	if(body.IsInGroup("Bullet")){
		EmitSignal(SignalName.Shot);
		QueueFree();
	}
	
}

public void GotShot(){
	EmitSignal(SignalName.Shot);
}

}


