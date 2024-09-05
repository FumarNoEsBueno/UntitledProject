using Godot;
using System;
using System.Collections.Generic;

public abstract class Unidad 
{
    protected String nombre;
    protected Sprite2D sprite = new Sprite2D();
    protected List<Habilidad> habilidades = new List<Habilidad>();
    
    public Vector2I getVector2I(){
        return new Vector2I((int)this.sprite.Position.X/64, (int)this.sprite.Position.Y/64);
    }

    public Sprite2D getSprite(){
        return this.sprite;
    }

    public List<Habilidad> getHabilidades(){
        return this.habilidades;
    }

    public void setPosition(Vector2 position){
        this.sprite.Position = position;
    }

    public abstract void comportamiento(); 
}

public class personajeTesteo: Unidad{

    public personajeTesteo(){
        this.nombre = "Personaje de testeo";
		this.sprite.Texture = GD.Load<Texture2D>("res://Sprites/Unidades/UnidadTesteo1.png");
        this.habilidades.Add(new movimiento());
    }

    public override void comportamiento(){
    } 
}

public class enemigoTesteo: Unidad{

    public enemigoTesteo(){
        this.nombre = "Enemigo de testeo";
		this.sprite.Texture = GD.Load<Texture2D>("res://Sprites/Unidades/UnidadTesteo2.png");
        this.habilidades.Add(new movimientoAutomatico());
    }

    public override void comportamiento(){
        this.habilidades[0].comportamiento();
    } 
}
