using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMasTreeKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = 0;
            int minSize = 10;
            int maxSize = 20;
            int xPos = 3;
            int yPos = maxSize + 1;

            var currenPos = Tuple.Create(0, 0);
            var random = new Random();

            var ww = new WinterWonderland();
            for (int treeCount = 0; treeCount < 5; treeCount++)
            {
                var randomSize = random.Next(minSize, maxSize);
                var c = new ChristmasTree(randomSize, true);
                var tree = c.Draw();
                ww.Add(c);
                   

            }
                ww.Draw();

            Console.ReadKey();
        }

       

    }
}
