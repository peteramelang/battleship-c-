using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board
    {
        private string[,] fieldData = new string[Constants.ROWCOUNT, Constants.COLUMNCOUNT];

        Game game;

        public Board(Game game)
        {
            this.game = game;

            for (int i = 0; i < Constants.ROWCOUNT; i++)
            {
                for (int j = 0; j < Constants.COLUMNCOUNT; j++)
                {
                    fieldData[i, j] = Constants.EMPTY_FIELD;
                }
            }
        }

        public void UpdateData(Player player)
        {
            Dictionary<string, List<int[]>> shipsCoordinates = player.GetPlacedShipCoordinates();

            foreach (KeyValuePair<string, List<int[]>> shipCoordinates in shipsCoordinates)
            {
                foreach (int[] shipCoordinate in shipCoordinates.Value)
                {
                    int x = shipCoordinate[0];
                    int y = shipCoordinate[1];

                    fieldData[x, y] = shipCoordinates.Key;
                }
            }
        }

        public void Print()
        {
            PrintBoard(fieldData);
        }

        static void PrintBoard(string[,] data)
        {
            for(int row = -1; row < Constants.ROWCOUNT; row++)
            {
                for(int column = -1; column < Constants.COLUMNCOUNT; column++)
                {
                    if(row == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (column >= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Write(" " + ++column);

                            Console.ForegroundColor = ConsoleColor.Gray;

                            if (column != 10) Console.Write(" |");

                            column--;
                        } else
                        {
                            Console.Write("   |");
                        }
                    } else if(column == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write(" " + Constants.ALPHABET[row]);

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write(
                            Constants.BOARD_SYMBOLS[
                                data[row, column]
                                ]
                            );

                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.Write("|");
                    }
                }
                Console.WriteLine();

                for (int column = -1; column < Constants.COLUMNCOUNT; column++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write("---+");
                }

                Console.WriteLine();
            }
        }
    }
}
