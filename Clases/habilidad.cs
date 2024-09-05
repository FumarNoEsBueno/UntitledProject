using Godot;
using System;

public abstract class Habilidad 
{
	protected static String wea = "coso";
	protected String nombre;
	protected Unidad unidad;
	protected Unidad unidadObjetivo;
	protected Vector2I localizacionObjetivo;
	protected AStarGrid2D astar;

	public String getNombre(){
		return this.nombre;
	}

	public abstract void comportamiento();
	public abstract void inicializar();
}

public class movimiento : Habilidad  
{
	public movimiento(Unidad unidad, AStarGrid2D astar){
        this.unidad = unidad;
        this.astar = astar;
		this.nombre = "Mover C";
	}

	public override void inicializar(){
    }

	public override void comportamiento(){
	} 
}

public class movimientoAutomatico : Habilidad  
{
	public movimientoAutomatico(){
		this.nombre = "Mover C lo";
	}

	public override void inicializar(){
    }

	public override void comportamiento(){
		GD.Print(this.nombre);
	} 
}
