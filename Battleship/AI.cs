using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class AI : Player
    {

        public AI(OutputManager oManager) : base(ref oManager) { }

        public void PlaceShips()
        {
            foreach (Ship ship in ships)
            {
                PlaceShip(new String[] { ship.type });
            }
        }
    }
}
