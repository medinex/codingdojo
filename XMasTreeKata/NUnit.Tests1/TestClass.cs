using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMasTreeKata;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            ChristmasTree tree = new ChristmasTree();
            var result = tree.Draw(5, false);
            Assert.That(result.Count, Is.EqualTo(6));
        }

        [Test]
        public void TreeWithStarShouldHaveOnlElementMore()
        {
            ChristmasTree tree = new ChristmasTree();
            var result = tree.Draw(5, true);
            Assert.That(result.Count, Is.EqualTo(7));
        }
    }
}
