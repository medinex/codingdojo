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
        List<string> _drawnTree = new List<string>();

        public IList<string> Draw( int treeSize, bool star)
        {

            if (star)
            {
                var offset = Enumerable.Repeat(' ', (treeSize) + 1).ToList();
                offset.AddRange("¤");
                _drawnTree.Add(string.Join(string.Empty, offset));
            }

            for (int i = 0; i < treeSize; i++)
            {
                var offset = Enumerable.Repeat(' ', (treeSize - i ) + 1).ToList();
                var value = Enumerable.Repeat('█', (i * 2) + 1);
                offset.AddRange(value);
                _drawnTree.Add(string.Join(string.Empty, offset));
            }

            var offset2 = Enumerable.Repeat(' ', (treeSize) + 1).ToList();
            offset2.AddRange("█");
            _drawnTree.Add(string.Join(string.Empty, offset2));

            return _drawnTree;
        }

        public int GetHeight()
        {
            return _drawnTree.Count();
        }

        public int GetWidth()
        {
            int max = 0;
            foreach (var l in _drawnTree)
                if (l.Length > max)
                    max = l.Length;

            return max;
        }
        
    }




}
