using System;

namespace Battleship
{
    class Game
    {
        static Human human = new Human();
        static AI ai = new AI();

        Player[] players = { human, ai };

        Board board;
        InputManager iManager;
        OutputManager oManager;

        bool playing = true;

        public Game()
        {
            board = new Board();
            iManager = new InputManager(this);
            oManager = new OutputManager(this);
        }

        public void Start()
        {
            oManager.PrintInstructions();

            board.Print();

            do
            {
                iManager.Listen();
            } while (playing);
        }

        public void Print(string type, string[] data = null)
        {
            data = data ?? new string[0];

            Console.WriteLine(data);

            switch (type)
            {
                case Constants.STATUS_ERROR:
                    oManager.ThrowError(output);
                    break;
                case "help":
                    oManager.ShowCommands(data);
                    break;
            }
        }
    }
}
