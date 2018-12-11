using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManKata
{
    public class Level
    {
        BoardElement[,] _grid;

        public Level()
        {
            var level1 = new char[,]
            {
                { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
                { 'w', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', 'W' },
                { 'w', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', 'W' },
                { 'w', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', 'W' },
                { 'w', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', 'W' },
                { 'w', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', 'W' },
                { 'w', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', 'W' },
                { 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w' },
            };

            _grid = new BoardElement[level1.GetLength(0), level1.GetLength(1)];

            for (int x = 0; x < level1.GetLength(0); x++)
                for (int y = 0; y < level1.GetLength(1); y++)
                    _grid[x, y] = new BoardElement(level1[x, y]);
        }

        internal void SetContent(BoardElement boardElement, int x, int y)
        {
            _grid[x, y] = boardElement;
        }

        internal int GetMiddleY()
        {
            return (_grid.GetLength(1) / 2);
        }

        internal int GetMiddleX()
        {
            return(_grid.GetLength(0)/2);
        }

        internal string Show()
        {
            var o = new StringBuilder();

            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                for (int y = 0; y < _grid.GetLength(1); y++)
                {
                    o.Append(_grid[x, y].Representation);
                }
                o.Append(Environment.NewLine);
            }

            return o.ToString();
        }

        public BoardElement[,]  getContent()
        {
            return _grid;
        }
    }
}
