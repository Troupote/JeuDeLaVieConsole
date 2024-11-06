using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeLaVieConsole
{
    public class Grid
    {

        private int _n;

        public int n
        {
            get { return _n; }
            set { _n = value; }
        }

        Cell[,] TabCells;

        public Grid(int nbCells, List<Coords> AliveCellsCoords)
        {
            this.n = nbCells;
            TabCells = new Cell[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Coords currentCoords = new Coords(i, j);
                    if (AliveCellsCoords.Contains(currentCoords))
                    {
                        TabCells[i, j] = new Cell(true);
                    }
                    else
                    {
                        TabCells[i, j] = new Cell(false);
                    }

                }
            }
        }

        public int getNbAliveNeighboor(int i, int j)
        {
            int Counter = 0;
            List<Coords> Neighbors = getCoordsNeighbors(i, j);
            Debug.Print("getnbaliveoukay");

            foreach (Coords neighbor in Neighbors)
            {
                if (TabCells[neighbor.x, neighbor.y].isAlive)
                {
                    Counter++;
                }
            }

            return Counter;
        }

        public List<Coords> getCoordsNeighbors(int i, int j)
        {
            List<Coords> ToReturn = new List<Coords>();
            for (int k = i - 1; k <= i + 1; k++)
            {
                for (int l = j - 1; l <= j + 1; l++)
                {
                    if (k >= 0 && k < n && l >= 0 && l < n)
                    {
                        ToReturn.Add(new Coords(k, l));
                    }
                }
            }

            return ToReturn;
        }

        public List<Coords> getCoordsCellsAlive()
        {
            List<Coords> ToReturn = new List<Coords>();

            for (int i = 0; i < TabCells.Length; i++)
            {
                for (int j = 0; j < TabCells.Length; j++)
                {
                    if (TabCells[i, j].isAlive)
                    {
                        ToReturn.Add(new Coords(i, j));
                    }
                }

            }
            return ToReturn;
        }

        public void DisplayGrid()
        {
            Debug.Print("godisplay");
            string ToDisplay = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ToDisplay += "+---";
                }
                ToDisplay += "+\n";

                for (int j = 0; j < n; j++)
                {
                    if (TabCells[i, j].isAlive)
                    {
                        ToDisplay += "| X ";
                    }
                    else
                    {
                        ToDisplay += "|   ";
                    }
                }
                ToDisplay += "|\n";
            }
            for (int j = 0; j < n; j++)
            {
                ToDisplay += "+---";
            }
            ToDisplay += "+\n";

            Debug.Print(ToDisplay);
            Console.WriteLine(ToDisplay);
        }
    }
}
