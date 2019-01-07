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
            var maxHeight = _forest.Max(t=> t.GetHeight());
            var maxWidth = _forest.Max(s => s.GetWidth());

            var builder = new StringBuilder();
            foreach (var tree in _forest)
            {
                for (int i = 0; i < maxHeight; i++)
                {
                    //builder.Append(tree[i]);
                }
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
