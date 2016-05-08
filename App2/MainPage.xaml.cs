using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MapIcon mapIcon1 = new MapIcon();
        private object table;

        public MainPage()
        {
            this.InitializeComponent();
            myMap.Loaded += myMap_Loaded;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TagSong));
            //            songs s = new songs
            //            {
            //                song_name = "Hey"
            //           };

            //            await App.MobileService.GetTable<songs>().InsertAsync(s);
        }

        private async void myMap_Loaded(object sender, RoutedEventArgs e)
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            var rad = 0.1;
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    Geolocator gl = new Geolocator();
                    Geoposition gp = await gl.GetGeopositionAsync();
                    Geopoint myloc = gp.Coordinate.Point;

                    myMap.Center = myloc;
                    myMap.ZoomLevel = 12;
                    mapIcon1.Location = myloc;
                    mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                    mapIcon1.Title = "My Friend";
                    mapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/StoreLogo.png")); ;
                    mapIcon1.ZIndex = 0;
                    //myMap.MapElements.Add(mapIcon1);

                    List<songs> songs = await App.MobileService.GetTable<songs>().ToListAsync();
                    double lat = mapIcon1.Location.Position.Latitude;
                    double longi = mapIcon1.Location.Position.Longitude;

                    List<songs> songs_range = new List<songs>();
                    foreach (songs song in songs)
                    {
                        //if ((song.latitude > lat - rad && song.latitude < lat + rad) && (song.longitude > longi - rad && song.longitude < longi + rad))
                        //{
                            MapIcon mapIcon = new MapIcon();
                            mapIcon.Location = new Geopoint(new BasicGeoposition() { Latitude = song.latitude, Longitude = song.longitude });
                            mapIcon.NormalizedAnchorPoint = new Point(0.5, 1.0);
                            mapIcon.Title = song.song_name;
                            mapIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png")); ;
                            mapIcon.ZIndex = 0;
                            myMap.MapElements.Add(mapIcon);
                        //}
                    }

                    break;
                case GeolocationAccessStatus.Denied:
                    break;
                case GeolocationAccessStatus.Unspecified:
                    break;
            }

            //            myMap.Center.Latitude = 26.2715525;
            //            myMap.Center.Longitude = 73.0346128;
            //myMap.ZoomLevel = 12;
        }

        private void myMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            var loc = new Geopoint(new BasicGeoposition() { Latitude = args.Location.Position.Latitude, Longitude = args.Location.Position.Longitude }); ;
            this.Frame.Navigate(typeof(show_song), loc);
        }
    }
}
