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

	public abstract void inicializar(AStarGrid2D astar, Vector2I objetivo);
	public abstract bool comportamiento();
}

public class movimiento : Habilidad  
{
    AStarGrid2D astar;
    Vector2I objetivo;

	public movimiento(Unidad unidad){
        this.unidad = unidad;
		this.nombre = "Mover C";
	}

	public override void inicializar(AStarGrid2D astar, Vector2I objetivo){
        this.astar = astar;
        this.objetivo = objetivo;
    }

	public override bool comportamiento(){
        this.unidad.setPosition(objetivo * 64);
        return true;
        
	} 
}

public class movimientoAutomatico : Habilidad  
{
	public movimientoAutomatico(){
		this.nombre = "Mover C lo";
	}

	public override void inicializar(AStarGrid2D astar, Vector2I objetivo){
    }

	public override bool comportamiento(){
		GD.Print(this.nombre);
        return true;
	} 
}
