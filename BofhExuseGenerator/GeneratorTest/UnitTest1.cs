using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BofhExuseGenerator;

namespace GeneratorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestToGetASentence()
        {
            var gen = new Generator();
            var ret = gen.CreateExcuse(0, 0, 0, 0);

            Assert.AreEqual("Temporary Array Interruption Error",ret);

        }

        [TestMethod]
        public void TestListHasElement()
        {
            var list = Resource.GetFirstList();

            Assert.IsTrue(list.Count > 0);
        }

    }
}
