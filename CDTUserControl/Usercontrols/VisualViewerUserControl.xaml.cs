using CDTUserControl.Viewmodels;
using NewCDT.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewCDT.Controls
{
    /// <summary>
    /// Interaction logic for VisualViewer.xaml
    /// </summary>
    public partial class VisualViewerUserControl : UserControl
    {
        VisualViewerViewModel vm;

        public VisualViewerUserControl()
        {
            InitializeComponent();
            vm = new VisualViewerViewModel();
            base.DataContext = vm;
        }

        public VisualViewerViewModel GetVM()
        {
            return vm;
        }
    }
}
