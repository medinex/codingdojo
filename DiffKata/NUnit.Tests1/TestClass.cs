using NUnit.Framework;
using DiffKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiffKata.ViewModel;

namespace DiffKata.Tests
{
    [TestFixture()]
    public class MainWindowTests
    {

        KataViewModel _m;

        [SetUp]
        public void Init()
        {
            _m = new KataViewModel();
        }

        [TestCase(3, 0, "nine")]
        [TestCase(3, 1, "minus one")]
        [TestCase(3, 1, "minus one")]
        public void ParseToListShouldDoTheThing(int lineHead, int whichList, string textHead)
        {


            _m.ParseToList(NUnit.Tests1.Properties.Resource1.InputString);

            if (whichList == 0)
            {
                Assert.That(_m.HeadStringList[lineHead], Is.EqualTo(textHead));
            }
            else
            {
                Assert.That(_m.BranchStringList[lineHead], Is.EqualTo(textHead));
            }
        }

        [Test]
        public void TEstListPArser()
        {
            var ret = _m.ParseToList(NUnit.Tests1.Properties.Resource1.InputString);


            Assert.That(ret[4], Is.EqualTo("minus one"));

        }


    }
}