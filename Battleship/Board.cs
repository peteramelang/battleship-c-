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

        public static void Print()
        {
            string[,] fieldData = new string[Board.rowCount, Board.columnCount] {
                { Constants.EMPTY_FIELD, Constants.AIRCRAFT_CARRIER, "", "", "", "", "", "", "", "" } ,
                { "", Constants.AIRCRAFT_CARRIER, "", "", "", "", "", "", "", "" } ,
                { "", Constants.AIRCRAFT_CARRIER, "", "", "", "", "", "", "", "" } ,
                { "", Constants.AIRCRAFT_CARRIER, "", "", "", "", "", "", "", "" } ,
                { "", Constants.AIRCRAFT_CARRIER, "", "", "", "", "", "", "", "" } ,
                { "", "", "", "", "", "", "", "", "", "" } ,
                { "", "", "", "", "", "", "", "", "", "" } ,
                { "", "", "", "", "", "", "", "", "", "" } ,
                { "", "", "", "", "", "", "", "", "", "" } ,
                { "", "", "", "", "", "", "", "", "", "" } 
            };

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
                        if(column >= 0)
                        {
                            Console.Write(" " + ++column);
                            if (column != 10) Console.Write(" |");

                            column--;
                        } else
                        {
                            Console.Write("   |");
                        }
                    } else if(column == -1)
                    {
                        Console.Write(" " + Constants.ALPHABET[row] + " |");
                    } else
                    {
                        Console.Write(
                            Constants.BOARD_SYMBOLS[
                                data[row, column]
                                ]
                            );
                        Console.Write("|");
                    }
                }
                Console.WriteLine();

                for (int column = -1; column < columnCount; column++)
                {
                    Console.Write("---+");
                }

                Console.WriteLine();
            }
        }
    }
}
