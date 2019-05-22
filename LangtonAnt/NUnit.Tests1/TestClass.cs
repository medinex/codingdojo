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
            var game = new Game();
            var pane = game.CreateMap(3, 3);


            
            Assert.That(pane.GetColor(1,1), Is.AnyOf(Colors.Black, Colors.White));
            
        }

        [Test]
        public void TickShouldMoveAnt()
        {
            var game = new Game();
            var pane = game.CreateMap(3, 3);

            pane.SetColor(pane.Ant.Coordinate, Colors.Black);
            pane.Ant.Angle = 180;
            pane.Tick();

            Assert.That(pane.Ant.Angle, Is.EqualTo(90));
            Assert.That(pane.Ant.Coordinate.X, Is.EqualTo(2));
            Assert.That(pane.Ant.Coordinate.Y, Is.EqualTo(1));
        }

        [Test]
        public void TickShouldChangeColor()
        {
            var game = new Game();
            var pane = game.CreateMap(3, 3);

            var oldCoordinate = pane.Ant.Coordinate;
            var color = pane.GetCurrentColor(oldCoordinate);
            pane.Tick();

            Assert.That(pane.GetCurrentColor(oldCoordinate), Is.Not.EqualTo(color));
        }

        [Test]
        public void DrawMap()
        {
            var game = new Game();
            var pane = game.CreateMap(3, 3);

            
            for (int i = 0; i < pane.Width; i++)
            {
                for (int j = 0; j < pane.Height; j++)
                {
                    var color = pane.GetColor(i, j);
                    Assert.That(color, Is.AnyOf(Colors.Black, Colors.White));


                }
            }

        }

        [Test]
        public void CheckOutOfBounds()
        {
            var game = new Game();
            var pane = game.CreateMap(5,5);


            pane.Ant.Coordinate = Point.Construct(0, 0);
            pane.Ant.Angle = 270;
            pane.SetColor(0, 0, Colors.White);

            pane.Tick();

            Assert.That(pane.Ant.Coordinate.X, Is.EqualTo(0));
            Assert.That(pane.Ant.Coordinate.Y, Is.EqualTo(4));
        }

        //needed to pass Point.Construct as parameter
        private class TestStuff
        {
            public static IEnumerable Tests()
            {
                yield return new TestCaseData(90, Colors.Black, Point.Construct(5, 5), 0, Colors.White, Point.Construct(5, 4));
                yield return new TestCaseData(90, Colors.White, Point.Construct(5, 5), 180, Colors.Black, Point.Construct(5, 6));
                yield return new TestCaseData(180, Colors.White, Point.Construct(2, 2), 270, Colors.Black, Point.Construct(1, 2));
                yield return new TestCaseData(0, Colors.Black, Point.Construct(0, 0), 270, Colors.White, Point.Construct(9, 0));
          
            }
        }

        [TestCaseSource(typeof(TestStuff), nameof(TestStuff.Tests))]
        public void CheckAntCanMove(
            int degree, 
            Colors inputColor, 
            Point ptIn, 
            int expectedDegree, 
            Colors expectedColor,
            Point ptOut)
        {
            var map = new Map(10,10); 
            var ant = new Ant();
            ant.Coordinate = ptIn;
            ant.Angle = degree;
            map.SetColor(ant.Coordinate, inputColor);
            var rcolor = ant.Move(map);

            Assert.That(ant.Coordinate, Is.EqualTo(ptOut), "Endpoint not as expected");
            Assert.That(ant.Angle, Is.EqualTo(expectedDegree), "Angle not as expected");
            Assert.That(rcolor, Is.EqualTo(expectedColor), "Color not as expected");

        }
    }
}
