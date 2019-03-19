using LOCKata;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestBlockParser()
        {
            var test = new LOCParser("/*alabala*/");
            
            Assert.AreEqual(1, test.LinesTotal);
            Assert.AreEqual(0, test.LinesOfCode);
        }

        [Test]
        public void TestSingleLineComment()
        {
            var test = new LOCParser("adliasjdkljd//alksdjaslkdjaskljdklasdj");

            Assert.AreEqual(1, test.LinesTotal);
            Assert.AreEqual(1, test.LinesOfCode);
        }


        [Test]
        public void TestResourceCode()
        {
            var code = NUnit.Tests1.Properties.Resource.Test1;

            var test = new LOCParser(code);

            Assert.AreEqual(18, test.LinesTotal);
            Assert.AreEqual(14, test.LinesOfCode);
        }

        [Test]
        public void TestCleaner()
        {

            var code = "lödfsfj ölskdjf asfkld /*ödfslkjaskdljf as*/ l kja söldkfjj sd" +
                        "sdf ajsdlfj asdflö ölfdka jsöfd;// dsfäölk asldkj;";

            var result = "lödfsfj ölskdjf asfkld  l kja söldkfjj sd" +
                        "sdf ajsdlfj asdflö ölfdka jsöfd;";

            var test = new LOCParser(code);

            var r = test.DeleteComments(code);
            Assert.AreEqual(r, result);



        }

        [Test]
        public void TestCleanerInEmptyText()
        {
            var code = "";

            var result = "";

            var test = new LOCParser(code);

            var r = test.DeleteComments(code);
            Assert.AreEqual(r, result);
        }

        [Test]
        public void TestCleanerInText()
        {

            var code = "lödfsfj ölskdjf asfkld \"/*ödfslkjaskdljf as*/\" l kja söldkfjj sd" +
                        "sdf ajsdlfj asdflö ölfdka jsöfd;\"// dsfäölk asldkj;\"";

            var result = "lödfsfj ölskdjf asfkld \"/*ödfslkjaskdljf as*/\" l kja söldkfjj sd" +
                        "sdf ajsdlfj asdflö ölfdka jsöfd;\"// dsfäölk asldkj;\"";

            var test = new LOCParser(code);

            var r = test.DeleteComments(code);
            Assert.That(r, Is.EqualTo(result));



        }
    }
}
