using System;

namespace Countdown.ViewModel
{
    public interface ITimer
    {
        void Start();

        void Stop();

        event EventHandler Tick;

    }
}
