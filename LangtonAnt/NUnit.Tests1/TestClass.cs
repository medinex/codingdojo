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
            var langtonAnt = new LangtonGame();
            var pane = langtonAnt.CreatePane(3, 3);

            Assert.That(pane.Width, Is.EqualTo(3));
            Assert.That(pane.Height, Is.EqualTo(3));
        }

        [Test]
        public void CheckCreatePlaneWillHaveColors()
        {
            var langtonAnt = new LangtonGame();
            var pane = langtonAnt.CreatePane(3, 3);

            Assert.That(pane.GetColor(), Is.EqualTo(Colors.Black || Colors.White ));
            
        }
    }

 
}
