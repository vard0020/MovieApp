using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MovieApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            this.InitializeComponent();
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            Details_Icon.Background = new SolidColorBrush(Colors.Gray);
            Search_Icon.Background = new SolidColorBrush();
            About_Icon.Background = new SolidColorBrush();

            //creating a fake JSON. The real JSON will be go stten from an online source. This is just filler info.
            using (JsonWriter writer = new JsonTextWriter(sw))
            {

                writer.WriteStartObject();
                writer.WritePropertyName("poster");
                writer.WriteValue("ms-appx:///Assets/details_poster.jpg");
                writer.WritePropertyName("title");
                writer.WriteValue("Mission Impossible: Rogue Nation");
                writer.WritePropertyName("rating");
                writer.WriteValue("Pg-13");
                writer.WritePropertyName("runtime");
                writer.WriteValue("131 min.");
                writer.WritePropertyName("genre");
                writer.WriteValue("Action, Adventure");
                writer.WritePropertyName("plot");
                writer.WriteValue("Ethan and team take on their most impossible mission yet, eradicating the Syndicate - an International rogue organization as highly skilled as they are, committed to destroying the IMF.");
                writer.WritePropertyName("cast");
                writer.WriteValue("Tom Cruise, Jeremy Renner");
                writer.WritePropertyName("director");
                writer.WriteValue("Christopher Mcquarrie");
                writer.WriteEndObject();
            }

            var StringJson = sb.ToString();

            var jObj = JObject.Parse(StringJson);

            //setting poster
            var poster = jObj.SelectToken("poster");
            string posterString = poster.ToString();
            BitmapImage imagex = new BitmapImage(new Uri(posterString, UriKind.RelativeOrAbsolute));
            Poster.Source = imagex;

            //set title
            var movieTitle = jObj.SelectToken("title");
            string titleString = movieTitle.ToString();
            Movie_Title.Text = titleString;

            //set rating
            var movieRating = jObj.SelectToken("rating");
            string ratingString = movieRating.ToString();
            Rating.Text = ratingString;

            //set runtime
            var movieRuntime = jObj.SelectToken("runtime");
            string runtimeString = movieRuntime.ToString();
            RunTime.Text = runtimeString;

            //set genre
            var movieGenre = jObj.SelectToken("genre");
            string genreString = movieGenre.ToString();
            Genre.Text = genreString;

            //set plot
            var moviePlot = jObj.SelectToken("plot");
            string plotString = moviePlot.ToString();
            Plot.Text = plotString;

            //set cast
            var movieCast = jObj.SelectToken("cast");
            string castString = movieCast.ToString();
            Cast.Text = "Cast: " + castString;

            //set director
            var movieDirector = jObj.SelectToken("director");
            string directorString = movieDirector.ToString();
            Director.Text = "Director: " + directorString;
        }

        private void About_Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += backButton_Tapped;

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
            Frame.Navigate(typeof(MainPage));
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
