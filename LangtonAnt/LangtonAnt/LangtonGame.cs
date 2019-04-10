// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace LangtonAnt
{
    public class LangtonGame
    {
        public LangtonGame()
        {
        }

        public LangtonPane CreatePane(int width, int height)
        {
            return new LangtonPane(width, height);
        }
    }
}