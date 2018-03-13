using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	/*
     * Class for the Ship behaviour
     * @author Stanislav Yurchenko
     * @version 21/11/2017
     */
	[Serializable]
	public class Ship
    {
        // length of the ship
        private int length;
        // ship picture resource
        private String path;
        private String altPath;
        // ship designation
        private String Name;
        // boolean array for parts of ship that are either hit or not, 0 being the head
        private bool[] hit;
        // array of coordinates on which the ship is found
        private int[] coordinates;
        // array of coordinates around the ship, where nothing can be put and that check off automatically when ship is sunk;
        private int[] frame;
        // true if the ship is vertical
        private bool vertical = false;
        public Ship(String Name)
        {

            if (Name.Equals("Carrier"))
            {
                length = 5;
                hit = new bool[length];
                this.Name = Name;
                path = @"Resources\Carrier.png";
                altPath = @"Resources\Carrier90.png";
            }
            else if (Name.Equals("Battleship"))
            {
                length = 4;
                hit = new bool[length];
                this.Name = Name;
                path = @"Resources\Battleship.png";
                altPath = @"Resources\Battleship90.png";
            }
            else if (Name.Equals("Cruiser"))
            {
                length = 3;
                hit = new bool[length];
                this.Name = Name;
                path = @"Resources\Cruiser.png";
                altPath = @"Resources\Cruiser90.png";
            }
            else if (Name.Equals("Submarine"))
            {
                length = 3;
                hit = new bool[length];
                this.Name = Name;
                path = @"Resources\Submarine.png";
                altPath = @"Resources\Submarine90.png";
            }
            else if (Name.Equals("Destroyer"))
            {
                length = 2;
                hit = new bool[length];
                this.Name = Name;
                path = @"Resources\Destroyer.png";
                altPath = @"Resources\Destroyer90.png";
            }
            else
            {
                throw new ArgumentException("Valid values for a ship are Destroyer, Submarine, Cruiser, Battleship and Carrier");
            }
        }

        public bool Vertical { get => vertical; set => vertical = value; }
        public int[] Coordinates { get => coordinates; set => coordinates = value; }
        public int[] Frame { get => frame; set => frame = value; }

        /*
        * Method sets the appropriate part of the ship to hit
        * @param position - coordinate of the ship to hit
        * @author Stanislav Yurchenko
        * @version 04/12/2017
        */
        public void HitShip(int position)
        {
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (coordinates[i] == position)
                {
                    hit[i] = true;
                    
                }
            }
        }
        /*
         * Method runs through the hit parts to see whether the ship is sunk yet
         * @author Stanislav Yurchenko
         * @version 21/11/2017
         * @return true if the ship was sunk
         */
        public bool SinkShip()
        {
            bool sunk = true;
            foreach (bool hitPart in hit)
            {
                if (hitPart == false)
                {
                    sunk = hitPart;
                }
            }
            return sunk;
        }
        /*
         * Method returns reference to 
         * @author Stanislav Yurchenko
         * @version 03/12/2017
         * @return String of path to ship image file
         */
        public String GetPath()
        {
            if (this.Vertical)
            {
                return altPath;
            }
            else
            {
                return path;
            }
        }
        /*
         * Accessor for the Name of ship
         * @author Stanislav Yurchenko
         * @version 02/12/2017
         */
        public String GetName()
        {
            return Name;
        }
        /*
         * Accessor for the Length of ship
         * @author Stanislav Yurchenko
         * @version 02/12/2017
         */
        public int GetLength()
        {
            return length;
        }
        /*
         * Checks if the select position will overlap with another ship or its surroundings
         * @author Stanislav Yurchenko
         * @version 04/12/2017
         * @return true if there is an overlap or touching, false if clear
         */
        public bool Overlap(int position, bool touchCheck)
        {
            // Looks for overlap
            foreach (int i in this.coordinates)
            {
                if (i == position)
                {
                    return true;
                }
            }
            // Looks for touching
            if (touchCheck && Frame != null)
            {
                foreach (int i in this.Frame)
                {
                    if (i == position)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /*
         * Generates a frame around a ship so that no other ships can be directly adjacent to it
         * @author Stanislav Yurchenko
         * @version 04/12/2017
         */
        public void GenerateFrame()
        {
            List<int> points = new List<int>();
            int row = (coordinates[0] / 10) - 1;
            int column = (coordinates[0] % 10) - 1;
            if (this.Vertical)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < coordinates.Length + 2; j++)
                    {
                        if (row + j >= 0 && row + j < 10 && column + i >= 0 && column + i < 10 && !Overlap((row + j) * 10 + (column + i), false))
                        {
                            points.Add((row + j) * 10 + (column + i));
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < coordinates.Length + 2; j++)
                    {
                        if (row + i >= 0 && row + i < 10 && column + j >= 0 && column + j < 10 && !Overlap((row + i) * 10 + (column + j), false))
                        {
                            points.Add((row + i) * 10 + (column + j));
                        }
                    }
                }
            }
            Frame = points.ToArray();
        }
    }
}
