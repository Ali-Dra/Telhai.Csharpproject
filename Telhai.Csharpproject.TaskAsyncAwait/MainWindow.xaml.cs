using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Telhai.Csharpproject.TaskAsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Thread.CurrentThread.Name = "UI Thread";
            InitializeComponent();
        }

        private void BtnFreeze_Click(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = "Freezing...";

            // Simulate heavy work (5 seconds)
            Thread.Sleep(5000);

            txtStatus.Text = "Finished (UI was frozen!)";
        }

        private async void BtnTask_Click(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = "Starting Task...";
            int counter = 0;
            await Task.Run(() =>
            {
                // 1. Do heavy work on background thread
                //Thread.Sleep(4000);
                var sw = System.Diagnostics.Stopwatch.StartNew();
                while (sw.Elapsed < TimeSpan.FromSeconds(5))
                {//Heacy CPU work
                    counter++;
                    double x = 0;
                    for (int i = 0; i < 10_000_000; i++)
                        x += Math.Sqrt(i);

                }

                // 2. ERROR: Cannot access UI from here!
                // txtStatus.Text = "Done"; // <--- CRASHES APP

                // 3. FIX: Must ask the UI thread to update
                // Application.Current.Dispatcher.Invoke(() =>

            });
            txtStatus.Text = "Finished Background Task!";

        }

        private async void BtnAsync_Click(object sender, RoutedEventArgs e)
        {

            txtStatus.Text = "Waiting asynchronously...";

            // 'await' releases the UI thread to do other things (like animate the ProgressBar)
            // Task.Delay is the non-blocking version of Thread.Sleep
            await Task.Delay(3000);

            // Context is restored automatically here! We can update UI directly.
            txtStatus.Text = "Finished Async Wait!";
        }
        private static readonly HttpClient client = new HttpClient();

        private async void BtnApi_Click(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = "Fetching Data...";
            string url = "https://jsonplaceholder.typicode.com/todos";

            try
            {
                // 1. Send Request (Non-blocking)
                string jsonResponse = await client.GetStringAsync(url);

                // 2. Deserialize (Parse JSON)
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<TodoItem> todos = JsonSerializer.Deserialize<List<TodoItem>>(jsonResponse, options);

                // 3. Update UI
                txtStatus.Text = $"API Result: {todos?.Count}";
            }
            catch (HttpRequestException ex)
            {
                txtStatus.Text = "Network Error!";
            }
        }

    }

    public class TodoItem
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}