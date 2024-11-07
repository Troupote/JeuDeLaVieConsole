using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeLaVieConsole
{
    public class Game
    {
        private int n;
        private int iter;
        public Grid grid;
        List<Coords> AliveCellsCoords;

        public Game(int nbCells, int nbIterations)
        {
            this.n = nbCells;
            this.iter = nbIterations;
            this.AliveCellsCoords = new List<Coords>() { new Coords(1,2), new Coords(1, 3), new Coords(1, 4) };
            this.grid = new Grid(n, AliveCellsCoords);
        }

        public void RunGameConsole()
        {
            grid.DisplayGrid();
            for (int i = 0; i < iter; i++)
            {
                grid.UpdateGrid();
                grid.DisplayGrid();
                Thread.Sleep(1000);
            }

        }
    }
}
