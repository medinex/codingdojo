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
            var c = new ChristmasTree();
            var i = 0;
            int minSize = 3;
            int maxSize = 10;
            int xPos = 3;
            int yPos = maxSize + 1;

            var currenPos = Tuple.Create(0, 0);
            var random = new Random();

            var ww = new WinterWonderland();
            for (int treeCount = 0; treeCount < 5; treeCount++)
            {
                var randomSize = random.Next(minSize, maxSize);
                var tree = c.Draw(randomSize, true);
                ww.Add(c);
                   

            }
                ww.Draw();

            Console.ReadKey();
        }

       

    }
}
