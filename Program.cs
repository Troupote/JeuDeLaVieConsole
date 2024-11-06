using JeuDeLaVieConsole;
using System;

class Program
{
    static void Main(string[] args)
    {
        Coords point1 = new Coords(1, 2);
        Coords point2 = new Coords(3, 4);
        Coords point3 = new Coords(5, 6);
        Coords point4 = new Coords(7, 8);

        List<Coords> points = new List<Coords> { point1, point2, point3, point4 };

        Grid TEST = new Grid(5,points);

        Console.WriteLine(TEST.DisplayGrid);
    }
}
