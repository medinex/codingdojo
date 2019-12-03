using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace Countdown.ViewModel
{
    class Timer : ITimer
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();


        public Timer()
        {
            _timer.Interval = new TimeSpan(0, 0, 1);
        }

        public event  EventHandler Tick
        {
            add { _timer.Tick += value; }
            remove { _timer.Tick -= value; }
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
