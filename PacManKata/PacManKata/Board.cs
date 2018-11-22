using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKata
{
    public class Board
    {
        BoardElement[,] grid;
        String dot;
        String wall;
        Actor actor;

        public Board(int x, int y)
        {
            grid = new BoardElement[x, y];
            InitLevet1();
        }

        private void InitLevet1()
        {

            var level1 = new char[,]
            {
                { '╔', '═' },
                { '╔', '═' },
            };
            //this = level1;



        }

        //public operator = (char[,])
        //    {
        //    }

        public void tick( int inputKey)
        {

        }
    }
}
