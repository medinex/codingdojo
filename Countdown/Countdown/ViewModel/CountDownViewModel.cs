using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace Countdown.ViewModel
{
    public class CountDownViewModel : ViewModelBase
    {
        private TimeSpan BaseCountDownTime { get; set; } = new TimeSpan(0, 0, 0);
        private readonly TimeSpan _timeSpanZero = new TimeSpan(0, 0, 0);
        ITimer _timer;

        public CountDownViewModel(ITimer timer)
        {

            StartCommand = new RelayCommand(OnStartCommand);
            StopCommand = new RelayCommand(OnStopCommand);
            ResetCommand = new RelayCommand(OnResetCommand);
            _timer = timer; // ?? new ArgumentNullException(nameof(_timer));
            _timer.Tick += _timer_Tick;
        }

        public TimeSpan CountDownTime
        {
            get => _countDownTime;
            set 
            {
                Set(ref _countDownTime, value);

                RaisePropertyChanged(nameof(IsTimeNegative));
            } 
        }
        private TimeSpan _countDownTime = new TimeSpan(0, 0, 0);

        public bool IsTimeNegative => CountDownTime < _timeSpanZero;

        public ICommand ResetCommand { get; }
        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }
       
        public double Value
        {
            get => _value;
            set => Set(ref _value, value);
        }
        private double _value;

        private void OnResetCommand()
        {
            _timer.Stop();
            CountDownTime = BaseCountDownTime;
            _timer.Start();
        }

        private void OnStopCommand()
        {
            _timer.Stop();
        }

        private void OnStartCommand()
        {
            _timer.Start();
            BaseCountDownTime = CountDownTime;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            CountDownTime = CountDownTime.Subtract(new TimeSpan(0, 0, 1));
            Value = 100 - (CountDownTime.TotalSeconds / BaseCountDownTime.TotalSeconds) * 100;
        }

    }
}
