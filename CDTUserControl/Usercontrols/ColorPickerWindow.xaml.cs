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
    /// <summary>
    /// Interaction logic for ColorPickerWindow.xaml
    /// </summary>
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
            this.Close();
        }
        
        Color? _ColorSelected;

        //When the Selected Color is changed I need this to update on the ColorSelected Property. This would be RaisePropertyChanged on the MVVM but not sure how to do here? Maybe event on SelectedColorChanged?
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
        
    }
}
