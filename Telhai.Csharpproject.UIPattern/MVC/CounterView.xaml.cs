using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Windows.Controls;


namespace Telhai.Csharpproject.UIPattern.MVC
{
    /// <summary>
    /// Interaction logic for CounretView.xaml
    /// </summary>
    public partial class CounretView : UserControl
    {
        private CounterModel model = new();
        private CounterController controller;

       public CounretView()
        {
            InitializeComponent();
            controller = new CounterController(model);
            UpdateUI();
        }

        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            controller.Increment();
            UpdateUI();
        }
        public UserControl BuilViewA()
        {
            return this;
        }

        private void UpdateUI()
        {
            CounterText.Text = controller.GetValue().ToString();
        }
        
    }
}
