using CDTUserControl.Viewmodels;
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

namespace CDTUserControl.Usercontrols
{

    public partial class ColorPickerWindow : Window
    {        
        public ColorPickerWindow(Color? cl)
        {
            InitializeComponent();
            this.DataContext = this;
            ColorSelected = cl;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            ColorOK = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;

            this.Left = point.X;
            this.Top = point.Y;
        }
        
        Color? _ColorSelected;
        public Color? ColorSelected
        {
            get { return _ColorSelected; }
            set
            {
                if (_ColorSelected != value)
                {
                    _ColorSelected = value;
                }
            }
        }

        bool _ColorOK = false;
        public bool ColorOK
        {
            get { return _ColorOK; }
            set
            {
                if (_ColorOK != value)
                {
                    _ColorOK  = value;
                }
            }
        }

    }
}
