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
	protected Vector2I vectorObjetivo;
	protected Godot.Collections.Array<Vector2I> path;
    protected int pathId;


	public String getNombre(){
		return this.nombre;
	}

	public abstract void inicializar(AStarGrid2D astar,
            Vector2I objetivo,
            Godot.Collections.Array<Vector2I> path);

	public abstract bool comportamiento();
}

public class movimiento : Habilidad  
{
	private int velocidad = 5;
	private Vector2 dir;

	public movimiento(Unidad unidad){
		this.unidad = unidad;
		this.nombre = "Mover C";
	}

	public override void inicializar(AStarGrid2D astar,
            Vector2I objetivo,
            Godot.Collections.Array<Vector2I> path){

		this.astar = astar;
		this.vectorObjetivo = objetivo;
        this.path = path;
        this.path.Reverse();
        this.pathId = 1;
        this.dir = this.path[pathId] - this.unidad.getVector2I();
    }

	public override bool comportamiento(){
		this.unidad.setPosition(unidad.getPosition() + (dir) * 4);
        if(this.unidad.getPosition() == path[pathId] * 64){
            pathId++;
            if(pathId == path.Count) return true;
            dir = path[pathId] - this.unidad.getVector2I();
        }
		return false;
		
	} 
}

public class movimientoAutomatico : Habilidad  
{
	public movimientoAutomatico(){
		this.nombre = "Mover C lo";
	}

	public override void inicializar(AStarGrid2D astar,
            Vector2I objetivo,
            Godot.Collections.Array<Vector2I> path){
		this.astar = astar;
		this.vectorObjetivo = objetivo;
        this.path = astar.GetIdPath(unidad.getVector2I(), objetivo);
        this.pathId = 1;
    }

	public override bool comportamiento(){
		GD.Print(this.nombre);
		return true;
	} 
}
