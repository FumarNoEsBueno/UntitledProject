using Godot;
using System;

public abstract class Habilidad 
{
    protected String nombre;
    protected Unidad unidad;
    protected Unidad unidadObjetivo;
    protected Vector2I localizacionObjetivo;
    protected AStarGrid2D astar;

    public String getNombre(){
        return this.nombre;
    }

    public abstract void comportamiento();
}

public class movimiento : Habilidad  
{
    public movimiento(){
        this.nombre = "Mover C";
    }

    public override void comportamiento(){
        GD.Print(this.nombre);
    } 
}

public class movimientoAutomatico : Habilidad  
{
    public movimientoAutomatico(){
        this.nombre = "Mover C lo";
    }

    public override void comportamiento(){
        GD.Print(this.nombre);
    } 
}
