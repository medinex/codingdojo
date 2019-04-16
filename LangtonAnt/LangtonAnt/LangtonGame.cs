// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace LangtonAnt
{
    public class Game
    {
        public Game()
        {
        }

        public Map CreateMap(int width, int height)
        {
            return new Map(width, height);
        }
    }
}