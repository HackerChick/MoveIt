using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

// Handles Navigation between pages so that the ViewModel can remain blissfully ignorant of the Views
// Source from: http://blog.clauskonrad.net/2010/09/wp7-navigationservice-support-when.html
namespace MoveIt.Helpers
{
    public enum ViewType { Timer, Move, Exercise }

    public class ApplicationController
    {
        static ApplicationController _singletonInstance;
        readonly Dictionary<ViewType, Uri> views;

        ApplicationController()
        {
            views = new Dictionary<ViewType, Uri>();

            // Register views with controller
            Register(ViewType.Timer, new Uri("/View/TimerPage.xaml", UriKind.Relative));
            Register(ViewType.Move, new Uri("/View/MovePanorama.xaml", UriKind.Relative));
            Register(ViewType.Exercise, new Uri("/View/ExerciseView.xaml", UriKind.Relative));
        }

        public static ApplicationController Default { get { return _singletonInstance ?? (_singletonInstance = new ApplicationController()); } }

        void Register(ViewType type, Uri address)
        {
            if (views.ContainsKey(type)) //update
            {
                views[type] = address;
                return;
            }

            views.Add(type, address); //add
        }

        void UnRegister(ViewType type)
        {
            if (views.ContainsKey(type))
                views.Remove(type);
        }

        public void GoBack()
        {
            var root = Application.Current.RootVisual as PhoneApplicationFrame;
            if (root != null) root.GoBack();
        }

        public void NavigateTo(ViewType type)
        {
            var root = Application.Current.RootVisual as PhoneApplicationFrame;
            if (root != null) root.Navigate(views[type]);
        }

        public void NavigateTo(ViewType type, int selectedItem)
        {
            var root = Application.Current.RootVisual as PhoneApplicationFrame;
            String url = views[type].ToString() + "?selectedItem=" + selectedItem;
            if (root != null) root.Navigate(new Uri(url, UriKind.Relative));
        }

        public void NavigateToUrl(String url)
        {
            var webBrowser = new WebBrowserTask { URL = Uri.EscapeDataString(url) };
            webBrowser.Show();
        }
    }
}
