using System;
using System.Windows;
using System.Windows.Resources;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Command;
using MoveIt.Helpers;
using MoveIt.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;



namespace MoveIt.ViewModel
{
    public class TimerViewModel : ViewModelBase
    {
        private readonly TimeSpan tickDuration = new TimeSpan(0, 0, 1);
        private static readonly TimeSpan DEFAULT_DURATION = new TimeSpan(0, 0, 1);
        private static readonly TimeSpan SNOOZE_DURATION = new TimeSpan(0, 0, 5);
        private static readonly TimeSpan ZERO = new TimeSpan(0, 0, 0);

        private SoundEffect alarmSound;
        private TimeSpan timerDuration;
        private DispatcherTimer timer = null;
        public RelayCommand StartTimerCommand { get; private set; }
        public RelayCommand StopTimerCommand { get; private set; }
        public RelayCommand RestartTimerCommand { get; private set; }

        private TimeSpan remainingTime;
        public TimeSpan RemainingTime
        {
            get { return remainingTime; }
            set { remainingTime = value; OnNotifyPropertyChanged("RemainingTime"); OnNotifyPropertyChanged("HasCountdownStarted"); }
        }

        public bool HasCountdownStarted
        {
            get { return !(RemainingTime == timerDuration); }
        }

        private bool isTimerActive = false;
        public bool IsTimerActive
        {
            get { return isTimerActive; }
            private set { isTimerActive = value; OnNotifyPropertyChanged("IsTimerActive"); OnNotifyPropertyChanged("CanStartTimer"); }
        }

        public bool CanStartTimer
        {
            get { return !isTimerActive && RemainingTime > ZERO; }
        }

        public TimerViewModel() : this(TimerState.Type.New) { }
        public TimerViewModel(TimerState.Type timerType)
        {
            Initialize(timerType == TimerState.Type.Snooze ? SNOOZE_DURATION : DEFAULT_DURATION);
        }


        private void Initialize(TimeSpan timerLength)
        {
            timerDuration = timerLength;
            RemainingTime = timerDuration;

            StartTimerCommand = new RelayCommand(StartTimer);
            StopTimerCommand = new RelayCommand(StopTimer);
            RestartTimerCommand = new RelayCommand(RestartTimer);

            Sound.Default.Load("Sounds/alarm.wav", out alarmSound);

            App.State = TimerState.Type.InProgress;
            StartTimer();
        }

        private void StartTimer()
        {
            if (IsTimerActive || RemainingTime <= ZERO) return;
            IsTimerActive = true;

            timer = new DispatcherTimer { Interval = tickDuration };
            timer.Tick += new EventHandler(TimerFired);
            timer.Start();
        }

        private void StopTimer()
        {
            if (IsTimerActive && timer != null) timer.Stop();
            IsTimerActive = false;
            timer = null;
        }

        private void RestartTimer()
        {
            RemainingTime = DEFAULT_DURATION;
            StartTimer();
        }

        private void TimerFired(object sender, EventArgs e)
        {
            RemainingTime = RemainingTime.Subtract(tickDuration); // using RemainingTime = to get the OnNotifyPropertyChanged event

            if (RemainingTime <= ZERO)
            {
                StopTimer();
                Move();
            }
        }

        private void Move()
        {
            alarmSound.Play();

            App.State = TimerState.Type.New;    // reset so if they hit back button the timer will start anew
            ApplicationController.Default.NavigateTo(ViewType.Move);
        }



    }
}
