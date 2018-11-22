using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKata
{
    public class GameMaster
    {
        public bool CanMove(Actor[,] board, Actor actor, int x,int y )
        {
            return true;
        }

        public bool IsGameOver()
        {
            return false;
        }

        public bool CanEat(Actor[,] board, Actor actor, int x, int y)
        {
            return false;
        }
    }
}
