using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Telhai.Csharpproject.API_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void CallApi_Click(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();
            var text = await client.GetStringAsync(
                "https://localhost:7108/api/test");

            ResultText.Text = text;
        }
        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            using var client = new HttpClient();

            var response = await client.PostAsJsonAsync(
                "https://localhost:7108/api/test/echo",
                InputBox.Text);

            var result = await response.Content.ReadAsStringAsync();
            ResultText.Text = result;
        }
    }
}