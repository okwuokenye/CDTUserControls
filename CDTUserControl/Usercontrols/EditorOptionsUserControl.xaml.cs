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

        public delegate void TCChangeEventHandler();
        public event TCChangeEventHandler TCChangeEvent;
        
        public delegate void SaveButtonEventHandler();
        public event SaveButtonEventHandler SaveButtonEvent;
        
        public delegate void EditorChangedEventHandler();
        public event EditorChangedEventHandler EditorChangedEvent;

        

        #endregion

        #region constructor

        public EditorOptionsUserControl()
        {
            InitializeComponent();
            vm = new EditorOptionsUserControlViewModel();

            //add event listeners
            vm.RootChangeButtonEvent += Vm_RootChangeButtonEvent;
            vm.EditorExeChangeButtonEvent += Vm_EditorExeChangeButtonEvent;
            vm.TCChangeEvent += Vm_TCChangeEvent;

            vm.SaveButtonEvent += Vm_SaveButtonEvent;

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
        
        private void Vm_TCChangeEvent()
        {
            TCChangeEvent();
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
        public void SetDeviceList(List<String> p_Devices)
        {
            vm.SetDeviceList(p_Devices);
        }
        public void SetVoiceList(List<String> p_Voices)
        {
            vm.SetVoiceList(p_Voices);
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

        public void SetGlossaryFolder(string p_Value)
        {
            vm.SetGlossaryFolder(p_Value);
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

        public void SetAssetFolder2(string p_Value)
        {
            vm.SetAssetFolder2(p_Value);
        }

        public void SetDirHeader2(string p_Value)
        {
            vm.SetDirHeader2(p_Value);
        }

        public void SetFileHeader2(string p_Value)
        {
            vm.SetFileHeader2(p_Value);
        }

        public void SetTextHeader2(string p_Value)
        {
            vm.SetTextHeader2(p_Value);
        }

        public void SetDirHeader2C(string p_Value)
        {
            vm.SetDirHeader2C(p_Value);
        }

        public void SetFileHeader2C(string p_Value)
        {
            vm.SetFileHeader2C(p_Value);
        }

        public void SetTextHeader2C(string p_Value)
        {
            vm.SetTextHeader2C(p_Value);
        }
        public void SetCharHeader(string p_Value)
        {
            vm.SetCharHeader(p_Value);
        }

        public void SetSceneHeader(string p_Value)
        {
            vm.SetSceneHeader(p_Value);
        }

        public void SetItemHeader(string p_Value)
        {
            vm.SetItemHeader(p_Value);
        }

        public void SetVideoHeader(string p_Value)
        {
            vm.SetVideoHeader(p_Value);
        }

        public void SetMusicHeader(string p_Value)
        {
            vm.SetMusicHeader(p_Value);
        }

        public void SetSFXHeader(string p_Value)
        {
            vm.SetSFXHeader(p_Value);
        }

        public void SetLFXHeader(string p_Value)
        {
            vm.SetLFXHeader(p_Value);
        }
        public void SetCharHeaderC(string p_Value)
        {
            vm.SetCharHeaderC(p_Value);
        }

        public void SetSceneHeaderC(string p_Value)
        {
            vm.SetSceneHeaderC(p_Value);
        }

        public void SetItemHeaderC(string p_Value)
        {
            vm.SetItemHeaderC(p_Value);
        }

        public void SetVideoHeaderC(string p_Value)
        {
            vm.SetVideoHeaderC(p_Value);
        }

        public void SetMusicHeaderC(string p_Value)
        {
            vm.SetMusicHeaderC(p_Value);
        }

        public void SetSFXHeaderC(string p_Value)
        {
            vm.SetSFXHeaderC(p_Value);
        }

        public void SetLFXHeaderC(string p_Value)
        {
            vm.SetLFXHeaderC(p_Value);
        }
        public void SetTCValue(string p_Value)
        {
            vm.SetTCValue(p_Value);
        }

        public void SetTCRule(string p_Value)
        {
            vm.SetTCRule(p_Value);
        }

        public void SetDiffRangeText(string p_Value)
        {
            vm.SetDiffRangeText(p_Value);
        }

        public void SetWPSText(string p_Value)
        {
            vm.SetWPSText(p_Value);
        }

        public void SetSynthVoice(string p_Value)
        {
            vm.SetSynthVoice(p_Value);
        }

        public void SetHeadRowIndex(int p_Value)
        {
            vm.SetHeadRowIndex(p_Value);
        }

        public void SetTCDirection(int p_Value)
        {
            vm.SetTCDirection(p_Value);
        }

        public void SetDiffRange(int p_Value)
        {
            vm.SetDiffRange(p_Value);
        }

        public void SetWPS(int p_Value)
        {
            vm.SetWPS(p_Value);
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

        public void SetVoiceIndex(int p_Value)
        {
            vm.SetVoiceIndex(p_Value);
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

        public void SetUsesDir2Checked(bool p_Value)
        {
            vm.SetUsesDir2Checked(p_Value);
        }

        public void SetTCPerCent(bool p_Value)
        {
            vm.SetTCPerCent(p_Value);
        }

        public void SetTCMS(bool p_Value)
        {
            vm.SetTCMS(p_Value);
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

        public string SendGlossaryFolder()
        {
            return vm.SendGlossaryFolder();
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

        public string SendAssetFolder2()
        {
            return vm.SendAssetFolder2();
        }

        public string SendDirHeader2()
        {
            return vm.SendDirHeader2();
        }

        public string SendFileHeader2()
        {
            return vm.SendFileHeader2();
        }

        public string SendTextHeader2()
        {
            return vm.SendTextHeader2();
        }

        public string SendCharHeader()
        {
            return vm.SendCharHeader();
        }

        public string SendSceneHeader()
        {
            return vm.SendSceneHeader();
        }

        public string SendItemHeader()
        {
            return vm.SendItemHeader();
        }

        public string SendVideoHeader()
        {
            return vm.SendVideoHeader();
        }

        public string SendMusicHeader()
        {
            return vm.SendMusicHeader();
        }

        public string SendSFXHeader()
        {
            return vm.SendSFXHeader();
        }

        public string SendLFXHeader()
        {
            return vm.SendLFXHeader();
        }

        public string SendTCValue()
        {
            return vm.SendTCValue();
        }

        public string SendDiffRangeText()
        {
            return vm.SendDiffRangeText();
        }

        public string SendWPSText()
        {
            return vm.SendWPSText();
        }

        public string SendSynthVoice()
        {
            return vm.SendSynthVoice();
        }

        public int SendHeadRowIndex()
        {
            return vm.SendHeadRowIndex();
        }

        public int SendTCDirection()
        {
            return vm.SendTCDirection();
        }

        public int SendDiffRange()
        {
            return vm.SendDiffRange();
        }

        public int SendWPS()
        {
            return vm.SendWPS();
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

        public bool SendUsesDir2Checked()
        {
            return vm.SendUsesDir2Checked();
        }

        public bool SendTCMS()
        {
            return vm.SendTCMS();
        }

        #endregion
    }
}
