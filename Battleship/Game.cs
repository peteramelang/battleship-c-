using System;
using System.Linq;

namespace Battleship
{
    class Game
    {
        public Human human;
        public AI ai;

        Player[] players = new Player[2];

        Board board;
        InputManager iManager;
        OutputManager oManager;

        bool playing = true;

        public Game()
        {
            

            board = new Board();
            iManager = new InputManager(this);
            oManager = new OutputManager(this);

            human = new Human(oManager);
            ai = new AI(oManager);

            players[0] = human;
            players[1] = ai;
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
                case Constants.REQUEST:
                    oManager.Request(data);
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

        public static string GetParameter(string[] parameterList)
        {
            string parameter = "";

            if (parameterList != null && parameterList.Length != 0)
                parameter = parameterList.First().ToLower();

            return parameter;
        }

        public static string MakeUppercase(string word)
        {
            return word.First().ToString().ToUpper() + word.Substring(1);
        }
    }
}
