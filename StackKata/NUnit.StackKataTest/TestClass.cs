using NUnit.Framework;
using System;
using System.Text;
using System.Threading.Tasks;
using StackKataLibrary;
using System.Collections.Generic;

namespace NUnit.StackKataTest
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void PoppingAnEmptyStackShouldThrowInvalidOperationException()
        {
            var stack = new StackKata<int>();

            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void TestingPushOneElemet()
        {
            var stack = new StackKata<int>();
            stack.Push(5);
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestingPushAndPopTogether()
        {
            var stack = new StackKata<int>();
            stack.Push(5);
            Assert.That(stack.Pop(), Is.EqualTo(5));
        }

        [Test]
        public void PopShouldRemoveLastPush()
        {
            var stack = new StackKata<int>();
            stack.Push(7);
            stack.Push(9);
            stack.Push(1);
            Assert.That(stack.Pop(), Is.EqualTo(1));
            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestPopOnly()
        {
            var expectedList = new List<int>();
            expectedList.Add(5);
            expectedList.Add(7);
            expectedList.Add(9);
            expectedList.Add(1);

            var stack = new StackKata<int>(expectedList);
            Assert.That(stack.Pop(), Is.EqualTo(1));
            Assert.That(stack.Pop(), Is.EqualTo(9));
            Assert.That(stack.Pop(), Is.EqualTo(7));
            Assert.That(stack.Pop(), Is.EqualTo(5));
        }

        [Test]
        public void TestPushOnly()
        {
            var expectedList = new List<int>();
            expectedList.Add(5);
            expectedList.Add(7);
            expectedList.Add(9);
            expectedList.Add(1);

            var stack = new StackKata<int>();
            stack.Push(5);
            stack.Push(7);
            stack.Push(9);
            stack.Push(1);


            Assert.That(stack.GetAsList(), Is.EqualTo(expectedList));
        }

    }
}
