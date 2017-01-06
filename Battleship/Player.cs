using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Player
    {
        protected List<Ship> ships = new List<Ship>();

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

        protected void PlaceShip(string[] parameter) {
            string[] parameterList = Game.MakeUppercase(parameter);

            if (parameterList.Length == 0)
            {
                oManager.PrintHelp(new string[] { "place" });
                return;
            }

            string shipType = Game.GetFirstParameter(parameterList);

            if (!Constants.SHIP_LENGTHS.ContainsKey(shipType))
            {
                oManager.ThrowError(Constants.LABEL_INVALID_PARAMETER);
                return;
            }

            foreach (Ship ship in ships)
            {
                if (ship.type == shipType)
                {
                    Console.WriteLine("blimb");
                }
            }
        }

        public List<Ship> GetShips()
        {
            return ships;
        }

        public Dictionary<string, int[][]> GetPlacedShipCoordinates()
        {
            Dictionary<string, int[][]> placedShipCoordinates = new Dictionary<string, int[][]>();

            foreach (Ship ship in ships)
            {
                if (ship.IsSet())
                {
                    placedShipCoordinates.Add(ship.type, ship.GetCoordinates());
                }
            }

            return placedShipCoordinates;
        }
    }
}
