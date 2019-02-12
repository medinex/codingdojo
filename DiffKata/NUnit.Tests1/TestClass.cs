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

        [TestCase(0, true, "the solar system")]
        [TestCase(1, true, "the number of planets is")]
        [TestCase(2, true, "nine")]
        [TestCase(3, true, "minus one")]
        [TestCase(4, true, "earth is the 3rd planet")]
        [TestCase(3, false, "")]
        [TestCase(2, false, "eight")]
        public void ParseToListShouldDoTheThing(int indexOfLine, bool isHeadList, string textHead)
        {


            _m.ParseToList(NUnit.Tests1.Properties.Resource1.InputString);

            if (isHeadList)
            {
                Assert.That(_m.HeadStringList[indexOfLine], Is.EqualTo(textHead));
            }
            else
            {
                Assert.That(_m.BranchStringList[indexOfLine], Is.EqualTo(textHead));
            }
        }

        [TestCase(0, false, "the solar system")]
        [TestCase(1, false, "the number of planets is")]
        [TestCase(2, false, "eight")]
        [TestCase(3, false, "minus one")]
        [TestCase(4, false, "earth is the 3rd planet")]
        [TestCase(3, true, "")]
        [TestCase(2, true, "nine")]
        public void ParseReverseToListShouldDoTheThing(int indexOfLine, bool isHeadList, string textHead)
        {
            _m.ParseToList(NUnit.Tests1.Properties.Resource1.ReverseString);

            if (isHeadList)
            {
                Assert.That(_m.HeadStringList[indexOfLine], Is.EqualTo(textHead));
            }
            else
            {
                Assert.That(_m.BranchStringList[indexOfLine], Is.EqualTo(textHead));
            }
        }


        [TestCase(0, true, "the solar system")]
        [TestCase(0, false, "the solar system")]
        [TestCase(1, true, "the number of planets is")]
        [TestCase(1, false, "the number of planets is")]
        [TestCase(2, true, "nine")]
        [TestCase(3, true, "minus one")]
        [TestCase(4, true, "earth is the 3rd planet")]
        [TestCase(4, false, "earth is the 3rd planet")]
        [TestCase(3, false, "hello world")]
        [TestCase(2, false, "eight")]
        public void ParseSecondTestToListShouldDoTheThing(int indexOfLine, bool isHeadList, string textHead)
        {
            _m.ParseToList(NUnit.Tests1.Properties.Resource1.SecondTestString);

            if (isHeadList)
            {
                Assert.That(_m.HeadStringList[indexOfLine], Is.EqualTo(textHead));
            }
            else
            {
                Assert.That(_m.BranchStringList[indexOfLine], Is.EqualTo(textHead));
            }
        }

        [TestCase(0, true, "nine")]
        [TestCase(1, true, "minus one")]
        [TestCase(2, true, "earth is the 3rd planet")]
        [TestCase(2, false, "earth is the 3rd planet")]
        [TestCase(1, false, "hello world")]
        [TestCase(0, false, "eight")]
        public void ParseStartsWithHeadToListShouldDoTheThing(int indexOfLine, bool isHeadList, string textHead)
        {
            _m.ParseToList(NUnit.Tests1.Properties.Resource1.StartsWithHead);

            if (isHeadList)
            {
                Assert.That(_m.HeadStringList[indexOfLine], Is.EqualTo(textHead));
            }
            else
            {
                Assert.That(_m.BranchStringList[indexOfLine], Is.EqualTo(textHead));
            }
        }

        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        public void CheckConflict(int indexOfLine, bool isConflict)
        {
            _m.ParseToList(NUnit.Tests1.Properties.Resource1.InputString);

            Assert.That(_m.IsConflict(indexOfLine), Is.EqualTo(isConflict));
        }

        [Test]
        public void TestListParser()
        {
             _m.ParseToList(NUnit.Tests1.Properties.Resource1.InputString);


            Assert.That(_m.HeadStringList[3], Is.EqualTo("minus one"));
            Assert.That(_m.BranchStringList[2], Is.EqualTo("eight"));

        }

        [Test]
        public void ListsShouldBeFilled()
        {
            _m.ParseToList("dlkföjadflö kajsd fölkas dfölkas dfölask<<<<<<<<< <> >>>>>>>>>>>>>> lödfjd ljh\n" +
                "dfköasjd flask j==== 0============== jd fdlök\n" +
                "\n\nldfj ölsdajkfs alödk f");


            Assert.That(_m.BranchlistValues.Any(), Is.True);
            Assert.That(_m.HeadlistValues.Any(), Is.True);
            Assert.That(_m.HeadlistValues.Count, Is.EqualTo(_m.BranchlistValues.Count));
        }

        [Test]
        public void TestEquality()
        {
            _m.ParseToList("dlkföjadflö kajsd fölkas dfölkas dfölask<<<<<<<<< <> >>>>>>>>>>>>>> lödfjd ljh\n" +
                "dfköasjd flask j==== 0============== jd fdlök\n" +
                "\n\nldfj ölsdajkfs alödk f");


            Assert.That(_m.HeadStringList.Count == _m.BranchStringList.Count);

        }


        [Test]
        public void ConflictShouldFire()
        {
            bool fired = false;
            _m.PropertyChanged += (sender, evt) =>
            {
                if (evt.PropertyName == nameof(KataViewModel.HasConflict))
                {
                    fired = true;
                }
            };

            _m.ParseToList(NUnit.Tests1.Properties.Resource1.InputString);

            Assert.That(fired, Is.True, "event not fired");

        }

    }
}