using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Board
    {
        int rowCount = 10;
        int columnCount = 10;
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public void Print()
        {
            Object ding = new Object();

            PrintBoard(ding);
        }

        void PrintBoard(Object data)
        {
            for(int i = -1; i < rowCount; i++)
            {
                for(int j = -1; j < columnCount; j++)
                {
                    if(i == -1)
                    {
                        if(j >= 0)
                        {
                            Console.Write(" " + j + " |");
                        } else
                        {
                            Console.Write("   |");
                        }
                    } else if(j == -1)
                    {
                        Console.Write(" " + alphabet[i] + " |");
                    } else
                    {
                        Console.Write("   |");
                    }
                }
                Console.WriteLine();

                for (int j = -1; j < columnCount; j++)
                {
                    Console.Write("---+");
                }

                Console.WriteLine();
            }
        }
    }
}
