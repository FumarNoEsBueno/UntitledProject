using Godot;
using System;
using System.Collections.Generic;

public class FabricaCasilla
{
    public Casilla fabricarCasilla(int id, int posicionX, int posicionY){
        switch(id){
            case 0: return new CasillaVacia(posicionX, posicionY);
            case 1: return new ParedTesteo(posicionX, posicionY);
        }
        return null;
    }
}
