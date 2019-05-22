using System;
using NUnit.Framework;
using DepthFirstSearch;
using System.Collections;

namespace DepthFirstSearchTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void AskingWhereWeAreShouldReturnPosition()
        {
            var problem = new Problem();
            var whatever = new KataSearch(problem);
            var position = whatever.WhereAmI();

            Assert.That(position, Is.EqualTo(1));
        }

        [TestCaseSource(typeof(TestSource), nameof(TestSource.Tests))]

        public void AskingWhereCanIGoShouldReturnNull(Problem problem, object foundObject)
        {
            var whatever = new KataSearch(problem);
            var nextPath = whatever.WhereCanIGo();

            Assert.That(nextPath, Is.EqualTo(foundObject));
        }

        private class TestSource
        {
            public static IEnumerable Tests()
            {
                yield return new TestCaseData(new Problem(), null);
            }
        }

    }


}
