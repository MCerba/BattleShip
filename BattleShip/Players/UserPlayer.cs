using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	/*
    Intance class for all players
    @author CerbaM
    */
	[Serializable]
	public class UserPlayer : Player
    {
        public UserPlayer(string name)
        {
            Name = name;
            GameGrid = new GameGrid();
            Opponent = null;
        }

        //Ctor which set opponent
        public UserPlayer(string name,Player opponent) : this( name)
        {
            Opponent = opponent;
        }

        public override void Turn()
        {
            RandomShot();
        }
    }
}
