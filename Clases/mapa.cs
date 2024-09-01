using Godot;
using System;

public partial class Mapa : Node2D
{
    private Casilla[,] casilla = new Casilla[10,10];
    private AStarGrid2D aStar = new AStarGrid2D();

    public Mapa(){
        int[,] mazmorraTemporal = {
            {1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1},
        };

        for(int i = 0; i < 10; i++){
            for(int j = 0; j < 10; j++){
                this.casilla[j,i] = new Casilla(mazmorraTemporal[j,i] == 0);
                GD.Print("Test");
            }
        }
    }

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
}
