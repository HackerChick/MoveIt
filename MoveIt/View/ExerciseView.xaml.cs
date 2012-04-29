using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using MoveIt.DataAccess;
using MoveIt.Model;

namespace MoveIt.View
{
    public partial class ExerciseView : PhoneApplicationPage
    {
        public ExerciseView()
        {
            InitializeComponent();
        }

        // Use this to grab selectedItem out of the query string and set datacontext accordingly
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                var exercise = ExerciseRepository.Default.GetExercise(index);
                System.Windows.MessageBox.Show(exercise.Name);
                //DataContext = App.ViewModel.Items[index];
            }
        }

        private void webBrowser1_Loaded(object sender, RoutedEventArgs e)
        {
            //string site = "http://www.allyou.com/diet-fitness/at-home-workouts/lose-weight-00400000048774/page2.html";
            string site = "http://m.youtube.com/watch?v=whmUeG0saAM&fulldescription=1";
            //string site = "http://www.exercise.com/exercise/run-in-place";
            //webBrowser1.Navigate(new Uri(site, UriKind.Absolute));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String id = "whmUeG0saAM";
            //string urlToLoad = "vnd.youtube:" + id; // +"?vndapp=youtube_mobile";
            string urlToLoad = "http://www.youtube.com/watch?v=yX3jDRILmIg&fulldescription=1";
            
            WebBrowserTask wbt = new WebBrowserTask { URL = urlToLoad };
            wbt.Show();
        }
    }
}