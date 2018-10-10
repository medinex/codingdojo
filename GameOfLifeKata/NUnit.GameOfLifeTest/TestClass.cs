using GameOfLifeKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.GameOfLifeTest
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestIfLessThanTwo()
        {
            var gof = new GameOfLife(8,4);
            gof.AddLivingCell(5,2);
            //gof.AddLivingCell(4,3);
            //gof.AddLivingCell(5,3);
            gof.Evolve();
            Boolean is_alive = gof.IsCellAlive(5, 2);


            Assert.IsFalse(is_alive);
        }
    }
}
