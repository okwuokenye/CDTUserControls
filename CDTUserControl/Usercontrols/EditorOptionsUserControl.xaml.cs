using System;
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
            vm.RootChangeButtonEvent += Vm_RootChangeButtonEvent;
            vm.EditorExeChangeButtonEvent += Vm_EditorExeChangeButtonEvent;

            vm.SaveButtonEvent += Vm_SaveButtonEvent;
            vm.UpdateButtonEvent += Vm_UpdateButtonEvent;

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

        private void Vm_RootChangeButtonEvent()
        {
            RootChangeButtonEvent();
        }

        private void Vm_EditorExeChangeButtonEvent()
        {
            EditorExeChangeButtonEvent();
        }
        
        private void Vm_SaveButtonEvent()
        {
            SaveButtonEvent();
        }

        private void Vm_UpdateButtonEvent()
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
        
        #endregion
    }
}
