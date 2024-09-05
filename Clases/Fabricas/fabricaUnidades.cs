using Godot;
using System;
using System.Collections.Generic;

public class FabricaUnidad
{
    public Unidad fabricarUnidad(int id){
        switch(id){
            case 0: return new personajeTesteo();
            case 1: return new enemigoTesteo();
        }
        return null;
    }
}
