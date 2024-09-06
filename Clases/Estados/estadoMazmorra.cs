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
	private AStarGrid2D aStar;
	private Vector2I posCursor;
	private Vector2I posJugador;
	private Godot.Collections.Array<Vector2I> path;

		
	public EligiendoObjetivoTargeteado(Mapa mazmorra, Unidad jugador, List<Unidad> unidades, int idHabilidad): base(mazmorra, jugador, unidades){
		habilidad = jugador.getHabilidades()[idHabilidad - 1];
		posJugador = this.jugador.getVector2I();
		posCursor = posJugador;
		aStar = mazmorra.getAStarGrid2D();
	}

	public override void comportamientoDibujar(Node2D nodo){
		GD.Print(path);
		if(posJugador != posCursor){
			nodo.DrawRect(new Rect2(posCursor.X * 64 - 32, (posCursor.Y) * 64 - 32, 62, 62), Colors.Green, true);
			for(int i = 0; i < path.Count - 1; i++){
				nodo.DrawLine(new Vector2(path[i].X*64, path[i].Y*64), new Vector2( path[i+1].X*64, path[i+1].Y*64),Colors.Green);
			}
		}
	}

	public override void comportamientoTeclado(InputEvent @event){
		switch(@event.AsText()){
			case "Escape": case "Backspace":
				this.mazmorra.cambiarEstado(new EligiendoHabilidad(mazmorra, jugador, unidades));
			break;
			case "Up":
				moverCursor(new Vector2I(0, -1));
			break;
			case "Down":
				moverCursor(new Vector2I(0, 1));
			break;
			case "Left":
				moverCursor(new Vector2I(-1, 0));
			break;
			case "Right":
				moverCursor(new Vector2I(1, 0));
			break;
			case "Enter":
				if(posCursor != posJugador) 
					this.mazmorra.cambiarEstado(new EjecutandoTurnoJugador(mazmorra, jugador, unidades, habilidad, posCursor));
			break;
		}
	} 

	public override void comportamiento(){
	}

	private void moverCursor(Vector2I direccion){
		if(!aStar.IsPointSolid(posCursor + direccion)){
			posCursor += direccion;
			Godot.Collections.Array<Vector2I> tempPath = aStar.GetIdPath(posCursor, posJugador); 
			if(tempPath.Count - 1 > jugador.getMovimientosTemp()){
				posCursor -= direccion;
			}else
				path = tempPath;
		} 
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
