﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tutorial_UWPWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e) {
             Windows.Devices.Geolocation.Geoposition position;
            try {
                position = await LocationManager.GetPosition();
                //get the weather from OpenWeatherMap API. 
                RootObject weather = await OpenWeatherMapProxy.GetWeather(position.Coordinate.Latitude, position.Coordinate.Longitude);

                //schedule updates from LiveTileService
                string URI = String.Format(
                    "http://livetileservice1462.azurewebsites.net/default/?lat={0}&lon={1}",
                    position.Coordinate.Latitude,
                    position.Coordinate.Longitude
                    );

                var tileContent = new Uri(URI);
                var updater = TileUpdateManager.CreateTileUpdaterForApplication();
                updater.StartPeriodicUpdate(tileContent, PeriodicUpdateRecurrence.HalfHour);

                //get the actual icon image referenced in the prior API call
                string icon = String.Format("http://openweathermap.org/img/w/{0}.png", weather.weather[0].icon);

                //Assign the icon fetched to the source of the XAML image element in MainPage
                ResultImage.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(icon, UriKind.Absolute));

                //Display today's forecast in the XAML text element.
                TemperatureTextBlock.Text = weather.main.temp.ToString();
                DescriptionTextBlock.Text = weather.weather[0].description;
                LocationTextBlock.Text = weather.name;
            }
            catch {
                LocationTextBlock.Text = "Unable to get weather information.";
            }
        }
    }
}
