using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MovieApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Details_Icon.Background = new SolidColorBrush();
            Search_Icon.Background = new SolidColorBrush(Colors.Gray);
            About_Icon.Background = new SolidColorBrush();

            


        }

        private void Go_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DetailsPage));    
        }

        private void About_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));

        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = string.Empty;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            currentView.BackRequested -= backButton_Tapped;

            //saving application data whenever the uer leaves the search for movie page
            var composite = new ApplicationDataCompositeValue();
            composite["movieSearch"] = SearchBox.Text;
            ApplicationData.Current.LocalSettings.Values["mainPage data"] = composite;

            base.OnNavigatedTo(e);
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //load
            //var composite = new ApplicationDataCompositeValue();
            //composite["movieSearch"] = SearchBox.Text;

            //ApplicationData.Current.LocalSettings.Values["mainPage data"] = composite;

            var composite = ApplicationData.Current.LocalSettings.Values["mainPage data"] as ApplicationDataCompositeValue;

            if (composite != null)
            {
                SearchBox.Text = composite["movieSearch"].ToString();
                // Checks whether the entire result is null OR
                // contains no resulting records.
            }

            base.OnNavigatedTo(e);
        }

        private void backButton_Tapped(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(MainPage));
            
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DetailsPage));
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }
    }
}
