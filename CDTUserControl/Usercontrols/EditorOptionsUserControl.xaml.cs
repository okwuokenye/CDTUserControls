﻿using System;
using System.Collections.Generic;
using System.Data;
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
    /// <summary>
    /// Interaction logic for EditorOptionsUserControl.xaml
    /// </summary>
    public partial class EditorOptionsUserControl : UserControl
    {
        EditorOptionsUserControlViewModel vm;

        #region event declarations

        public delegate void RootChangeButtonEventHandler();
        public event RootChangeButtonEventHandler RootChangeButtonEvent;

        public delegate void EditorExeChangeButtonEventHandler();
        public event EditorExeChangeButtonEventHandler EditorExeChangeButtonEvent;
                
        public delegate void SaveButtonEventHandler();
        public event SaveButtonEventHandler SaveButtonEvent;

        public delegate void UpdateButtonEventHandler();
        public event UpdateButtonEventHandler UpdateButtonEvent;

        public delegate void EditorChangedEventHandler();
        public event EditorChangedEventHandler EditorChangedEvent;


        #endregion

        #region constructor
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

        public EditorOptionsUserControl()
        {
            EnsureApplicationResources();
            InitializeComponent();
            vm = new EditorOptionsUserControlViewModel();

            //add event listeners
            vm.EditorChangedEvent += Vm_EditorChangedEvent;

            base.DataContext = vm;
        }

        #endregion

        #region event handlers

        void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            if (e.Source is Expander)
            {
                var exp1 = (Expander)sender;
                foreach (Expander exp in ExpanderGrid.Children)
                {
                    if (exp!=exp1 )
                    {
                        exp.IsExpanded = false;
                    }
                }                
            }
        }

        private void RootClick(object sender, RoutedEventArgs args)
        {
            RootChangeButtonEvent();
        }

        private void EditorExeClick(object sender, RoutedEventArgs args)
        {
            EditorExeChangeButtonEvent();
        }
        
        private void SaveClick(object sender, RoutedEventArgs args)
        {
            SaveButtonEvent();
        }

        private void UpdateClick(object sender, RoutedEventArgs args)
        {
            UpdateButtonEvent();
        }
        
        private void Vm_EditorChangedEvent()
        {
            EditorChangedEvent();
        }

        #endregion

        #region public set functions
        public void SetDeviceList(List<String> p_Devices)
        {
            vm.SetDeviceList(p_Devices);
        }
        
        public void SetRootText(string p_Value)
        {
            vm.SetRootText(p_Value);
        }

        public void SetEditorExe(string p_Value)
        {
            vm.SetEditorExe(p_Value);
        }

        public void SetStatusWarn(string p_Value)
        {
            vm.SetStatusWarn(p_Value);
        }

        public void SetVersionNumber(string p_Value)
        {
            vm.SetVersionNumber(p_Value);
        }
        public void SetAltSuffix(string p_Value)
        {
            vm.SetAltSuffix(p_Value);
        }

        public void SetDeviceName(string p_Value)
        {
            vm.SetDeviceName(p_Value);
        }
        
        public void SetAssetFolder1(string p_Value)
        {
            vm.SetAssetFolder1(p_Value);
        }

        public void SetDirHeader1(string p_Value)
        {
            vm.SetDirHeader1(p_Value);
        }

        public void SetFileHeader1(string p_Value)
        {
            vm.SetFileHeader1(p_Value);
        }

        public void SetTextHeader1(string p_Value)
        {
            vm.SetTextHeader1(p_Value);
        }
        
        public void SetDirHeader1C(string p_Value)
        {
            vm.SetDirHeader1C(p_Value);
        }

        public void SetFileHeader1C(string p_Value)
        {
            vm.SetFileHeader1C(p_Value);
        }

        public void SetTextHeader1C(string p_Value)
        {
            vm.SetTextHeader1C(p_Value);
        }
                
        public void SetCharHeader(string p_Value)
        {
            vm.SetCharHeader(p_Value);
        }

        public void SetSceneHeader(string p_Value)
        {
            vm.SetSceneHeader(p_Value);
        }
        
        public void SetCharHeaderC(string p_Value)
        {
            vm.SetCharHeaderC(p_Value);
        }

        public void SetSceneHeaderC(string p_Value)
        {
            vm.SetSceneHeaderC(p_Value);
        }
        
        public void SetHeadRowIndex(int p_Value)
        {
            vm.SetHeadRowIndex(p_Value);
        }
        
        public void SetEditorIndex(int p_Value)
        {
            vm.SetEditorIndex(p_Value);
        }

        public void SetTabIndex(int p_Value)
        {
            vm.SetTabIndex(p_Value);
        }

        public void SetDelayIndex(int p_Value)
        {
            vm.SetDelayIndex(p_Value);
        }
        
        public void SetDeviceIndex(int p_Value)
        {
            vm.SetDeviceIndex(p_Value);
        }
        public void SetAutoPlayChecked(bool p_Value)
        {
            vm.SetAutoPlayChecked(p_Value);
        }

        public void SetAutoStopChecked(bool p_Value)
        {
            vm.SetAutoStopChecked(p_Value);
        }

        public void SetDefaultDeviceChecked(bool p_Value)
        {
            vm.SetDefaultDeviceChecked(p_Value);
        }

        public void SetUsesDir1Checked(bool p_Value)
        {
            vm.SetUsesDir1Checked(p_Value);
        }
        
        public void ClearStatusText()
        {
            vm.ClearStatusText();
        }

        public void SetMetaHeaderC(string p_Value)
        {
            vm.SetMetaHeaderC(p_Value);
        }

        public void SetMetaHeader(string p_Value)
        {
            vm.SetMetaHeader(p_Value);
        }

        public void SetAddMetaDataChecked(bool p_Value)
        {
            vm.SetAddMetaDataChecked(p_Value);
        }

        #endregion

        #region public send functions

        public string SendRootText()
        {
            return vm.SendRootText();
        }

        public string SendEditorExe()
        {
            return vm.SendEditorExe();
        }

        public string SendAltSuffix()
        {
            return vm.SendAltSuffix();
        }

        public string SendDeviceName()
        {
            return vm.SendDeviceName();
        }
        
        public string SendAssetFolder1()
        {
            return vm.SendAssetFolder1();
        }

        public string SendDirHeader1()
        {
            return vm.SendDirHeader1();
        }

        public string SendFileHeader1()
        {
            return vm.SendFileHeader1();
        }

        public string SendTextHeader1()
        {
            return vm.SendTextHeader1();
        }
        
        public string SendCharHeader()
        {
            return vm.SendCharHeader();
        }

        public string SendSceneHeader()
        {
            return vm.SendSceneHeader();
        }
                
        public int SendHeadRowIndex()
        {
            return vm.SendHeadRowIndex();
        }
        
        public int SendEditorIndex()
        {
            return vm.SendEditorIndex();
        }

        public int SendTabIndex()
        {
            return vm.SendTabIndex();
        }

        public int SendDelayIndex()
        {
            return vm.SendDelayIndex();
        }

        public bool SendAutoPlayChecked()
        {
            return vm.SendAutoPlayChecked();
        }

        public bool SendAutoStopChecked()
        {
            return vm.SendAutoStopChecked();
        }

        public bool SendDefaultDeviceChecked()
        {
            return vm.SendDefaultDeviceChecked();
        }

        public bool SendUsesDir1Checked()
        {
            return vm.SendUsesDir1Checked();
        }


        public int SendHK11Index()
        {
            return vm.SendHK11Index();
        }
        public int SendHK12Index()
        {
            return vm.SendHK12Index();
        }
        public int SendHK21Index()
        {
            return vm.SendHK21Index();
        }
        public int SendHK22Index()
        {
            return vm.SendHK22Index();
        }
        public int SendHK31Index()
        {
            return vm.SendHK31Index();
        }
        public int SendHK32Index()
        {
            return vm.SendHK32Index();
        }
        
        public void SetHK11Index(int p_Value)
        {
            vm.SetHK11Index(p_Value);
        }
        public void SetHK12Index(int p_Value)
        {
            vm.SetHK12Index(p_Value);
        }
        public void SetHK21Index(int p_Value)
        {
            vm.SetHK21Index(p_Value);
        }
        public void SetHK22Index(int p_Value)
        {
            vm.SetHK22Index(p_Value);
        }
        public void SetHK31Index(int p_Value)
        {
            vm.SetHK31Index(p_Value);
        }
        public void SetHK32Index(int p_Value)
        {
            vm.SetHK32Index(p_Value);
        }

        public string SendMetaHeader()
        {
            return vm.SendMetaHeader();
        }

        public bool SendAddMetaDataChecked()
        {
            return vm.SendAddMetaDataChecked();
        }
        #endregion
    }
}
