using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMasTreeKata
{
    public class ChristmasTree
    {
        public IList<string> Draw( int treeSize, bool star)
        {
            List<string> drawnTree = new List<string>();

            if (star)
            {
                var offset = Enumerable.Repeat(' ', (treeSize) + 1).ToList();
                offset.AddRange("¤");
                drawnTree.Add(string.Join(string.Empty, offset));
            }

            for (int i = 0; i < treeSize; i++)
            {
                var offset = Enumerable.Repeat(' ', (treeSize - i ) + 1).ToList();
                var value = Enumerable.Repeat('█', (i * 2) + 1);
                offset.AddRange(value);
                drawnTree.Add(string.Join(string.Empty, offset));
            }

            var offset2 = Enumerable.Repeat(' ', (treeSize) + 1).ToList();
            offset2.AddRange("█");
            drawnTree.Add(string.Join(string.Empty, offset2));

            return drawnTree;
        }
    }




}
