using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class show_song : Page
    {
        public show_song()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var loc = e.Parameter as Geopoint;
            
            var rad = 0.1;

            List<songs> songs = await App.MobileService.GetTable<songs>().ToListAsync();
            double lat = loc.Position.Latitude;
            double longi = loc.Position.Longitude;


            List<songs> songs_range = new List<songs>();
            foreach (songs song in songs)
            {
                if ((song.latitude > lat - rad && song.latitude < lat + rad) && (song.longitude > longi - rad && song.longitude < longi + rad))
                {
                    songs_range.Add(song);
                }
            }
            SongList.ItemsSource = songs_range;

        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void MySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedUrl = SongList.SelectedItem;
           // Debug.WriteLine("Selected: {0}", e.AddedItems[0]);
        }
        private async void youtube_Click(object sender, RoutedEventArgs e)
        {
            //await Windows.System.Launcher.LaunchUriAsync(new Uri("{Binding youtube_link}"));
            var selectedObject = ((Button)sender).DataContext;
            var selectedUrl = ((songs)selectedObject).youtube_link;
            await Windows.System.Launcher.LaunchUriAsync(new Uri(selectedUrl));
        }

        private async void Soundcloud_Click(object sender, RoutedEventArgs e)
        {
            var selectedObject = ((Button)sender).DataContext;
            var selectedUrl = ((songs)selectedObject).itune_purchase_link;
            await Windows.System.Launcher.LaunchUriAsync(new Uri(selectedUrl));
        }
    }
}
