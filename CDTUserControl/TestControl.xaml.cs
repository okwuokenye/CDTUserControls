using System;
using System.Collections.Generic;
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

namespace CDTUserControl
{
    /// <summary>
    /// Interaction logic for TestControl.xaml
    /// </summary>
    public partial class TestControl : Window
    {
        public TestControl()
        {
            InitializeComponent();
        }

        [STAThread]
        public static void Main()
        {
            TestControl tc = new TestControl();
            tc.Show();
           // Dispatcher.Run();
        }
    }
}
