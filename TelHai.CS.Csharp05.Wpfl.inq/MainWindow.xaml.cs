using System.Windows;
using System.Windows.Controls;
using TelHai.CS.Csharp05.Wpfl.inq.Models;

namespace TelHai.CS.Csharp05.Wpfl.inq
{
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            this.songsListBoxs.SelectionChanged += SongsListBoxs_SelectionChanged;
        }

        private void SongsListBoxs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Title=songsListBoxs.SelectedItems.ToString();
            lbl.Content = songsListBoxs.SelectedItems.ToString();
        }

        int index = 0;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            index++;
            this.songsListBoxs.Items.Add("Item " + index);
        }
        List<Song> songs = new List<Song>{
            new Song { Id = Guid.NewGuid().ToString(), Name = "1", Duration = 3.20f },
            new Song { Id = Guid.NewGuid().ToString(), Name = "2", Duration = 3.20f },
            new Song { Id = Guid.NewGuid().ToString(), Name = "3", Duration = 3.20f }
        };



        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //this.songsListBoxs.Items.Clear();
            //this.songsListBoxs.ItemsSource = null;
            //this.songsListBoxs.ItemsSource=songs;

            var rangList = songs.Where(s=> s.Duration <1f && s.Duration <2.5f).OrderBy(s =>s.Duration);
            songsListBoxs.Items.Clear();
            foreach(Song s in rangList)
            {
                songsListBoxs.Items.Add(s);
            }


        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button 3 clicked");
        }
    }
}
