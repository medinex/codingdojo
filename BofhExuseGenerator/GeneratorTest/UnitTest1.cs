using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BofhExuseGenerator;
using System.Collections.Generic;

namespace GeneratorTest
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow("Temporary", "Array", "Interruption", "Error")]
        [DataRow("Intermittant", "Software", "Destruction", "Signal")]
        public void WhateverShouldReturnTemporaryArrayInterruptionError(String a, String b, String c , String d)
        {
            var gen = new Generator();
            List<string> first = new List<string> { a };
            List<string> second = new List<string> { b };
            List<string> third = new List<string> { c };
            List<string> fourth = new List<string> { d };
            var ret = gen.CreateExcuse(first, second, third, fourth);

            Assert.AreEqual($"{a} {b} {c} {d}",ret);
        }

        [TestMethod]
        public void ShouldReturnRandomValue()
        {
            var gen = new Generator();
            var ret = gen.CreateExcuse(Resource.GetList(0), Resource.GetList(1), Resource.GetList(2), Resource.GetList(3));
            //todo assert that first value is in first list, as second is in second list a.s.o.
            Assert.IsFalse(string.IsNullOrWhiteSpace(ret), ret);
        }

        [TestMethod]
        public void TestListHasElement()
        {
            var list = Resource.GetFirstList();

            Assert.IsTrue(list.Count > 0);
        }

    }
}
