using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	[Serializable]
    class HardComputerPlayer : NormalComputerPlayer
    {
        public HardComputerPlayer()
        {
            Name = "HardComputerPlayer";
            GameGrid = new GameGrid();
			GameGrid.SetShips();
			Opponent = null;
            inHuntmode = true;
			targets = new List<int[]> { };
			hitVerticalShip = null;
		}

        //turn behaviour
        public override void Turn()
        {
            if (this.inHuntmode == true)
            {
                this.PseudoRandomShot();
            }
            else
                this.TargetShot();
        }

        //Still Random, but without half of targets
        private void PseudoRandomShot()
        {
            int x;
            int y;
            do
            {
                x = r.Next(0, 10);
                if (x / 2 == 0)
                {
                    y = r.Next(0, 9);
                    //if (y / 2 == 0) y += 1;
                    y = (y / 2 == 0) ? y + 1 : y; 
                }
                else
                {
                        y = r.Next(1, 10);
                        //if (y / 2 != 0) y -= 1;
                        y = (y / 2 == 0) ? y - 1 : y;
                }

            } while (Opponent.GameGrid.Hit(x, y));

            //if FireShot return true(ship was hitted) change computer mode from  Hunt(inHuntmode = true) to Target (inHuntmode = true) 

            answerFireShot = FireShot(x, y);
            if (answerFireShot == true)
            {


                if (!Opponent.GameGrid.Hit(x - 1, y)) this.targets.Add(new int[] { x - 1, y });
                if (!Opponent.GameGrid.Hit(x, y + 1)) this.targets.Add(new int[] { x, y + 1 });
                if (!Opponent.GameGrid.Hit(x + 1, y)) this.targets.Add(new int[] { x + 1, y });
                if (!Opponent.GameGrid.Hit(x, y - 1)) this.targets.Add(new int[] { x, y - 1 });
                this.firstHit = new int[] { x, y };
                this.inHuntmode = false;
            }
        }

    }
}
