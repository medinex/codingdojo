using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKata
{
    public class Board
    {
        private Level _level;

        public Level Level
        {
            get { return _level; }
            set { _level = value; }
        }


        public Board(Level level)
        {
            _level = level;
        }


    }
}
