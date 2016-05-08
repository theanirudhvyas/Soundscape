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
using Newtonsoft.Json;
using System.Net.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TagSong : Page
    {
        MapIcon mapIcon1 = new MapIcon();

        public TagSong()
        {
            this.InitializeComponent();
            myMap.Loaded += myMap_Loaded;
        }
        private async void myMap_Loaded(object sender, RoutedEventArgs e)
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    Geolocator gl = new Geolocator();
                    Geoposition gp = await gl.GetGeopositionAsync();
                    Geopoint myloc = gp.Coordinate.Point;

                    myMap.Center = myloc;
                    mapIcon1.Location = myloc;
                    mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                    mapIcon1.Title = "";
                    mapIcon1.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png")); ;
                    mapIcon1.ZIndex = 0;
                    myMap.MapElements.Add(mapIcon1);
                    //myMap.Center.Longitude = myloc.Position.Longitude;
                    myMap.ZoomLevel = 12;
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

        private async void add_song_Click(object sender, RoutedEventArgs e)
        {
            songs s = new songs
            {
                song_name = song_name.Text,
                artist_name = "Various Artists",
                artist_id = "ASDKASGHCDSKASD",
                youtube_link = "https://www.youtube.com/watch?v=Mv48M9trlKs",
                itune_purchase_link = "https://soundcloud.com/qurat-wahid/padharo-maro-desh-farid-ayaz",
                latitude = mapIcon1.Location.Position.Latitude,
                longitude = mapIcon1.Location.Position.Longitude,
            };
            await App.MobileService.GetTable<songs>().InsertAsync(s);
        }


        private void myMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            mapIcon1.Location = args.Location;
            if (mapIcon1==null)
            {
            }
            else
            {

            }
        }

        private async void appBarButton_Click(object sender, RoutedEventArgs e)
        {
           
            Uri bUrl = new Uri("http://developer.echonest.com/api/v4/song/search?api_key=IPCIKPRHQM8FYTUUV&title=" + song_name.Text);
            HttpClient cli = new HttpClient();
            string content = await cli.GetStringAsync(bUrl);
            RootObject roj = JsonConvert.DeserializeObject<RootObject>(content);
            myMap.Height = 200;
           // reslist.ItemsSource = roj.response.songs;

        
    }

        private void listView_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
