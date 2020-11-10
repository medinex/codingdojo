using HangmanGame;
using NUnit.Framework;

namespace HangmanTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var h = new Hangman("test");

            var ret = h.Guess('a');

            Assert.AreEqual("----", ret);

            ret = h.Guess('t');

            Assert.AreEqual("t--t", ret);

            ret = h.Guess('t');

            Assert.AreEqual("t--t", ret);

            ret = h.Guess('e');

            Assert.AreEqual("te-t", ret);

            ret = h.Guess('s');

            Assert.AreEqual("test", ret);

        }
    }
}