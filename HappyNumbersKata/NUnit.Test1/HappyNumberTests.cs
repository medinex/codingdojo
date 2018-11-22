using NUnit.Framework;
using HappyNumbersKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyNumbersKata.Tests
{
    [TestFixture()]
    public class HappyNumberTests
    {
        [Test()]
        public void SplitNumberTest()
        {
            var happy = new HappyNumber();
            var arr = happy.SplitNumber(123);
            var expected = new int[] { 1, 2, 3 };

            Assert.That(arr.Count(), Is.EqualTo(3));
            Assert.That(arr, Is.EqualTo(expected));
        }
    }
}