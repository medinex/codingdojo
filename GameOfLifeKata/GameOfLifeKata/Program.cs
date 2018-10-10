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
            var gof = new GameOfLife(8, 4);
            gof.AddLivingCell(5, 2);
            //gof.AddLivingCell(4,3);
            //gof.AddLivingCell(5,3);
            gof.Evolve();
            gof.Output();
        }
    }
}
