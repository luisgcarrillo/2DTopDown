using Godot;
using System;

public partial class CustomSignals : Node
{
	[Signal]
	public delegate void EnemyShotEventHandler();

	[Signal]
	public delegate void ScoreUpdateEventHandler(int Score);
}

