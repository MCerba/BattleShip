using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    interface IPlayer
    {
        Boolean? FireShot(int x, int y);
        void RandomShot();
        void SetOpponent(Player player);
        void Turn();

    }
}
