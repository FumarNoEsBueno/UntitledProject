using Godot;
using System;

public partial class Systema : Node2D
{
	Mapa mapa = new Mapa();
    EstadoSystema estado;

	public override void _Ready()
	{
        this.estado = new JugadorEnMazmorra(this);
		this.AddChild(mapa);
	}

	public override void _Process(double delta)
	{
        this.estado.comportamiento();
	}
}
