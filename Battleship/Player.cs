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

        protected OutputManager oManager;
        protected Game game;

        public bool alive = true;

        public Player(ref OutputManager oManager, Game game)
        {
            this.oManager = oManager;
            this.game = game;

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

        public Dictionary<string, List<int[]>> GetPlacedShipCoordinates()
        {
            Dictionary<string, List<int[]>> placedShipCoordinates = new Dictionary<string, List<int[]>>();

            foreach (Ship ship in ships)
            {
                if (ship.IsSet())
                {
                    if (!placedShipCoordinates.ContainsKey(ship.type))
                    {
                        placedShipCoordinates.Add(ship.type, new List<int[]>());
                    }

                    int[][] shipCoordinates = ship.GetCoordinates();

                    foreach (int[] shipCoordinate in shipCoordinates)
                    {
                        placedShipCoordinates[ship.type].Add(shipCoordinate);
                    }
                }
            }

            return placedShipCoordinates;
        }

        protected bool IsShipPlaceable(int[][] coordinates)
        {
            int coordinatesLength = coordinates.Length;

            for (int i = 0; i < coordinatesLength; i++)
            {
                bool coordinateInBound = CoordinateInBounds(coordinates[i]);
                bool coordinateTaken = CoordinateTaken(coordinates[i]);

                if (!coordinateInBound && !coordinateTaken)
                    return false;
            }

            return true;
        }

        protected bool CoordinateInBounds(int[] coordinate)
        {
            int[][] boardBoundings = new int[][]
            {
                new int[] { 0, Constants.COLUMNCOUNT - 1 },
                new int[] { 0, Constants.ROWCOUNT - 1 }
            };

            if ((coordinate[0] >= boardBoundings[0][0] && coordinate[0] <= boardBoundings[0][1]) &&
            (coordinate[1] >= boardBoundings[1][0] && coordinate[1] <= boardBoundings[1][1]))
            {
                return true;
            }

            return false;
        }

        protected bool CoordinateTaken(int[] coordinate)
        {
            Dictionary<string, List<int[]>> shipsCoordinates = GetPlacedShipCoordinates();

            foreach (KeyValuePair<string, List<int[]>> shipCoordinates in shipsCoordinates)
            {
                foreach (int[] shipCoordinate in shipCoordinates.Value)
                {
                    if (shipCoordinate == coordinate)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
