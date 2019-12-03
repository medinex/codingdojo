using Countdown.ViewModel;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;

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
            Mock<ITimer> timerMoq = new Mock<ITimer>();
            //timerMoq.Setup(s => s.cu

            var vm = new CountDownViewModel(timerMoq.Object)
            {
                CountDownTime = new System.TimeSpan(0, 0, 5),
            };
          
            vm.StartCommand.Execute(this);

            timerMoq.Raise(m => m.Tick += null, EventArgs.Empty);
            timerMoq.Raise(m => m.Tick += null, EventArgs.Empty);
            timerMoq.Raise(m => m.Tick += null, EventArgs.Empty);
            timerMoq.Raise(m => m.Tick += null, EventArgs.Empty);
            timerMoq.Raise(m => m.Tick += null, EventArgs.Empty);

            Assert.That(vm.CountDownTime == new TimeSpan(0, 0, 0), "Should be 0");
            timerMoq.Verify(m => m.Start(), Times.Once);

            
        }
    }
}