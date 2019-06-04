using System;
using NUnit.Framework;
using DepthFirstSearch;
using System.Collections;
using System.Linq;

namespace DepthFirstSearchTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void WhereAreWeFirstNode()
        {
            var node = new Node("A");
            var result = KataSearch.WhereAreWe(node);
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void WhereAreTheExitsFirstNode()
        {
            var node = new Node("A");
            node.AddChildren("B", "C");
            var result = KataSearch.WhereAreTheExists(node);
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void TraverseNodeShouldReturnPath()
        {
            var node = new Node("A");
            node.AddChildren("B", "C");
            var result = KataSearch.Traverse(node);
            Assert.That(result.ToArray(), Is.EqualTo(new string[] { "A", "B", "A", "C" }));
        }

    }


}
