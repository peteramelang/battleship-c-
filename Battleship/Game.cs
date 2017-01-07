using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    class Game
    {
        public Human human;
        public AI ai;

        Player[] players = new Player[2];

        public Board board;
        InputManager iManager;
        OutputManager oManager;

        bool playing = true;

        public Game()
        {
            board = new Board(this);
            iManager = new InputManager(this);
            oManager = new OutputManager(this);

            human = new Human(oManager, this);
            ai = new AI(oManager, this);

            players[0] = human;
            players[1] = ai;

            ai.PlaceShips();

        }

        public void Start()
        {
            PrintMainInterface();

            do
            {                
                iManager.Listen();
            } while (playing);
        }

        public void Print(string type = null, string[] data = null)
        {
            type = type ?? "";
            data = data ?? new string[0];

            PrintMainInterface();
            
            if(type.Length > 0 && type != null)
                PrintAdditionalInformation(type, data);
        }

        void PrintMainInterface()
        {
            Console.Clear();

            oManager.PrintOverview();
            oManager.PrintBoard();
            oManager.PrintHelp(new string[] { Constants.PARA_ALL });

            Console.WriteLine();
        }

        void PrintAdditionalInformation(string type, string[] data)
        {
            switch (type)
            {
                case Constants.STATUS_ERROR:
                    oManager.ThrowError(data);
                    break;
                case Constants.HELP:
                    oManager.PrintHelp(data);
                    break;
                case Constants.STATUS_REQUEST:
                    oManager.PrintRequest(data);
                    break;
            }
        }

        public static string GetFirstParameter(string[] parameterList)
        {
            string parameter = "";

            if (parameterList != null && parameterList.Length != 0)
                parameter = parameterList[0];

            return parameter;
        }

        public static string GetFirstParameter(string parameter)
        {
            return parameter;
        }

        public static string MakeUppercase(string word)
        {
            return word.First().ToString().ToUpper() + word.Substring(1);
        }

        public static string[] MakeUppercase(string[] words)
        {
            List<string> uppercase = new List<string>();

            foreach (string word in words)
            {
                uppercase.Add(MakeUppercase(word));
            }

            return uppercase.ToArray();
        }
    }
}
