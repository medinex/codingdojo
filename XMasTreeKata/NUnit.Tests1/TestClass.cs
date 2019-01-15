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
            ChristmasTree tree = new ChristmasTree(5, false);
            var result = tree.Draw();
            Assert.That(result.Count, Is.EqualTo(6));
        }

        [Test]
        public void TreeWithStarShouldHaveOnlElementMore()
        {
            ChristmasTree tree = new ChristmasTree(5, true);
            var result = tree.Draw();
            Assert.That(result.Count, Is.EqualTo(7));
        }

        [TestCase(5, 7)]
        [TestCase(6, 8)]
        [TestCase(3, 5)]
        public void TestTreeHeightWithStar(int treeSize, int expectedHeight)
        {
            ChristmasTree tree = new ChristmasTree(treeSize, true);
            tree.Draw();
            var result = tree.GetHeight();
            Assert.That(result, Is.EqualTo(expectedHeight));
        }

        [TestCase(5, 6)]
        [TestCase(6, 7)]
        [TestCase(3, 4)]
        public void TestTreeHeightWithoutStar(int treeSize, int expectedHeight)
        {
            ChristmasTree tree = new ChristmasTree(treeSize, false);
            tree.Draw();
            var result = tree.GetHeight();
            Assert.That(result, Is.EqualTo(expectedHeight));
        }

        [TestCase(6, 13)]
        [TestCase(3, 7)]
        [TestCase(5, 11)]
        public void TestTreeWidthWithStar(int treeSize, int expectedWidth)
        {
            ChristmasTree tree = new ChristmasTree(treeSize, true);
            tree.Draw();
            var result = tree.GetWidth();
            Assert.That(result, Is.EqualTo(expectedWidth));
        }

        [TestCase(6, 13)]
        [TestCase(3, 7)]
        [TestCase(5, 11)]
        public void TestTreeWidthWithoutStar(int treeSize, int expectedWidth)
        {
            ChristmasTree tree = new ChristmasTree(treeSize, true);
            tree.Draw();
            var result = tree.GetWidth();
            Assert.That(result, Is.EqualTo(expectedWidth));
        }
    }
}
