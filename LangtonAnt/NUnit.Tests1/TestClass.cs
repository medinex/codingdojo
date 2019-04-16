// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using LangtonAnt;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void CheckCreatePlaneWillHaveCorrectDimension()
        {
            var game = new Game();
            var pane = game.CreateMap(3, 3);

            Assert.That(pane.Width, Is.EqualTo(3));
            Assert.That(pane.Height, Is.EqualTo(3));
        }

        [Test]
        public void CheckCreatePlaneWillHaveColors()
        {
            var langtonAnt = new Game();
            var pane = langtonAnt.CreateMap(3, 3);


            
            Assert.That(pane.GetColor(), Is.AnyOf(Colors.Black, Colors.White));
            
        }

        //needed to pass Point.Construct as parameter
        private class TestStuff
        {
            public static IEnumerable Tests()
            {
                yield return new TestCaseData(90, Colors.Black, Point.Construct(5, 5), 0, Colors.White, Point.Construct(5, 6));
                yield return new TestCaseData(90, Colors.White, Point.Construct(5, 5), 180, Colors.Black, Point.Construct(5, 4));
          
            }
        }

        [TestCaseSource(typeof(TestStuff), nameof(TestStuff.Tests))]
        public void CheckAntCanMove(
            int degree, 
            Colors color, 
            Point ptIn, 
            int expectedDegree, 
            Colors expectedColor,
            Point ptOut)
        {
            var ant = new Ant();
            ant.Coordinate = ptIn;
            ant.Angle = degree;
            var rcolor = ant.Move(color);

            Assert.That(ant.Coordinate, Is.EqualTo(ptOut));
            Assert.That(ant.Angle, Is.EqualTo(expectedDegree));
            Assert.That(rcolor, Is.EqualTo(expectedColor));

        }
    }
}
