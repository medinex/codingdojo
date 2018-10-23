using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public int GetLivingNeighboursCount(int checkX, int checkY)
        {
            int count = 0;
            for (int x = Math.Max(checkX - 1, 0); x <= Math.Min(_matrix.GetLength(0)-1, checkX+1); x++)
            {
                for (int y = Math.Max(checkY - 1, 0); y <= Math.Min(_matrix.GetLength(1)-1, checkY+1); y++)
                {
                    if (!(x == checkX && y == checkY) && _matrix[x, y] == 1)
                        count++;
                }
            }
            return count;
        }

        public bool IsEmpty()
        {
            int cnt = 0;
            for (int y = 0; y < _matrix.GetLength(1); y++)
            {
                for (int x = 0; x < _matrix.GetLength(0); x++)
                {
                    if (_matrix[x, y] > 0)
                        cnt++;
                }
            }

            return cnt <= 0;
        }

            public void Evolve()
        {
            var temp = _matrix.Clone() as int[,];
            
            for (int y = 0; y < _matrix.GetLength(1); y++)
            {
                for (int x = 0; x < _matrix.GetLength(0); x++)
                {
                    var nei = GetLivingNeighboursCount(x, y);
                    if (nei < 2 || nei > 3) {
                        temp[x, y] = 0;
                    }
                    else if (nei ==3)
                    {
                        temp[x, y] = 1;
                    }
                    /*else
                    {
                        temp[x,y] = 
                    }*/

                }
            }

            _matrix = temp;
        }
    

        public void Output()
        {
            for (int j = 0; j < 10; j++)
            {
                for (int y = 0; y < _matrix.GetLength(1); y++)
                {
                    var lifeLine = new StringBuilder();
                    for (int x = 0; x < _matrix.GetLength(0); x++)
                    {
                        //lifeLine.Append(GetLivingNeighboursCount(x, y).ToString());
                        lifeLine.Append(_matrix[x, y] == 0 ? "█" : "░");
                        
                    }
                    Console.WriteLine(lifeLine);
                }

                if (!IsEmpty())
                    Console.ReadLine();
                //Thread.Sleep(1000);
                Console.Clear();
                Evolve(); 
            }
        }

    }
}
