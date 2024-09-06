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
	public abstract void comportamientoDibujar(Node2D nodo); 
	public abstract void comportamiento(); 
}

public class EligiendoHabilidad : EstadoMazmorra
{

	public EligiendoHabilidad(Mapa mazmorra, Unidad jugador, List<Unidad> unidades): base(mazmorra, jugador, unidades){
	}

	public override void comportamiento(){
	}

	public override void comportamientoDibujar(Node2D nodo){
	}

	public override void comportamientoTeclado(InputEvent @event){
		switch(@event.AsText()){
			case "1":
				this.mazmorra.cambiarEstado(new EligiendoObjetivoTargeteado(mazmorra, jugador, unidades, 1));
			break;
		}
	} 
}

public class EligiendoObjetivoTargeteado : EstadoMazmorra
{
	private Habilidad habilidad;
	private int ancho;
	private bool casillaNorte;
	private bool casillaSur;
	private bool casillaEste;
	private bool casillaOeste;
	private Vector2I posCursor;
	private Vector2I posJugador;

	public EligiendoObjetivoTargeteado(Mapa mazmorra, Unidad jugador, List<Unidad> unidades, int idHabilidad): base(mazmorra, jugador, unidades){
		habilidad = jugador.getHabilidades()[idHabilidad - 1];
		ancho = 62;
		posJugador = this.jugador.getVector2I();
		posCursor = posJugador;
		casillaNorte = this.mazmorra.getCasillaTransitable(posJugador + new Vector2I(0,-1), this.jugador);
		casillaSur = this.mazmorra.getCasillaTransitable(posJugador + new Vector2I(0,1), this.jugador);
		casillaEste = this.mazmorra.getCasillaTransitable(posJugador + new Vector2I(1,0), this.jugador);
		casillaOeste = this.mazmorra.getCasillaTransitable(posJugador + new Vector2I(-1,0), this.jugador);
	}

	public override void comportamientoDibujar(Node2D nodo){

		if(casillaEste) nodo.DrawRect(new Rect2((posJugador.X + 1) * 64 - 32, posJugador.Y * 64 - 32, ancho, ancho), Colors.Green, false);
		if(casillaOeste) nodo.DrawRect(new Rect2((posJugador.X - 1) * 64 - 32, posJugador.Y * 64 - 32, ancho, ancho), Colors.Green, false);
		if(casillaSur) nodo.DrawRect(new Rect2(posJugador.X * 64 - 32, (posJugador.Y + 1) * 64 - 32, ancho, ancho), Colors.Green, false);
		if(casillaNorte) nodo.DrawRect(new Rect2(posJugador.X * 64 - 32, (posJugador.Y - 1) * 64 - 32, ancho, ancho), Colors.Green, false);
		if(posJugador != posCursor) nodo.DrawRect(new Rect2(posCursor.X * 64 - 32, (posCursor.Y) * 64 - 32, ancho, ancho), Colors.Green, true);
	}

	public override void comportamientoTeclado(InputEvent @event){
		switch(@event.AsText()){
			case "Escape": case "Backspace":
				this.mazmorra.cambiarEstado(new EligiendoHabilidad(mazmorra, jugador, unidades));
			break;
			case "Up":
				if(casillaNorte) posCursor = posJugador + new Vector2I(0,-1); 
			break;
			case "Down":
			   if(casillaSur) posCursor = posJugador + new Vector2I(0,1); 
			break;
			case "Left":
			   if(casillaOeste) posCursor = posJugador + new Vector2I(-1,0); 
			break;
			case "Right":
			   if(casillaEste) posCursor = posJugador + new Vector2I(1,0); 
			break;
			case "Enter":
				if(posCursor != posJugador) 
					this.mazmorra.cambiarEstado(new EjecutandoTurnoJugador(mazmorra, jugador, unidades, habilidad, posCursor));
			break;
		}
	} 

	public override void comportamiento(){
	}

}

public class EjecutandoTurnoJugador : EstadoMazmorra
{
	Habilidad habilidad;
	public EjecutandoTurnoJugador(Mapa mazmorra, Unidad jugador, List<Unidad> unidades, Habilidad habilidad, Vector2I objetivo): base(mazmorra, jugador, unidades){
		this.habilidad = habilidad;
		this.habilidad.inicializar(this.mazmorra.getAStarGrid2D(), objetivo);
	}

	public override void comportamiento(){
		if(this.habilidad.comportamiento()){
			this.mazmorra.cambiarEstado(new EligiendoHabilidad(mazmorra, jugador, unidades));
		}
	}

	public override void comportamientoDibujar(Node2D nodo){
	}

	public override void comportamientoTeclado(InputEvent @event){
	} 
}

public class TurnoSistema : EstadoMazmorra
{

	public TurnoSistema(Mapa mazmorra, Unidad jugador, List<Unidad> unidades): base(mazmorra, jugador, unidades){
	}

	public override void comportamiento(){
	}

	public override void comportamientoDibujar(Node2D nodo){
	}

	public override void comportamientoTeclado(InputEvent @event){
	} 
}
