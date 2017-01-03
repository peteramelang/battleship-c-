using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board
    {
        const int rowCount = 10;
        const int columnCount = 10;

        private string[,] fieldData = new string[Board.rowCount, Board.columnCount];

        public Board()
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    fieldData[i, j] = Constants.EMPTY_FIELD;
                }
            }
        }

        public void Print()
        {
            Board.PrintBoard(fieldData);
        }

        static void PrintBoard(string[,] data)
        {
            for(int row = -1; row < rowCount; row++)
            {
                for(int column = -1; column < columnCount; column++)
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

                for (int column = -1; column < columnCount; column++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write("---+");
                }

                Console.WriteLine();
            }
        }
    }
}
