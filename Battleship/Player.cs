using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player
    {
        List<Ship> ships = new List<Ship>();

        OutputManager oManager;

        public bool alive = true;

        public Player(ref OutputManager oManager)
        {
            this.oManager = oManager;

            GenerateShips();
        }

        void GenerateShips()
        {
            foreach (KeyValuePair<String, int> ship in Constants.SHIP_COUNT)
            {
                for (int i = 0; i < ship.Value; i++)
                {
                    ships.Add(new Ship(ship.Key, this));
                }
            }
        }

        public void PlaceShip(string[] shipType) {
            string parameter = Game.MakeUppercase(Game.GetFirstParameter(shipType));

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

            foreach (Ship ship in ships)
            {
                if (ship.type == parameter)
                {

                }
            }
        }

        public List<Ship> GetShips()
        {
            return ships;
        }
    }
}
