using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    class InputManager
    {

        private static Game game;

        public InputManager(Game game)
        {
            InputManager.game = game;
        }

        public void Listen()
        {
            HandleInput(Console.ReadLine());
        }

        public string Request(string type)
        {
            game.Print(Constants.STATUS_REQUEST, new string[] { type });

            return "";
        }

        void HandleInput(string input)
        {
            input = input ?? "";

            string[] splitInput = input.Split();
            string command = splitInput.First().ToLower();
            string[] parameterList = splitInput.Skip(1).ToArray();

            if(command.Length == 1)
            {
                foreach (string validCommand in Constants.COMMANDS.Keys)
                {
                    if(validCommand.First().ToString() == command)
                    {
                        command = validCommand;
                    }
                }
            }

            switch (command)
            {
                case Constants.HELP:
                    game.Print(Constants.HELP, parameterList);
                    break;
                case Constants.EXIT:
                    Environment.Exit(0);
                    break;
                case Constants.PLACE:
                    game.human.PlaceShip(parameterList);
                    break;
                case "bb":
                    Dictionary<string, Ship> dong = game.human.GetShips();
                    Console.WriteLine("dong");
                    foreach (string key in dong.Keys)
                    {
                        Console.WriteLine("fd " + key);
                    }
                    break;
                default:
                    game.Print(Constants.STATUS_ERROR, new string[] { Constants.LABEL_UNKNOWN_COMMAND });
                    break;
            }
        }
    }
}
