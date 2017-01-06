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

        public Board()
        {
            for (int i = 0; i < Constants.ROWCOUNT; i++)
            {
                for (int j = 0; j < Constants.COLUMNCOUNT; j++)
                {
                    fieldData[i, j] = Constants.EMPTY_FIELD;
                }
            }
        }

        void UpdateData(Player player)
        {
            Dictionary<string, int[][]> ships = player.GetPlacedShipCoordinates();
            

            foreach (KeyValuePair<int[], string> coordinate in coordinateData)
            {
                int x = coordinate.Key[0];
                int y = coordinate.Key[1];

                fieldData[x, y] = coordinate.Value;
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
