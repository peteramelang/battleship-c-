﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Ship
    {
        int length;
        int[][] coordinates = new int[][] { };
        Constants.SHIP_STATUS status;
        public string type;
        public Player owner;

        public Ship(string shipType, Player owner)
        {
            type = shipType;
            length = Constants.SHIP_LENGTHS[shipType];
            this.owner = owner;
            status = Constants.SHIP_STATUS.NEW;
        }

        public void SetCoordinates(int[][] shipToPlaceCoordinates)
        {
            coordinates = shipToPlaceCoordinates;
        }

        public int[][] GetCoordinates()
        {
            return coordinates;
        }

        public int GetLength()
        {
            return length;
        }

        public int[,] GetDamagedParts()
        {
            return new int[,] { };
        }

        public bool IsSet()
        {
            return coordinates.Length > 0 && coordinates != null;
        }

        public override string ToString()
        {
            return type;
        }

    }
}
