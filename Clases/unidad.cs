using Godot;
using System;
using System.Collections.Generic;

public abstract class Unidad 
{
    protected String nombre;
    protected int movimientos;
    protected int movimientosTemp;
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

    public Vector2 getPosition(){
        return this.sprite.Position;
    }

    public void setPosition(Vector2 position){
        this.sprite.Position = position;
    }

    public int getMovimientosTemp(){
        return this.movimientosTemp;
    }

    public Unidad(){
        this.sprite.ZIndex = -100;
    }

    public abstract void comportamiento(); 
}

public class personajeTesteo: Unidad{

    public personajeTesteo(): base(){
        this.nombre = "Personaje de testeo";
        this.movimientos = 6;
        this.movimientosTemp = 6;
		this.sprite.Texture = GD.Load<Texture2D>("res://Sprites/Unidades/Detofoo.png");
        this.habilidades.Add(new movimiento(this));
    }

    public override void comportamiento(){
    } 
}

public class enemigoTesteo: Unidad{

    public enemigoTesteo(): base(){
        this.nombre = "Enemigo de testeo";
		this.sprite.Texture = GD.Load<Texture2D>("res://Sprites/Unidades/Kikimora_chiquita.png");
        this.habilidades.Add(new movimientoAutomatico());
    }

    public override void comportamiento(){
        this.habilidades[0].comportamiento();
    } 
}
