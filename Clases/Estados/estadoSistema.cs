using Godot;
using System;

public abstract class EstadoSistema 
{
	protected Systema sistema;
	protected Mapa mapa;

	public EstadoSistema(Systema sistema, Mapa mapa){
		this.sistema = sistema;
	}

	public abstract void comportamientoTeclado(InputEvent @event); 
	public abstract void comportamientoDibujar(Node2D nodo); 
	public abstract void comportamiento(); 
}

public class JugadorEnMazmorra : EstadoSistema
{

	public JugadorEnMazmorra(Systema sistema, Mapa mapa): base(sistema, mapa){
		this.sistema = sistema;
		this.mapa = mapa;
	}

	public override void comportamientoTeclado(InputEvent @event){
		this.mapa.comportamientoTeclado(@event);
	}

	public override void comportamientoDibujar(Node2D nodo){
		this.mapa.comportamientoDibujar(nodo);
	}

	public override void comportamiento(){
		this.mapa.comportamiento();
	} 
}

public class menuPrincipal : EstadoSistema
{
	public menuPrincipal(Systema sistema, Mapa mapa): base(sistema, mapa){}

	public override void comportamientoTeclado(InputEvent @event){
	}
	public override void comportamientoDibujar(Node2D nodo){
	}
	public override void comportamiento(){
	} 
}
