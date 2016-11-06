using System.Collections.Generic;

namespace Battleship
{
    static class Constants
    {
        public const string EXIT = "exit";
        public const string HELP = "help";
        public const string PLACE = "place";
        public const string SHOOT = "shoot";
        public const string SHOW = "show";

        public const string STATUS_ERROR = "sdfsdf";


        public const string PARA_BOARD = "board";
        public const string PARA_SHIPS = "ships";

        public const string DESC_EXIT = "Quits the application.";
        public const string DESC_HELP = "Shows all valid commands. Use help <command> to see get more details.";
        public const string DESC_PLACE = "Places a ship on the board. Takes up to three parameter <shiptype startposition endposition>. Only shiptype is required.";
        public const string DESC_PLACE_SHORT = "Use the place command like: place b";
        public const string DESC_SHOOT = "Shoot at a given position. Takes X- and Y-axis <x y>.";

        public const string AIRCRAFT_CARRIER = "Aircraft Carrier";
        public const string BATTLESHIP = "Battleship";
        public const string CRUISER = "Cruiser";
        public const string DESTROYER = "Destroyer";

        public const string HEADLINE_LIST = "List of all commands:";

        public const string LABEL_ERROR = "An error occurred:";
        public const string LABEL_UNKNOWN_COMMAND = "Unknow command";

        public const string HEADLINE_List = "List of all commands:";
        public const string DESC_EXfIT = "sdfsdf";

        public static Dictionary<string, string> commands = new Dictionary<string, string>()
        {
            { EXIT, DESC_EXIT },
            { HELP, DESC_HELP },
            { PLACE, DESC_PLACE },
            { SHOOT, DESC_SHOOT },
        };
    }
}
