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

        public void PrintInstructions()
        {
            Console.WriteLine("Place the following ships on the board:");
            Console.WriteLine("1x {0}: [A][A][A][A][A]", Constants.AIRCRAFT_CARRIER);
            Console.WriteLine("1x {0}:       [B][B][B][B]", Constants.BATTLESHIP);
            Console.WriteLine("1x {0}:          [C][C][C]", Constants.CRUISER);
            Console.WriteLine("2x {0}:        [D][D]", Constants.DESTROYER);
            Console.WriteLine();
            Console.WriteLine(Constants.DESC_PLACE_SHORT);
            Console.WriteLine();
        }

        public void ThrowError(string error)
        {
            Console.WriteLine(Constants.LABEL_ERROR + " " + error);
        }

        public void ShowCommands(string[] parameterList)
        {
            string parameter = ""; ;

            if (parameterList != null && parameterList.Length != 0)
            {
                parameter = parameterList.First().ToLower();
            }

            Console.Clear();

            if (string.IsNullOrEmpty(parameter))
            {
                Console.WriteLine(Constants.HEADLINE_LIST);

                foreach (KeyValuePair<string, string> command in Constants.commands)
                {
                    Console.WriteLine(command.Key/* + " - " + command.Value*/);
                }
            }
            else
            {
                string commandDescription;

                if (Constants.commands.TryGetValue(parameter, out commandDescription))
                {
                    Console.WriteLine(commandDescription);
                } else
                {
                    ThrowError(Constants.LABEL_UNKNOWN_COMMAND + " " + parameter);
                }
            }
        }
    }
}
