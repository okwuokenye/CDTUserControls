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
    /// Interaction logic for EditorLoadUserControl.xaml
    /// </summary>
    public partial class EditLoadUserControl : UserControl
    {
        EditorLoadUserControlViewModel vm;

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

        public EditLoadUserControl()
        {
            EnsureApplicationResources();
            InitializeComponent();
            vm = new EditorLoadUserControlViewModel();

            //add event listeners
            vm.RootChangeButtonEvent += Vm_RootChangeButtonEvent;
            vm.EditorExeChangeButtonEvent += Vm_EditorExeChangeButtonEvent;

            vm.SaveButtonEvent += Vm_SaveButtonEvent;
            vm.ExitButtonEvent += Vm_ExitButtonEvent;
            vm.LoadButtonEvent += Vm_LoadButtonEvent;

            vm.EditorChangedEvent += Vm_EditorChangedEvent;


            base.DataContext = vm;
        }

        #endregion
        
        #region event declarations

        public delegate void RootChangeButtonEventHandler();
        public event RootChangeButtonEventHandler RootChangeButtonEvent;

        public delegate void EditorExeChangeButtonEventHandler();
        public event EditorExeChangeButtonEventHandler EditorExeChangeButtonEvent;
        
        public delegate void SaveButtonEventHandler();
        public event SaveButtonEventHandler SaveButtonEvent;

        public delegate void ExitButtonEventHandler();
        public event ExitButtonEventHandler ExitButtonEvent;

        public delegate void LoadButtonEventHandler();
        public event LoadButtonEventHandler LoadButtonEvent;

        public delegate void EditorChangedEventHandler();
        public event EditorChangedEventHandler EditorChangedEvent;
        

        #endregion
        
        #region event handlers
        
        private void Vm_RootChangeButtonEvent()
        {
            RootChangeButtonEvent();
        }

        private void Vm_EditorExeChangeButtonEvent()
        {
            EditorExeChangeButtonEvent();
        }


        private void Vm_ExitButtonEvent()
        {
            ExitButtonEvent();
        }

        private void Vm_LoadButtonEvent()
        {
            LoadButtonEvent();
        }

        private void Vm_SaveButtonEvent()
        {
            SaveButtonEvent();
        }

        private void Vm_EditorChangedEvent()
        {
            EditorChangedEvent();
        }

        #endregion

        #region public set functions
        
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
        
        public void SetCharHeaderC(string p_Value)
        {
            vm.SetCharHeaderC(p_Value);
        }
        
        public void SetSceneHeader(string p_Value)
        {
            vm.SetSceneHeader(p_Value);
        }

        public void SetSceneHeaderC(string p_Value)
        {
            vm.SetSceneHeaderC(p_Value);
        }

        public void SetEditorIndex(int p_Value)
        {
            vm.SetEditorIndex(p_Value);
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
        public int SendEditorIndex()
        {
            return vm.SendEditorIndex();
        }
        
        
        public bool SendUsesDir1Checked()
        {
            return vm.SendUsesDir1Checked();
        }
        
        #endregion
    }
}
