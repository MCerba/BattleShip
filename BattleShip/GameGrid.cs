using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleShip
{
	[Serializable]
	public class GameGrid
    {
        public bool[] hitLabels;
        public Ship[] ships;
        public GameGrid()
        {
            this.ships = new Ship[] { new Ship("Carrier"), new Ship("Battleship"), new Ship("Cruiser"), new Ship("Submarine"), new Ship("Destroyer") };
            this.hitLabels = new bool[100];
        }
        /*
         * Method tries to add ship to board
         * @author Stanislav Yurchenko
         * @version 03/12/2017
         */
        public void AddShip(Ship s, int row, int column)
        {
            int[] coordinates = new int[s.GetLength()];
            // check if vertical ship is too close to bottom
            if (s.Vertical && row + s.GetLength() > 10)
            {
                throw new IndexOutOfRangeException("Too close to border");
                // check if horizontal ship is too close to right side
            }
            else if (!s.Vertical && column + s.GetLength() > 10)
            {
                throw new IndexOutOfRangeException("Too close to border");
            }
            // Find every coordinate for ship and assign them to the property as long as they don't overlap
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] = row * 10 + column;
                foreach (Ship boat in ships)
                {
                    if (boat.Coordinates != null && !s.GetName().Equals(boat.GetName()) && boat.Overlap(coordinates[i], true))
                    {
                        s.Coordinates = null;
                        throw new IndexOutOfRangeException("Overlaps with other ship");
                    }
                }
                if (s.Vertical)
                {
                    row++;
                }
                else
                {
                    column++;
                }
            }
            s.Coordinates = coordinates;
            s.GenerateFrame();

        }
        /*
         * Method checks a spot on the grid
         * @author Stanislav Yurchenko
         * @version 04/12/2017
         * @return false if the spot was never hit or true if the spot was already hit
         */
        public bool Hit(int row, int column)
        {
			if (row < 0 || row > 9 || column < 0 || column > 9)
			{
				return true;
			}

            int coordinates = row * 10 + column;
            return hitLabels[coordinates];
        }
        /*
         * Method hits a spot on the grid
         * @author Stanislav Yurchenko
         * @version 04/12/2017
         * @return true if a ship was hit, null if sunk and false if the shot missed
         */
        public bool? Shot(int row, int column)
        {
			if (row < 0 || row > 9 || column < 0 || column > 9)
			{
				MessageBox.Show(" row is " + row + " rcolumnow is " + column);
			}
			int coordinates = row * 10 + column;
            bool? damage = false;
            hitLabels[coordinates] = true;
            foreach (Ship boat in ships)
            {
                if (boat.Overlap(coordinates, false))
                {
                    boat.HitShip(coordinates);
                    damage = true;
                    if (boat.SinkShip() == true)
                    {
                        damage = null;
                        Explode(boat);
                    }
                }
            }
            return damage;
        }
        /*
         * Uncover surrounding fields of ship once it sinks
         * @author Stanislav Yurchenko
         * @version 06/12/2017
         */
        public void Explode(Ship s)
        {
            foreach (int i in s.Frame)
            {
                if (!hitLabels[i])
                {
                    hitLabels[i] = true;
                }
            }
        }
        /*
		 * Method runs through the list of ships and returns whether they all have a location
		 * @author Stanislav Yurchenko
		 * @version 05/12/2017
		 * @returns true if all ships were placed, false if some ships remain to be placed
		 */
        public bool ShipsPlaced()
        {
            bool placed = true;
            foreach (Ship s in ships)
            {
                if (s.Coordinates == null)
                {
                    placed = false;
                    break;
                }
            }
            return placed;
        }
        /*
         * Automatically and randomly places ships.
         * @author Stanislav Yurchenko
         * @version 05/12/2017
         */
        public void SetShips()
        {
            Random r = new Random();
            foreach (Ship s in ships)
            {
                while (s.Coordinates == null)
                {
                    try
                    {
                        if (r.Next(0, 2) == 0)
                        {
                            s.Vertical = false;
                        }
                        else
                        {
                            s.Vertical = true;
                        }
                        int a = r.Next(0, 9);
                        int b = r.Next(0, 9);
                        this.AddShip(s, a, b);
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                }
            }
        }
    }
}
