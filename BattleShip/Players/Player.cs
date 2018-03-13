using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	/*
    abstract class for all players
    @author CerbaM
    */
	[Serializable]
	public abstract class Player : IPlayer
    {

        private String name;
        public String Name
        {
            get {return name;}
            set
            {
                if (value == "")
                {
                    name = "Default Player";
                }
                else
                {
                    name = value;
                }
            }

        }
        public Random r = new Random();
        public Player Opponent { get; set; }
        public GameGrid GameGrid { get; set; }
        public int wins = 0;
        public int losses = 0;


        /*
         * call Shot() method on  Opponent's GameBoard
         * @param int x,y - coordinates of shot
         * @return Boolean? - MISS = false, HIT = true, KILL = null
         */
        public Boolean? FireShot(int x, int y)
        {
            return Opponent.GameGrid.Shot(x, y);
        }


        /* implements completely Random shot 
         * Check if GameBoard was not hitted before and cals Hit(a,b) method on  Opponent's GameBoard
         * 
         */
        public virtual void RandomShot()
        {
            int a;
            int b;
            do
            {
                a = r.Next(0, 10);
                b = r.Next(0, 10);
            } while (Opponent.GameGrid.Hit(a,b));

            FireShot(a, b);
        }

        /*set particular Opponent to this player
         * @param Player - particular player to use like opponent
         * 
         */
        public void SetOpponent(Player player)
        {
            Opponent = player;
        }
		public bool Win()
		{
			bool winbool = true;
			foreach (Ship s in Opponent.GameGrid.ships)
			{
				if (!s.SinkShip())
				{
					winbool = false;
					break;
				}
			}
			return winbool;
		}

        public void gameWon()
        {
            this.wins++;
        }

        public void gameLost()
        {
            this.losses++;
        }

        public int getWins()
        {
            return this.wins;
        }

        public int getLosses()
        {
            return this.losses;
        }

        public abstract void Turn();

    }
}
