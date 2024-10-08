using Godot;
using System;

public partial class Systema : Node2D
{
	Mapa mapa;
	EstadoSistema estado;

	public override void _Ready()
	{
		this.mapa = new Mapa();
		this.estado = new JugadorEnMazmorra(this, this.mapa);
		this.AddChild(mapa);
	}

	public override void _Input(InputEvent @event)
	{
		if(!@event.IsPressed()) return;
		this.QueueRedraw();
		this.estado.comportamientoTeclado(@event);
	}

	 public override void _Draw()
	{
		this.estado.comportamientoDibujar(this);
	}

	public override void _Process(double delta)
	{
		this.estado.comportamiento();
	}
}
