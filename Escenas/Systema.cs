using Godot;
using System;

public partial class Systema : Node2D
{
	Mapa mapa = new Mapa();

	public override void _Ready()
	{
		this.AddChild(mapa);
	}

	public override void _Process(double delta)
	{
	}
}
