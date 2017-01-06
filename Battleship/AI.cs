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
                // logic for intelligent placement of ships

                bool shipPlaceable;

                int shipLength = ship.GetLength();
                int[][] coordinates = new int[shipLength][];

                do
                {
                    coordinates = GetNewCoordinates(shipLength);
                    shipPlaceable = IsShipPlaceable(coordinates);
                } while (!shipPlaceable);

                ship.SetCoordinates(coordinates);
            }
        }

        int[][] GetNewCoordinates(int shipLength)
        {
            Random random = new Random();

            int x = random.Next(0, 10);
            int y = random.Next(0, 10);

            int[][] coordinates = new int[shipLength][];

            coordinates[0] = new int[] { x, y };

            int directionX = random.Next(-1, 2);
            int directionY = 0;

            if (directionX == 0)
            {
                do
                {
                    directionY = random.Next(-1, 2);
                } while (directionY == 0);
            }          

            for (int i = 1; i < shipLength; i++)
            {
                x += directionX;
                y += directionY;

                coordinates[i] = new int[] { x, y };
            }

            return coordinates;
        }

        bool IsShipPlaceable(int[][] coordinates)
        {
            int coordinatesLength = coordinates.Length;

            for (int i = 0; i < coordinatesLength; i++)
            {
                bool coordinateInBound = CoordinatesInBounds(coordinates[i]);

                if (!coordinateInBound)
                    return false;
            }

            return true;
        }

        bool CoordinatesInBounds(int[] coordinate)
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
    }
}
