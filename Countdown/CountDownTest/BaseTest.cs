using Countdown.ViewModel;
using NUnit.Framework;

namespace CountDownTest
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
            var vm = new CountDownViewModel();
            Assert.Pass();
        }
    }
}