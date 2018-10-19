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
using CDTUserControl.Viewmodels;

namespace CDTUserControl.Usercontrols
{

    public partial class EditorUserControl : UserControl
    {
        EditorUserControlViewModel vm;
        #region events

        public delegate void RenameButtonEventHandler();
        public event RenameButtonEventHandler RenameButtonEvent;
        public delegate void DeleteButtonEventHandler();
        public event DeleteButtonEventHandler DeleteButtonEvent;
        public delegate void EditButtonEventHandler();
        public event EditButtonEventHandler EditButtonEvent;
        public delegate void PrimaryButtonEventHandler();
        public event PrimaryButtonEventHandler PrimaryButtonEvent;
        public delegate void SortAltsButtonEventHandler();
        public event SortAltsButtonEventHandler SortAltsButtonEvent;
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

        public delegate void VoiceClickEventHandler();
        public event VoiceClickEventHandler VoiceClickEvent;

        public delegate void VoiceDblClickEventHandler();
        public event VoiceDblClickEventHandler VoiceDblClickEvent;

        #endregion

        #region public properties



        #endregion

        #region Constructor

        public static void EnsureApplicationResources()
        {
            if (System.Windows.Application.Current == null)
            {
                new System.Windows.Application
                {
                    ShutdownMode = ShutdownMode.OnExplicitShutdown
                };
            }
        }
        
        public EditorUserControl()
        {
            EnsureApplicationResources();
            InitializeComponent();
            vm = new EditorUserControlViewModel();
            base.DataContext = vm;

        }

        #endregion


        #region public methods

        public void SetStatusPane(string p_Value)
        {
            vm.SetStatusPane(p_Value);
        }
        
        public EditorUserControlViewModel getVM()
        {
            return vm.getVM();
        }
        

        #endregion

        #region Button handlers

        private void RenameClick(object sender, RoutedEventArgs args)
        {
            RenameButtonEvent();
        }
        private void DeleteClick(object sender, RoutedEventArgs args)
        {
            DeleteButtonEvent();
        }
        private void EditClick(object sender, RoutedEventArgs args)
        {
            EditButtonEvent();
        }
        private void PrimaryClick(object sender, RoutedEventArgs args)
        {
            PrimaryButtonEvent();
        }
        private void SortAltsClick(object sender, RoutedEventArgs args)
        {
            SortAltsButtonEvent();
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
        private void Voice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VoiceDblClickEvent();
        }
        
        private void Voice_MouseClick(object sender, MouseEventArgs e)
        {
                VoiceClickEvent();            
        }
        #endregion


    }
}
