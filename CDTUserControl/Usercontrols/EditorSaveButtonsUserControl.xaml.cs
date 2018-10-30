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
    /// Interaction logic for EditorSaveButtons.xaml
    /// </summary>
    public partial class EditorSaveButtonsUserControl : UserControl
    {
        
        public delegate void PreviousButtonEventHandler();
        public event PreviousButtonEventHandler PreviousButtonEvent;
        public delegate void NextButtonEventHandler();
        public event NextButtonEventHandler NextButtonEvent;
        public delegate void TwoUpSaveButtonEventHandler();
        public event TwoUpSaveButtonEventHandler TwoUpSaveButtonEvent;
        public delegate void UpSaveButtonEventHandler();
        public event UpSaveButtonEventHandler UpSaveButtonEvent;
        public delegate void SaveButtonEventHandler();
        public event SaveButtonEventHandler SaveButtonEvent;

        public EditorSaveButtonsUserControl()
        {
            InitializeComponent();
        }

        private void PreviousMoveClick(object sender, RoutedEventArgs args)
        {
            PreviousButtonEvent();
        }
        private void NextMoveClick(object sender, RoutedEventArgs args)
        {
            NextButtonEvent();
        }
        private void TwoUpSaveClick(object sender, RoutedEventArgs args)
        {
            TwoUpSaveButtonEvent();
        }
        private void UpSaveClick(object sender, RoutedEventArgs args)
        {
            UpSaveButtonEvent();
        }
        private void SaveClick(object sender, RoutedEventArgs args)
        {
            SaveButtonEvent();
        }
    }
}
