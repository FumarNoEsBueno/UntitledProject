using Godot;
using System;
using System.Collections.Generic;

public abstract class Casilla
{
	protected Sprite2D sprite = new Sprite2D();
	protected String descripcion;
	protected String nombre;
	protected AStarGrid2D aStar;
	protected bool transitable;
	protected List<Unidad> unidades = new List<Unidad>();
	
	public void addUnidad(Unidad unidad){
		unidad.setPosition(this.sprite.Position);
		aStar.SetPointSolid(unidad.getVector2I(), true);
		this.unidades.Add(unidad);
	}
	public Sprite2D getSprite(){
		return this.sprite;
	}

	public bool getTransitable(Unidad unidad){
		return unidades.Count > 0;
	}
}

public class CasillaVacia: Casilla{
	public CasillaVacia(int posicionX, int posicionY, AStarGrid2D aStar){
		this.sprite.Position = new Vector2(posicionX * 64, posicionY * 64);
		this.transitable = true;
		this.aStar = aStar;
	}
}

public class ParedTesteo: Casilla{

	public ParedTesteo(int posicionX, int posicionY, AStarGrid2D aStar){
		this.nombre = "Pared Testeo";
		this.transitable = false;
		this.sprite.Texture = GD.Load<Texture2D>("res://Sprites/Casillas/ParedTesteo.png");
		this.sprite.Position = new Vector2(posicionX * 64, posicionY * 64);
		this.sprite.ZIndex = -100;
	}
}
