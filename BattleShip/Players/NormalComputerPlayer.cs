using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
	[Serializable]
	class NormalComputerPlayer : EasyComputerPlayer
    {
        //ComputerPlayer mod:  Huntmode(inHuntmode = true) to Targetmode (inHuntmode = false)
        public Boolean inHuntmode;
        // target Ship   can be Vertical (hitVerticalShip == true), horisontal (hitVerticalShip == false) and undefined (hitVerticalShip == null)
        public Boolean? hitVerticalShip;
        public int[] firstHit;
        public List<int[]> targets;
		public bool? answerFireShot;


		public NormalComputerPlayer()
        {
            Name = "NormalComputerPlayer";
            GameGrid = new GameGrid();
			GameGrid.SetShips();
			Opponent = null;
            inHuntmode = true;
			targets = new List<int[]> ();
			hitVerticalShip = null;

		}

        //turn behaviour
        public override void Turn() {
			if (this.inHuntmode == true)
			{
				this.RandomShot();
			}
			else
			{
				this.TargetShot();
			}
        }
        //shot first coordinates from target list
        public void TargetShot()
        {
            int x;
            int y;
            do
            {
                x = targets.ElementAt(0)[0];
                y = targets.ElementAt(0)[1];
                targets.RemoveAt(0);
            }
            while (Opponent.GameGrid.Hit(x, y));

            //FireShot return Boolean? -MISS = false, HIT = true, KILL = null
            Boolean? answer = FireShot(x, y);

            //in case of next hit  - set up Ship orientation and new targets
            if (answer == true && hitVerticalShip == null)
            {
                SetHitOreintation(x, y);
                SetNewTargets(x, y);
            }
            //in case of next MiSS - remove redundant turgets 
            else if (answer == false && hitVerticalShip != null)
            {
                if (hitVerticalShip == true)
                {
                    SkipButtomTargets();
                }
                else
                {
                    SkipRightTargets();
                }
            }
            //in case of next KILL - change to Hunt mode
            else if (answer == null)
            {
                inHuntmode = true;
                hitVerticalShip = null;
                targets = new List<int[]>();
            }

            }


        public override void RandomShot()
        {
            int x;
            int y;
            do
            {
                x = r.Next(0, 10);
                y = r.Next(0, 10);
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
        //sett orientation , depending on next hit(x,y)
        public void SetHitOreintation(int x, int y) {
            if (this.firstHit == null)
            {
                hitVerticalShip = null;
            }
            else if (this.firstHit[0] == x)
            {
                hitVerticalShip = false;
            }
            else {
                hitVerticalShip = true;
            }

        }

        //remoove old targets  + set up new , depending on hitship orientation
        public void SetNewTargets(int x, int y) {
            this.targets = new List<int[]> { };
            if (hitVerticalShip == true)
            {
                if (!Opponent.GameGrid.Hit(x + 1, y)) this.targets.Add(new int[] { x + 1, y });
                if (!Opponent.GameGrid.Hit(x + 2, y)) this.targets.Add(new int[] { x + 2, y });
                if (!Opponent.GameGrid.Hit(x + 3, y)) this.targets.Add(new int[] { x + 3, y });
                if (!Opponent.GameGrid.Hit(x + 4, y)) this.targets.Add(new int[] { x + 4, y });
                if (!Opponent.GameGrid.Hit(x - 1, y)) this.targets.Add(new int[] { x - 1, y });
                if (!Opponent.GameGrid.Hit(x - 2, y)) this.targets.Add(new int[] { x - 2, y });
                if (!Opponent.GameGrid.Hit(x - 3, y)) this.targets.Add(new int[] { x - 3, y });
                if (!Opponent.GameGrid.Hit(x - 4, y)) this.targets.Add(new int[] { x - 4, y });
            }
            else
            {
                if (!Opponent.GameGrid.Hit(x, y + 1)) this.targets.Add(new int[] { x, y + 1});
                if (!Opponent.GameGrid.Hit(x, y + 2)) this.targets.Add(new int[] { x, y + 2 });
                if (!Opponent.GameGrid.Hit(x, y + 3)) this.targets.Add(new int[] { x, y + 3 });
                if (!Opponent.GameGrid.Hit(x, y + 4)) this.targets.Add(new int[] { x, y + 4 });
                if (!Opponent.GameGrid.Hit(x, y - 1)) this.targets.Add(new int[] { x, y - 1 });
                if (!Opponent.GameGrid.Hit(x, y - 2)) this.targets.Add(new int[] { x, y - 2 });
                if (!Opponent.GameGrid.Hit(x, y - 3)) this.targets.Add(new int[] { x, y - 3 });
                if (!Opponent.GameGrid.Hit(x, y - 4)) this.targets.Add(new int[] { x, y - 4 });
            }
        }

        //remove all targets from right side of the first hit
        public void SkipRightTargets()
        {
			
            while (firstHit[1] - 1 <  targets.ElementAt(0)[1])
            {
                targets.RemoveAt(0);
            }
        }

        //remove all targets from buttom side of the first hit .
        public void SkipButtomTargets()
        {
            if (firstHit[1] != 9)
            {
                while (firstHit[0] - 1 < targets.ElementAt(0)[1])
                {
                    targets.RemoveAt(0);
                }
            }
        }



    }


}
