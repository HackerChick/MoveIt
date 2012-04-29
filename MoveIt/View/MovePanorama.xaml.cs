using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using MoveIt.Helpers;
using MoveIt.ViewModel;

namespace MoveIt.View
{
    public partial class MovePanorama : PhoneApplicationPage
    {
        private readonly MoveViewModel moveViewModel = new MoveViewModel();

        public MovePanorama()
        {
            InitializeComponent();
            DataContext = moveViewModel;
        }
    }
}