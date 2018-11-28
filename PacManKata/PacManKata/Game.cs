using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKata
{
    public class Game
    {
        Level _level = new Level();
        Board _board;

        public Game()
        {
            _board = new Board(_level);
        }

        public string Show()
        {
            Console.Clear();
            return _board.Level.Show();
        }
    }
}
