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

            
            foreach (var item in c.Draw(5, true))
            {
                Console.WriteLine(item);
            }

            var currenPos =  Tuple.Create(0,0);
            var random = new Random();
            for (int treeCount = 0; treeCount < 5; treeCount++)
            {               
                var randomSize = random.Next(2, 10);
                var str = c.Draw(randomSize, true);
                foreach (var item in str)
                {
                    i++;
                    var leftPos = Console.CursorLeft;
                    Console.SetCursorPosition(currenPos.Item2, currenPos.Item1 + i);
                    Console.WriteLine(item);
                }

                currenPos = Tuple.Create(randomSize + currenPos.Item2, str.Count + currenPos.Item1);

                Console.ReadKey();
            }

        }

        public string buildTree()
        {

            return "";
        }

    }
}
