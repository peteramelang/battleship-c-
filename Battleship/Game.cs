using System;

namespace Battleship
{
    class Game
    {
        public Human human = new Human();
        public AI ai = new AI();

        Player[] players = new Player[2];

        Board board;
        InputManager iManager;
        OutputManager oManager;

        bool playing = true;

        public Game()
        {
            players[0] = human;
            players[1] = human;

            board = new Board();
            iManager = new InputManager(this);
            oManager = new OutputManager(this);
        }

        public void Start()
        {
            PrintInterface();

            do
            {                
                iManager.Listen();
            } while (playing);
        }

        public void Print(string type = null, string[] data = null)
        {
            type = type ?? "";
            data = data ?? new string[0];

            PrintInterface();

            switch (type)
            {
                case Constants.STATUS_ERROR:
                    oManager.ThrowError(data);
                    break;
                case Constants.HELP:
                    oManager.PrintHelp(data);
                    break;
            }
        }

        void PrintInterface()
        {
            Console.Clear();

            oManager.PrintOverview();
            oManager.PrintBoard();
            oManager.PrintHelp(new string[] { Constants.PARA_ALL });

            Console.WriteLine();
        }
    }
}
