using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMasTreeKata
{
    public class WinterWonderland
    {
        List<ChristmasTree> _forest = new List<ChristmasTree>();

        internal void Draw()
        {
            int maxHeight = _forest.Max(t=> t.GetHeight());
            int maxWidth = _forest.Max(s => s.GetWidth());

            var builder = new StringBuilder();
            foreach (var tree in _forest)
            {
                var listOfTreeElements = tree.DrawInBlock(maxWidth, maxHeight);

                foreach (var item in listOfTreeElements)
                {
                    builder.AppendLine(item);
                }

    
                var currentWidth = tree.GetWidth();
                builder.AppendLine();
            }

            Console.WriteLine(builder);
            Console.ReadKey();
            
        }

        internal void Add(ChristmasTree c)
        {
            _forest.Add(c);
        }
    }
}
