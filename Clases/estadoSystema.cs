using Godot;
using System;

public abstract class EstadoSystema 
{
    protected Systema sistema;
    public EstadoSystema(Systema sistema){
        this.sistema = sistema;
    }

    public abstract void comportamiento(); 
}

public class JugadorEnMazmorra : EstadoSystema
{
    public JugadorEnMazmorra(Systema sistema): base(sistema){}

    public override void comportamiento(){
    } 
}

public class menuPrincipal : EstadoSystema
{
    public menuPrincipal(Systema sistema): base(sistema){}
    public override void comportamiento(){
    } 
}
