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

                bool shipPlaced;

                int shipLength = ship.GetLength();
                int[][] coordinates = new int[shipLength][];

                Random random = new Random();
                
                do
                {
                    int x = random.Next(0, 10);
                    int y = random.Next(0, 10);

                    coordinates[0] = new int[] { x, y };

                    int directionX = random.Next(-1, 2);
                    int directionY = 0;

                    if (directionX == 0)
                        directionY = random.Next(-1, 2);

                    for (int i = 1; i < shipLength; i++)
                    {
                        x += directionX;
                        y += directionY;

                        coordinates[i] = new int[] { x, y };
                    }

                    shipPlaced = ship.Place(coordinates, GetPlacedShipCoordinates());
                } while (!shipPlaced);

                
            }
        }
    }
}
