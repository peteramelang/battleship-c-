using System.Collections.Generic;

namespace Battleship
{
    static class Constants
    {

        public const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public const string EXIT = "exit";
        public const string HELP = "help";
        public const string PLACE = "place";
        public const string SHOOT = "shoot";
        public const string SHOW = "show";

        public static Dictionary<string, string> COMMANDS = new Dictionary<string, string>()
        {
            { EXIT, DESC_EXIT },
            { HELP, DESC_HELP },
            { PLACE, DESC_PLACE },
            { SHOOT, DESC_SHOOT },
        };

        public const string STATUS_ERROR = "error";        
        public const string STATUS_REQUEST = "request";

        public const string PARA_BOARD = "board";
        public const string PARA_SHIPS = "ships";
        public const string PARA_ALL = "all";

        public const string DESC_EXIT = "Quits the application.";
        public const string DESC_HELP = "Use help <command> to learn more about a command.";
        public const string DESC_PLACE = "Places a ship on the board. Takes up to three parameter <shiptype startposition endposition>. Only shiptype is required.";
        public const string DESC_PLACE_SHORT = "Use the place command like: place b";
        public const string DESC_SHOOT = "Shoot at a given position. Takes X- and Y-axis <x y>.";

        public const string HEADLINE_LIST = "List of all commands:";

        public const string LABEL_ERROR = "An error occurred:";
        public const string LABEL_UNKNOWN_COMMAND = "Unknow command. Use help to see all commands.";
        public const string LABEL_INVALID_PARAMETER = "Invalid Parameter. Use help <command> to see all.";

        public const string AIRCRAFT_CARRIER = "Aircraft Carrier";
        public const string BATTLESHIP = "Battleship";
        public const string CRUISER = "Cruiser";
        public const string DESTROYER = "Destroyer";
        public const string EMPTY_FIELD = "";

        public static Dictionary<string, int> SHIP_LENGTHS = new Dictionary<string, int>()
        {
            { AIRCRAFT_CARRIER, 5 },
            { BATTLESHIP, 4 },
            { CRUISER, 3 },
            { DESTROYER, 2 },
        };

        public static Dictionary<string, int> SHIP_COUNT = new Dictionary<string, int>()
        {
            { AIRCRAFT_CARRIER, 1 },
            { BATTLESHIP, 1 },
            { CRUISER, 1 },
            { DESTROYER, 2 },
        };

        public static Dictionary<string, string> BOARD_SYMBOLS = new Dictionary<string, string>()
        {
            { AIRCRAFT_CARRIER, "[A]" },
            { BATTLESHIP, "[B]" },
            { CRUISER, "[C]" },
            { DESTROYER, "[D]" },
            { EMPTY_FIELD, "   " },
        };

    }
}
