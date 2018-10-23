using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeKata
{
    class Program
    {
        private List<List<int>> _myLife = new List<List<int>>();
        static void Main(string[] args)
        {
            var gof = new GameOfLife(8, 8);
            gof.AddLivingCell(5, 5);
            gof.AddLivingCell(5, 6);
            gof.AddLivingCell(5, 7);

            gof.Output();
        }
    }
}
