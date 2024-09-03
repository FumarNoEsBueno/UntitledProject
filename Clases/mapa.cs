using Godot;
using System;

public partial class Mapa : Node2D
{
    private Casilla[,] casilla = new Casilla[10,10];
    private AStarGrid2D aStar = new AStarGrid2D();

    public Mapa(){
        FabricaCasilla fabricaCasilla = new FabricaCasilla();
        FabricaUnidad fabricaUnidad = new FabricaUnidad();

        this.aStar.Region = new Rect2I(0, 0, 10, 10);
        this.aStar.CellSize = new Vector2I(64, 64);
        this.aStar.DiagonalMode = Godot.AStarGrid2D.DiagonalModeEnum.Never;
        
        this.aStar.Update();

        int[,] mazmorraTemporal = {
            {1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,1,1,1,0,0,0,1},
            {1,0,0,0,0,1,1,1,1,1},
            {1,1,1,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1},
        };

        mazmorraTemporal = girarLaWeaDeMatrizPorqueSinoNoFuncionaPorLaCresta(mazmorraTemporal);

        for(int i = 0; i < 10; i++){
            for(int j = 0; j < 10; j++){
                this.casilla[i,j] = fabricaCasilla.fabricarCasilla(mazmorraTemporal[i,j], i, j);
                this.AddChild(casilla[i,j].getSprite());
                this.aStar.SetPointSolid(new Vector2I(i,j), mazmorraTemporal[i,j]==1);
            }
        }

        Unidad tempUnidad = fabricaUnidad.fabricarUnidad(0);
        this.casilla[1,1].addUnidad(tempUnidad);
        this.AddChild(tempUnidad.getSprite());

        Unidad tempUnidad2 = fabricaUnidad.fabricarUnidad(1);
        this.casilla[2,4].addUnidad(tempUnidad2);
        this.AddChild(tempUnidad2.getSprite());

        GD.Print(this.aStar.GetIdPath(tempUnidad.getVector2I(), tempUnidad2.getVector2I()));
    }

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

    static int[,] girarLaWeaDeMatrizPorqueSinoNoFuncionaPorLaCresta(int[,] matriz)
    {
        int filas = matriz.GetLength(0);
        int columnas = matriz.GetLength(1);
        int[,] matrizRotada = new int[columnas, filas];
        for (int i = 0; i < filas; i++){
            for (int j = 0; j < columnas; j++){
                matrizRotada[columnas - 1 - j, i] = matriz[i, j];
            }
        }
        return matrizRotada;
    }

    public override void _Input(InputEvent @event)
    {
        GD.Print(@event.AsText());
    }
}
