using AncientEgyptianMultiplicationKata;
using NUnit.Framework;
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
        [TestCase(33, 78, 2574)]
        [TestCase(47, 42, 1974)]
        [TestCase(3, 4, 12)]
        [TestCase(1, 1, 1)]
        public void TestMethod(int x, int y, int result)
        {
            var obelix = new Obelix();
            var r = obelix.Mul(x, y);
            Assert.That(r, Is.EqualTo(result));
        }

        [TestCase(1, 0)]
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void InvadlidNumber(int x, int y)
        {
            var obelix = new Obelix();
            Assert.That(() => obelix.Mul(x, y), Throws.ArgumentException);
        }

        [Test]
        public void MultipleCalculations()
        {
            var obelix = new Obelix();
            for (int i = 1; i < 999; i++)
                for (int j = 1; j < 999; j++)
                    Assert.That(() => obelix.Mul(i, j), Is.EqualTo(i * j));
        }


    }
}
