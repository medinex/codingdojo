using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicCalculatorExample;


namespace NUnit.TestBasicCalculator
{
    [TestFixture]
    public class TestBasicCalculator
    {
        [Test]
        public void TestSimpleIntegerAddition()
        {
            var c = new Calculator();
            Assert.AreEqual(3, c.Addition(1, 2));
            //Assert.Pass("Your first passing test");
        }

        [Test]
        public void TestSimpleIntegerAddition2()
        {
            var c = new Calculator();
            Assert.AreEqual(11, c.Addition(5, 6));
            //Assert.Pass("Your first passing test");
        }

        [Test]
        public void TestSimpleIntegerAddition3()
        {
            var c = new Calculator();
            Assert.AreEqual(-3, c.Addition(-1, -2));
            //Assert.Pass("Your first passing test");
        }

        [Test]
        public void TestSimpleIntegerAddition4()
        {
            var c = new Calculator();
            Assert.AreEqual(-1, c.Addition(1, -2));
            //Assert.Pass("Your first passing test");
        }
    }
}
