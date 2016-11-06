using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class OutputManager
    {

        private static Game game;

        public OutputManager(Game game)
        {
            OutputManager.game = game;
        }

        public void PrintOverview(Dictionary<string, int> shipCount = null)
        {
            shipCount = shipCount ?? Constants.SHIP_COUNT;

            foreach (KeyValuePair<string, int> ship in Constants.SHIP_LENGTHS)
            {
                Console.Write("{0}x", shipCount[ship.Key]);
                Console.Write(" {0}: ", ship.Key);

                // Add Space
                for (int i = 0; i < Constants.AIRCRAFT_CARRIER.Length - ship.Key.Length; i++)
                {
                    Console.Write(" ");
                }

                for (int i = 0; i < Constants.SHIP_LENGTHS[ship.Key]; i++)
                {
                    Console.Write(Constants.BOARD_SYMBOLS[ship.Key]);
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void ThrowError(string[] errors)
        {
            Console.WriteLine(Constants.LABEL_ERROR);

            foreach (string error in errors)
            {
                Console.WriteLine(error);
            }
        }

        public void PrintHelp(string[] parameterList = null)
        {
            string parameter = GetParameter(parameterList);

            if (parameter.Length == 0 ||parameter == "")
            {
                Console.WriteLine(Constants.DESC_HELP);
            }
            else if (parameter == Constants.PARA_ALL)
            {
                Console.Write("Commands: ");

                foreach (string commandKey in Constants.COMMANDS.Keys)
                {
                    string formattedCommand = string.Format(
                        "({0}){1}",
                        commandKey.First(),
                        commandKey.Substring(1)
                        );

                    Console.Write(formattedCommand);
                    
                    if(commandKey != Constants.COMMANDS.Keys.Last())
                        Console.Write(", ");
                }
            }
            else
            {
                string commandDescription;

                if (Constants.COMMANDS.TryGetValue(parameter,  out commandDescription))
                {
                    Console.WriteLine(commandDescription);
                } else
                {
                    ThrowError(new string[] { Constants.LABEL_UNKNOWN_COMMAND });
                }
            }
        }

        public void PrintBoard()
        {
            Board.Print();
        }

        static string GetParameter(string[] parameterList)
        {
            string parameter = "";

            if (parameterList != null && parameterList.Length != 0)
                parameter = parameterList.First().ToLower();

            return parameter;
        }
    }
}
