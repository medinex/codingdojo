using NUnit.Framework;
using PacManKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void BoardShouldVaveAPacman()
        {
            int pacmen = 0;
            //Board board = new Board(0);
            //for(int x = 0; x < board.GetWidth(); x++)
            //{
            //    for (int y = 0; y < board.GetHeight(); y++)
            //    {
            //        var element = board.GetElement(x, y);
            //        if (element is Actor)
            //            pacmen++;
            //    }
            //}

            //Assert.That(pacmen, Is.EqualTo(1), $"No pacman or too many {pacmen}");
        }
    }
}
