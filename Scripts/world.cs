using Godot;
using System;

public partial class world : Node2D
{
	private CustomSignals _customSignals;
	public int Score;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Score = 0;
	}

	private void ScoreUpdate(int Score)
	{
		Score += 1;
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
