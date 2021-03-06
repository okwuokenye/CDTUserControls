﻿using System;
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
using System.Windows.Threading;

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

        public delegate void File_ChangedEventHandler(string p_Value);
        public event File_ChangedEventHandler File_ChangedEvent;
        
        public delegate void RowDblClickEventHandler();
        public event RowDblClickEventHandler RowDblClickEvent;

        public delegate void RowEnterHitEventHandler();
        public event RowEnterHitEventHandler RowEnterHitEvent;               

        public delegate void Filter_Main_SelectedEventHandler(string p_Value);
        public event Filter_Main_SelectedEventHandler Filter_Main_SelectedEvent;

        public delegate void Filter_Second_SelectedEventHandler(string p_Value);
        public event Filter_Second_SelectedEventHandler Filter_Second_SelectedEvent;

        public delegate void Filter_Second_OnEventHandler(bool p_Value);
        public event Filter_Second_OnEventHandler Filter_Second_OnEvent;

        public delegate void Filter_Main_OnEventHandler(bool p_Value);
        public event Filter_Main_OnEventHandler Filter_Main_OnEvent;

        private DispatcherTimer DoubleClickTimer = new DispatcherTimer();

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

            vm.RowEnterHitEvent += Vm_RowEnterHitEvent;
            vm.Filter_Main_OnEvent += Vm_Filter_Main_OnEvent;
            vm.Filter_Second_OnEvent += Vm_Filter_Second_OnEvent;
            vm.Filter_Second_SelectedEvent += Vm_Filter_Second_SelectedEvent;
            vm.Filter_Main_SelectedEvent += Vm_Filter_Main_SelectedEvent;
            
            DoubleClickTimer.Interval = TimeSpan.FromSeconds(0.2);
            DoubleClickTimer.Tick += DoubleClickTimer_Tick;
        }

        #endregion


        #region public methods

        public void SetStatusPane(string p_Value)
        {
            vm.SetStatusPane(p_Value);
        }

        public void SetFileName(string p_Value)
        {
            vm.SetFileName(p_Value);
        }

        public void SetRowNo(string p_Value)
        {
            vm.SetRowNo(p_Value);
        }

        public EditorUserControlViewModel getVM()
        {
            return vm.getVM();
        }


        #endregion

        #region Button handlers

        private void Vm_Filter_Main_SelectedEvent(string p_Value)
        {
            Filter_Main_SelectedEvent(p_Value);
        }

        private void Vm_Filter_Second_SelectedEvent(string p_Value)
        {
            Filter_Second_SelectedEvent(p_Value);
        }
        
        private void Vm_Filter_Main_OnEvent(bool p_Value)
        {
            Filter_Main_OnEvent(p_Value);
        }
        private void Vm_Filter_Second_OnEvent(bool p_Value)
        {
            Filter_Second_OnEvent(p_Value);
        }

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
        
        private void Voice_MouseClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                DoubleClickTimer.Stop();
                VoiceDblClickEvent();
            }
            else
            {
                DoubleClickTimer.Start();
            }
          
        }

        private void DoubleClickTimer_Tick(object sender, EventArgs e)
        {
            DoubleClickTimer.Stop();
            VoiceClickEvent();
        }

        private void File_SelectionChanged(object sender, RoutedEventArgs args)
        {
            File_ChangedEvent(vm.Selected_File);
        }
        private void Row_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RowDblClickEvent();
        }

        private void Vm_RowEnterHitEvent()
        {
            RowEnterHitEvent();           
        }
       

        #endregion


    }
}
