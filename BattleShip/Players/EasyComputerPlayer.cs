using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    /*
    Intance class for all Computer players
    @author CerbaM
    */
	[Serializable]
    class EasyComputerPlayer : Player
    {

        public EasyComputerPlayer()
        {
            Name = "EasyComputerPlayer";
            GameGrid = new GameGrid();
            GameGrid.SetShips();
            Opponent = null;
        }


        public override void Turn()
        {
            this.RandomShot();
        }
    }
}
