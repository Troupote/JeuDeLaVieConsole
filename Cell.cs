using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeLaVieConsole
{
    public class Cell
    {

        private bool _isAlive;
        public bool isAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        private bool _nextState;

        public bool nextState
        {
            get { return _nextState; }
            set { _nextState = value; }

        }

        public Cell(bool state)
        {
            isAlive = state;
        }

        public void ComeAlive()
        {
            this.nextState = true;
        }

        public void PassAway()
        {
            this.nextState = false;
        }

        public void Update()
        {
            this.isAlive = this.nextState;
        }
    }
}
