using Godot;
using System;

public partial class Casilla : Node2D
{
    private bool ocupada;

    public Casilla(bool ocupada){
        this.ocupada = ocupada;
    }

    public bool getOcupada(){
        return ocupada;
    }
}
