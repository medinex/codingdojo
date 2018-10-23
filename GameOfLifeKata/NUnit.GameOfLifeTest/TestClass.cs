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
            gof.Evolve();
            Boolean is_alive = gof.IsCellAlive(5, 2);


            Assert.IsFalse(is_alive);
        }

        [Test]
        public void TestIfMoreThanThree()
        {
            var gof = new GameOfLife(8, 4);
            gof.AddLivingCell(5, 2);
            gof.AddLivingCell(5, 3);
            gof.AddLivingCell(4, 2);
            gof.AddLivingCell(5, 1);
            gof.AddLivingCell(6, 2);
            gof.Evolve();
            bool is_alive = gof.IsCellAlive(5, 2);


            Assert.That(is_alive, Is.False);
        }

        [Test]
        public void TestWithExactlyThree()
        {
            var gof = new GameOfLife(8, 4);
            gof.AddLivingCell(5, 1);
            gof.AddLivingCell(5, 2);
            gof.AddLivingCell(4, 2);
            gof.Evolve();
            bool is_alive = gof.IsCellAlive(4, 1);


            Assert.That(is_alive, Is.True);
        }

        [Test]
        public void TestWithExactThreeNeighbours()
        {
            var gof = new GameOfLife(4, 4);
            gof.AddLivingCell(0, 0);
            gof.AddLivingCell(0, 1);
            gof.AddLivingCell(1, 1);
            gof.AddLivingCell(1, 0);

            int count = gof.GetLivingNeighboursCount(0, 0);
            Assert.That(count, Is.EqualTo(3));
        }


        [Test]
        public void TestIfDeadCellGoesAlive()
        {
            var gof = new GameOfLife(4, 4);
            gof.AddLivingCell(0, 0);
            gof.AddLivingCell(2, 0);
            gof.AddLivingCell(1, 1);
            gof.Evolve();

            bool is_alive = gof.IsCellAlive(1, 0);
            Assert.That(is_alive, Is.True);
        }


    }
}
