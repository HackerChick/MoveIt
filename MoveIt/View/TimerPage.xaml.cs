using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using MoveIt.Model;
using MoveIt.ViewModel;

namespace MoveIt.View
{
    public partial class TimerPage : PhoneApplicationPage
    {
        // Constructor
        public TimerPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (App.State == TimerState.Type.InProgress) return;
            DataContext = new TimerViewModel( App.State );
        }
    }
}