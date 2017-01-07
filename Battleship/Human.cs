using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Human : Player
    {

        public Human(OutputManager oManager, Game game) : base(ref oManager, game) { }

        public void PlaceShip(string[] parameter)
        {
            Console.WriteLine("human place ship");
        }

    }
}
