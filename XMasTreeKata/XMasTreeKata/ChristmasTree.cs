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
        public int Height { get; set; }

        public bool StarOnTop { get; set; }

        public ChristmasTree(int height, bool star)
        {
            Height = height;
            StarOnTop = star;
        }

        List<string> _drawnTree = new List<string>();

        public IList<string> Draw()
        {
            if (StarOnTop)
            {
                var offset = Enumerable.Repeat(' ', (Height) + 1).ToList();
                offset.AddRange("¤");
                _drawnTree.Add(string.Join(string.Empty, offset));
            }

            for (int i = 0; i < Height; i++)
            {
                var offset = Enumerable.Repeat(' ', (Height - i ) + 1).ToList();
                var value = Enumerable.Repeat('█', (i * 2) + 1);
                offset.AddRange(value);
                _drawnTree.Add(string.Join(string.Empty, offset));
            }

            var offset2 = Enumerable.Repeat(' ', (Height) + 1).ToList();
            offset2.AddRange("█");
            _drawnTree.Add(string.Join(string.Empty, offset2));

            return _drawnTree;
        }

        public List<string> DrawInBlock(int maxWidth, int maxHeight)
        {

            var list = new List<string>();
            var tree = Draw();

            for (int i = 0; i < maxHeight - Height; i++)
            { 
                list.Add(new string(Enumerable.Repeat(' ', maxWidth).ToArray()));
            }

            var offset = new string(Enumerable.Repeat(' ', (maxWidth - GetWidth()) / 2).ToArray());
            foreach ( var l in tree )
            {
                list.Add(offset + l);
            }

            return list;

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
