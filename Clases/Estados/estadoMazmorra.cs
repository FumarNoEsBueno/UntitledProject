using Godot;
using System;
using System.Collections.Generic;

public abstract class EstadoMazmorra 
{
	protected Mapa mazmorra;
	protected Unidad jugador;
	protected List<Unidad> unidades = new List<Unidad>();

	public EstadoMazmorra(Mapa mazmorra, Unidad jugador, List<Unidad> unidades){
		this.mazmorra = mazmorra;
		this.jugador = jugador;
		this.unidades = unidades;
	}

	public abstract void comportamientoTeclado(InputEvent @event); 
	public abstract void comportamiento(); 
}

public class EligiendoHabilidad : EstadoMazmorra
{

	public EligiendoHabilidad(Mapa mazmorra, Unidad jugador, List<Unidad> unidades): base(mazmorra, jugador, unidades){
	}

	public override void comportamiento(){
	}

	public override void comportamientoTeclado(InputEvent @event){
		switch(@event.AsText()){
			case "1":
				GD.Print("Wena los k");
				this.mazmorra.cambiarEstado(new EligiendoObjetivoTargeteado(mazmorra, jugador, unidades, 1));
			break;
		}
	} 
}

public class EligiendoObjetivoTargeteado : EstadoMazmorra
{
	private int idHabilidad;

	public EligiendoObjetivoTargeteado(Mapa mazmorra, Unidad jugador, List<Unidad> unidades, int idHabilidad): base(mazmorra, jugador, unidades){
		this.idHabilidad = idHabilidad;
	}

	public override void comportamientoTeclado(InputEvent @event){
		GD.Print(@event.AsText());
		switch(@event.AsText()){
			case "Escape": case "Backspace":
				GD.Print("Regresando");
				this.mazmorra.cambiarEstado(new EligiendoHabilidad(mazmorra, jugador, unidades));
			break;
		}
	} 

	public override void comportamiento(){
	}

}

public class TurnoSistema : EstadoMazmorra
{

	public TurnoSistema(Mapa mazmorra, Unidad jugador, List<Unidad> unidades): base(mazmorra, jugador, unidades){
	}

	public override void comportamiento(){
	}

	public override void comportamientoTeclado(InputEvent @event){
	} 
}
