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
            set { this._n = value; }
        }

        Cell[,] TabCells;

        public Grid(int nbCells, List<Coords> AliveCellsCoords)
        {
            this.n = nbCells;
            this.TabCells = new Cell[n, n];
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
                    if ((k >= 0 && k < n && l >= 0 && l < n) && (k != i || l != j))
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

            for (int i = 0; i < n ; i++)
            {
                for (int j = 0; j < n ; j++)
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

            Console.WriteLine(ToDisplay);
        }

        public void UpdateGrid()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int aliveNeighbors = getNbAliveNeighboor(i, j);
                    if (TabCells[i, j].isAlive)
                    {
                        // Une cellule vivante reste en vie si elle a 2 ou 3 voisins vivants
                        TabCells[i, j].nextState = (aliveNeighbors == 2 || aliveNeighbors == 3);
                    }
                    else
                    {
                        // Une cellule morte devient vivante si elle a exactement 3 voisins vivants
                        TabCells[i, j].nextState = (aliveNeighbors == 3);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    TabCells[i, j].isAlive = TabCells[i, j].nextState;
                }
            }
        }

    }
}
