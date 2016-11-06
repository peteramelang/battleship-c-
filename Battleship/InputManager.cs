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

        void HandleInput(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                game.Print(Constants.STATUS_ERROR);
                return;
            }

            string[] splitInput = input.Split();
            string command = splitInput.First().ToLower();
            string[] parameterList = splitInput.Skip(1).ToArray();

            switch (command)
            {
                case Constants.HELP:
                    game.Print("help", "", parameterList);
                    break;
                case Constants.EXIT:
                    Environment.Exit(0);
                    break;

                case Constants.SHOW:
                    //RunShow(parameter);
                    break;

                default:
                    game.Print("error", "Unknown command. Use help to see all commands.");
                    break;
            }


        }

        void RunShow(string[] parameter)
        {
            

            // only one accepted
            string validParameter = parameter.First();

            switch (validParameter)
            {
                

                default:
                    break;
            }
        }
    }
}
