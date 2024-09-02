using Godot;
using System;

public abstract class habilidad : Node2D
{
    protected Unidad unidad;
    protected Unidad unidadObjetivo;
    protected Vector2I localizacionObjetivo;
    protected AStarGrid2D astar;

    public abstract void comportamiento();
}

public class movimiento : habilidad 
{
    public override void comportamiento(){
    } 
}
