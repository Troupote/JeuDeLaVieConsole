using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeLaVieConsole
{
    public struct Coords
    {

        private int _x;

        public int x
        {
            get { return _x; }
            set { _x = value; }
        }

        private int _y;

        public int y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Coords (int X, int Y)
        {
            x = X;
            y = Y;
        }

        public override string ToString()
        {
            return "( " + this.x + " , " + this.y + " )";
        }

    }
}
