using Countdown.ViewModel;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

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
            var vm = new CountDownViewModel()
            {
                CountDownTime = new System.TimeSpan(0, 0, 5),
            };
            Task.Run(() =>
            {
                vm.StartCommand.Execute(this);
               
                
            });
            Thread.Sleep(new TimeSpan(0, 0, 5));
            vm.StopCommand.Execute(this);
            Assert.That(vm.CountDownTime == new TimeSpan(0, 0, 0), "Shuld by 0");


            
        }
    }
}