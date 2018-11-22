using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyNumbersKata;

namespace NUnit.Test1
{
    [TestFixture]
    public class TestClass
    {
        [TestCase(19)]
        [TestCase(82)]
        [TestCase(68)]
        public void TestIsHappyNumber(int input)
        {
            HappyNumber hn = new HappyNumber();
            var result = hn.IsHappy(input);
            Assert.That(result, Is.True);
        }

        [TestCase(12)]
        [TestCase(33)]
        public void TestIsUnhappyNumber(int input)
        {
            HappyNumber hn = new HappyNumber();
            var result = hn.IsHappy(input);
            Assert.That(result, Is.False);
        }


        [TestCase(19,82)]
        [TestCase(82,68)]
        [TestCase(68,100)]
        [TestCase(100,1)]
        public void TestMakeSum(int a, int b)
        {
            HappyNumber hn = new HappyNumber();
            var result = hn.CalculateSum(hn.SplitNumber(a));
            Assert.Greater(result, 0);
            Assert.IsTrue(result==b);
        }


    }
}
