using Godot;
using System;

public abstract class EstadoSistema 
{
	protected Systema sistema;
	protected Mapa mapa;

	public EstadoSistema(Systema sistema, Mapa mapa){
		this.sistema = sistema;
	}

	public abstract void comportamiento(); 
}

public class JugadorEnMazmorra : EstadoSistema
{

	public JugadorEnMazmorra(Systema sistema, Mapa mapa): base(sistema, mapa){
		this.sistema = sistema;
		this.mapa = mapa;
	}

	public override void comportamiento(){
		this.mapa.comportamiento();
	} 
}

public class menuPrincipal : EstadoSistema
{
	public menuPrincipal(Systema sistema, Mapa mapa): base(sistema, mapa){}
	public override void comportamiento(){
	} 
}
