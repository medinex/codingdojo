using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeKata
{
    public class GameOfLife
    {
        int[,] _matrix;

        public GameOfLife(int x, int y)
        {
            _matrix = new int[x,y];
        }

        public void AddLivingCell(int x, int y)
        {
            _matrix[x, y] = 1;
        }

        public bool IsCellAlive(int x, int y)
        {
            return _matrix[x, y]>0;
        }

        public void Evolve()
        {

        }

        public void Output()
        {
            for( int x = 0; x < _matrix.GetLength(1); x++)
            {
                var lifeLine = new StringBuilder();
                for ( int y = 0; y < _matrix.GetLength(0); y++ )
                {
                    lifeLine.Append(_matrix[x, y] == 0 ? "." : "*");
                }
                Console.WriteLine(lifeLine);
            }
            Console.ReadKey();
        }

    }
}
