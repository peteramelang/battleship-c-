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

        OutputManager oManager;

        public bool alive = true;

        public Player(OutputManager oManager)
        {
            this.oManager = oManager;
        }

        public void PlaceShip(string[] shipType) {
            string parameter = Game.MakeUppercase(Game.GetParameter(shipType));

            if (parameter.Length == 0 || parameter == "")
            {
                oManager.PrintHelp(new string[] { "place" });
                return;
            }
            else if (!Constants.SHIP_LENGTHS.ContainsKey(parameter))
            {
                oManager.ThrowError(new string[] { Constants.LABEL_INVALID_PARAMETER });
                return;
            }

            ships.Add(parameter, new Ship(parameter));
        }

        public Dictionary<string, Ship> GetShips()
        {
            return ships;
        }
    }
}
