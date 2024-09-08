using Godot;
using System;

public class FabricaCasilla
{
    AStarGrid2D aStar;

    public FabricaCasilla(AStarGrid2D aStar){
        this.aStar = aStar;
    }

    public Casilla fabricarCasilla(int id, int posicionX, int posicionY){
        switch(id){
            case 0: return new CasillaVacia(posicionX, posicionY, aStar);
            case 1: return new ParedTesteo(posicionX, posicionY, aStar);
        }
        return null;
    }
}
