using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player
    {
        Dictionary<string, Ship> ships = new Dictionary<string, Ship>();

        public bool alive = true;

        public void PlaceShip(string shipType) {
            ships.Add(shipType, new Ship(shipType));
        }
    }
}
