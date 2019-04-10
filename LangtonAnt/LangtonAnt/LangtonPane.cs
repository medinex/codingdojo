// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace LangtonAnt
{
    public class LangtonPane
    {
        public LangtonPane(int v1, int v2)
        {
            this.Width = v1;
            this.Height = v2;
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public bool GetColor()
        {
            throw new NotImplementedException();
        }
    }
}