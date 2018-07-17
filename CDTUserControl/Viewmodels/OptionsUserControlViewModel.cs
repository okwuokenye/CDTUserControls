using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CDTUserControl.Viewmodels
{
    class OptionsUserControlViewModel : ObservableObject
    {
        #region private variables

        private string _RootText;
        private string _EditorExe;
        private string _StatusWarn;
        private string _VersionNumber;
        private string _AltSuffix;
        private string _DeviceName;
        private string _GlossaryFolder;
        private string _AssetFolder1;
        private string _DirHeader1;
        private string _FileHeader1;
        private string _TextHeader1;
        private string _AssetFolder2;
        private string _DirHeader2;
        private string _FileHeader2;
        private string _TextHeader2;
        private string _CharHeader;
        private string _SceneHeader;
        private string _ItemHeader;
        private string _VideoHeader;
        private string _MusicHeader;
        private string _SFXHeader;
        private string _LFXHeader;
        private string _TCValue;
        private string _TCRule;
        private string _DiffRangeText;
        private string _WPSText;
        private string _SynthVoice;

        private string _DirHeader1C;
        private string _FileHeader1C;
        private string _TextHeader1C;
        private string _DirHeader2C;
        private string _FileHeader2C;
        private string _TextHeader2C;
        private string _CharHeaderC;
        private string _SceneHeaderC;
        private string _ItemHeaderC;
        private string _VideoHeaderC;
        private string _MusicHeaderC;
        private string _SFXHeaderC;
        private string _LFXHeaderC;

        private int _HeadRowIndex;
        private int _TCDirection;
        private int _DiffRange;
        private int _WPS;
        private int _EditorIndex;
        private int _TabIndex;
        private int _DelayIndex;
        private int _VoiceIndex;
        private int _DeviceIndex;
        private bool _AutoPlayChecked;
        private bool _AutoStopChecked;
        private bool _DefaultDeviceChecked;
        private bool _UsesDir1Checked = true;
        private bool _UsesDir2Checked = true;
        private bool _TCPerCent;
        private bool _TCMS;

        ObservableCollection<String> _DeviceItems = new ObservableCollection<String>();
        ObservableCollection<String> _VoiceItems = new ObservableCollection<String>();
        ObservableCollection<String> _HeadRowItems = new ObservableCollection<String> {"1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20"};
        ObservableCollection<String> _TCDirectionItems = new ObservableCollection<String> {"Between -/+", "Shorter than +", "Longer than -"};
        ObservableCollection<String> _TabItems = new ObservableCollection<String> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
        ObservableCollection<String> _DelayItems = new ObservableCollection<String> {"20ms", "40ms", "60ms", "80ms", "100ms", "120ms", "140ms", "160ms", "180ms", "200ms"};
        ObservableCollection<String> _EditorItems = new ObservableCollection<String> { "Adobe Audition 3.0", "Adobe Audition CC"};


        public Visibility DeviceVisibility { get { return _DefaultDeviceChecked ? Visibility.Collapsed: Visibility.Visible; } }
        public Visibility Dir1Visibility { get { return _UsesDir1Checked ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility Dir2Visibility { get { return _UsesDir2Checked ? Visibility.Visible : Visibility.Collapsed; } }
        

        #endregion

        #region event declarations

        public delegate void RootChangeButtonEventHandler();
        public event RootChangeButtonEventHandler RootChangeButtonEvent;

        public delegate void EditorExeChangeButtonEventHandler();
        public event EditorExeChangeButtonEventHandler EditorExeChangeButtonEvent;

        public delegate void TCChangeEventHandler();
        public event TCChangeEventHandler TCChangeEvent;
        
        public delegate void SaveButtonEventHandler();
        public event SaveButtonEventHandler SaveButtonEvent;

        #endregion


        #region properties

        public String StatusWarn
        {
            get
            {
                return _StatusWarn;
            }
            set
            {
                if (_StatusWarn != value)
                {
                    _StatusWarn = value;
                    RaisePropertyChanged("StatusWarn");
                }
            }
        }
        
        public String VersionNumber
        {
            get
            {
                return _VersionNumber;
            }
            set
            {
                if (_VersionNumber != value)
                {
                    _VersionNumber = value;
                    RaisePropertyChanged("VersionNumber");
                }
            }
        }

        public String RootText
        {
            get
            {
                return _RootText;
            }
            set
            {
                if (_RootText != value)
                {
                    _RootText = value;
                    RaisePropertyChanged("RootText");
                }
            }
        }

        public String EditorExe
        {
            get
            {
                return _EditorExe;
            }
            set
            {
                if (_EditorExe != value)
                {
                    _EditorExe = value;
                    RaisePropertyChanged("EditorExe");
                }
            }
        }

        public String AltSuffix
        {
            get
            {
                return _AltSuffix;
            }
            set
            {
                if (_AltSuffix != value)
                {
                    _AltSuffix = value;
                    RaisePropertyChanged("AltSuffix");
                }
            }
        }

        public String DeviceName
        {
            get
            {
                return _DeviceName;
            }
            set
            {
                if (_DeviceName != value)
                {
                    _DeviceName = value;
                    RaisePropertyChanged("DeviceName");
                }
            }
        }

        public String GlossaryFolder
        {
            get
            {
                return _GlossaryFolder;
            }
            set
            {
                if (_GlossaryFolder != value)
                {
                    _GlossaryFolder = value;
                    RaisePropertyChanged("GlossaryFolder");
                }
            }
        }

        public String AssetFolder1
        {
            get
            {
                return _AssetFolder1;
            }
            set
            {
                if (_AssetFolder1 != value)
                {
                    _AssetFolder1 = value;
                    RaisePropertyChanged("AssetFolder1");
                }
            }
        }

        public String DirHeader1
        {
            get
            {
                return _DirHeader1;
            }
            set
            {
                if (_DirHeader1 != value)
                {
                    _DirHeader1 = value;
                    RaisePropertyChanged("DirHeader1");
                }
            }
        }

        public String FileHeader1
        {
            get
            {
                return _FileHeader1;
            }
            set
            {
                if (_FileHeader1 != value)
                {
                    _FileHeader1 = value;
                    RaisePropertyChanged("FileHeader1");
                }
            }
        }

        public String TextHeader1
        {
            get
            {
                return _TextHeader1;
            }
            set
            {
                if (_TextHeader1 != value)
                {
                    _TextHeader1 = value;
                    RaisePropertyChanged("TextHeader1");
                }
            }
        }


        public String DirHeader1C
        {
            get
            {
                return _DirHeader1C;
            }
            set
            {
                if (_DirHeader1C != value)
                {
                    _DirHeader1C = value;
                    RaisePropertyChanged("DirHeader1C");
                }
            }
        }

        public String FileHeader1C
        {
            get
            {
                return _FileHeader1C;
            }
            set
            {
                if (_FileHeader1C != value)
                {
                    _FileHeader1C = value;
                    RaisePropertyChanged("FileHeader1C");
                }
            }
        }

        public String TextHeader1C
        {
            get
            {
                return _TextHeader1C;
            }
            set
            {
                if (_TextHeader1C != value)
                {
                    _TextHeader1C = value;
                    RaisePropertyChanged("TextHeader1C");
                }
            }
        }


        public String AssetFolder2
        {
            get
            {
                return _AssetFolder2;
            }
            set
            {
                if (_AssetFolder2 != value)
                {
                    _AssetFolder2 = value;
                    RaisePropertyChanged("AssetFolder2");
                }
            }
        }

        public String DirHeader2
        {
            get
            {
                return _DirHeader2;
            }
            set
            {
                if (_DirHeader2 != value)
                {
                    _DirHeader2 = value;
                    RaisePropertyChanged("DirHeader2");
                }
            }
        }

        public String FileHeader2
        {
            get
            {
                return _FileHeader2;
            }
            set
            {
                if (_FileHeader2 != value)
                {
                    _FileHeader2 = value;
                    RaisePropertyChanged("FileHeader2");
                }
            }
        }

        public String TextHeader2
        {
            get
            {
                return _TextHeader2;
            }
            set
            {
                if (_TextHeader2 != value)
                {
                    _TextHeader2 = value;
                    RaisePropertyChanged("TextHeader2");
                }
            }
        }

        public String DirHeader2C
        {
            get
            {
                return _DirHeader2C;
            }
            set
            {
                if (_DirHeader2C != value)
                {
                    _DirHeader2C = value;
                    RaisePropertyChanged("DirHeader2C");
                }
            }
        }

        public String FileHeader2C
        {
            get
            {
                return _FileHeader2C;
            }
            set
            {
                if (_FileHeader2C != value)
                {
                    _FileHeader2C = value;
                    RaisePropertyChanged("FileHeader2C");
                }
            }
        }

        public String TextHeader2C
        {
            get
            {
                return _TextHeader2C;
            }
            set
            {
                if (_TextHeader2C != value)
                {
                    _TextHeader2C = value;
                    RaisePropertyChanged("TextHeader2C");
                }
            }
        }

        public String CharHeader
        {
            get
            {
                return _CharHeader;
            }
            set
            {
                if (_CharHeader != value)
                {
                    _CharHeader = value;
                    RaisePropertyChanged("CharHeader");
                }
            }
        }

        public String SceneHeader
        {
            get
            {
                return _SceneHeader;
            }
            set
            {
                if (_SceneHeader != value)
                {
                    _SceneHeader = value;
                    RaisePropertyChanged("SceneHeader");
                }
            }
        }

        public String ItemHeader
        {
            get
            {
                return _ItemHeader;
            }
            set
            {
                if (_ItemHeader != value)
                {
                    _ItemHeader = value;
                    RaisePropertyChanged("ItemHeader");
                }
            }
        }

        public String VideoHeader
        {
            get
            {
                return _VideoHeader;
            }
            set
            {
                if (_VideoHeader != value)
                {
                    _VideoHeader = value;
                    RaisePropertyChanged("VideoHeader");
                }
            }
        }

        public String MusicHeader
        {
            get
            {
                return _MusicHeader;
            }
            set
            {
                if (_MusicHeader != value)
                {
                    _MusicHeader = value;
                    RaisePropertyChanged("MusicHeader");
                }
            }
        }

        public String SFXHeader
        {
            get
            {
                return _SFXHeader;
            }
            set
            {
                if (_SFXHeader != value)
                {
                    _SFXHeader = value;
                    RaisePropertyChanged("SFXHeader");
                }
            }
        }

        public String LFXHeader
        {
            get
            {
                return _LFXHeader;
            }
            set
            {
                if (_LFXHeader != value)
                {
                    _LFXHeader = value;
                    RaisePropertyChanged("LFXHeader");
                }
            }
        }


        public String CharHeaderC
        {
            get
            {
                return _CharHeaderC;
            }
            set
            {
                if (_CharHeaderC != value)
                {
                    _CharHeaderC = value;
                    RaisePropertyChanged("CharHeaderC");
                }
            }
        }

        public String SceneHeaderC
        {
            get
            {
                return _SceneHeaderC;
            }
            set
            {
                if (_SceneHeaderC != value)
                {
                    _SceneHeaderC = value;
                    RaisePropertyChanged("SceneHeaderC");
                }
            }
        }

        public String ItemHeaderC
        {
            get
            {
                return _ItemHeaderC;
            }
            set
            {
                if (_ItemHeaderC != value)
                {
                    _ItemHeaderC = value;
                    RaisePropertyChanged("ItemHeaderC");
                }
            }
        }

        public String VideoHeaderC
        {
            get
            {
                return _VideoHeaderC;
            }
            set
            {
                if (_VideoHeaderC != value)
                {
                    _VideoHeaderC = value;
                    RaisePropertyChanged("VideoHeaderC");
                }
            }
        }

        public String MusicHeaderC
        {
            get
            {
                return _MusicHeaderC;
            }
            set
            {
                if (_MusicHeaderC != value)
                {
                    _MusicHeaderC = value;
                    RaisePropertyChanged("MusicHeaderC");
                }
            }
        }

        public String SFXHeaderC
        {
            get
            {
                return _SFXHeaderC;
            }
            set
            {
                if (_SFXHeaderC != value)
                {
                    _SFXHeaderC = value;
                    RaisePropertyChanged("SFXHeaderC");
                }
            }
        }

        public String LFXHeaderC
        {
            get
            {
                return _LFXHeaderC;
            }
            set
            {
                if (_LFXHeaderC != value)
                {
                    _LFXHeaderC = value;
                    RaisePropertyChanged("LFXHeaderC");
                }
            }
        }

        public String TCValue
        {
            get
            {
                return _TCValue;
            }
            set
            {
                if (_TCValue != value)
                {
                    _TCValue = value;
                    RaisePropertyChanged("TCValue");
                    TCChangeEvent();
                }
            }
        }
        public String TCRule
        {
            get
            {
                return _TCRule;
            }
            set
            {
                if (_TCRule != value)
                {
                    _TCRule = value;
                    RaisePropertyChanged("TCRule");
                }
            }
        }
        public String DiffRangeText
        {
            get
            {
                return _DiffRangeText;
            }
            set
            {
                if (_DiffRangeText != value)
                {
                    _DiffRangeText = value;
                    RaisePropertyChanged("DiffRangeText");
                }
            }
        }
        public String WPSText
        {
            get
            {
                return _WPSText;
            }
            set
            {
                if (_WPSText != value)
                {
                    _WPSText = value;
                    RaisePropertyChanged("WPSText");
                }
            }
        }
        public String SynthVoice
        {
            get
            {
                return _SynthVoice;
            }
            set
            {
                if (_SynthVoice != value)
                {
                    _SynthVoice = value;
                    RaisePropertyChanged("SynthVoice");
                }
            }
        }

        public bool AutoPlayChecked
        {
            get
            {
                return _AutoPlayChecked;
            }
            set
            {
                if (_AutoPlayChecked != value)
                {
                    _AutoPlayChecked = value;
                    RaisePropertyChanged("AutoPlayChecked");
                }
            }
        }

        public bool AutoStopChecked
        {
            get
            {
                return _AutoStopChecked;
            }
            set
            {
                if (_AutoStopChecked != value)
                {
                    _AutoStopChecked = value;
                    RaisePropertyChanged("AutoStopChecked");
                }
            }
        }
        public bool DefaultDeviceChecked
        {
            get
            {
                return _DefaultDeviceChecked;
            }
            set
            {
                if (_DefaultDeviceChecked != value)
                {
                    _DefaultDeviceChecked = value;
                    RaisePropertyChanged("DefaultDeviceChecked");
                    RaisePropertyChanged("DeviceVisibility");
                }
            }
        }
        public bool UsesDir1Checked
        {
            get
            {
                return _UsesDir1Checked;
            }
            set
            {
                if (_UsesDir1Checked != value)
                {
                    _UsesDir1Checked = value;
                    RaisePropertyChanged("UsesDir1Checked");
                    RaisePropertyChanged("Dir1Visibility");
                }
            }
        }
        public bool UsesDir2Checked
        {
            get
            {
                return _UsesDir2Checked;
            }
            set
            {
                if (_UsesDir2Checked != value)
                {
                    _UsesDir2Checked = value;
                    RaisePropertyChanged("UsesDir2Checked");
                    RaisePropertyChanged("Dir2Visibility");
                }
            }
        }
        public bool TCPerCent
        {
            get
            {
                return _TCPerCent;
            }
            set
            {
                if (_TCPerCent != value)
                {
                    _TCPerCent = value;
                    RaisePropertyChanged("TCPerCent");
                }
            }
        }

        public bool TCMS
        {
            get
            {
                return _TCMS;
            }
            set
            {
                if (_TCMS != value)
                {
                    _TCMS = value;
                    _TCPerCent = !value;
                    RaisePropertyChanged("TCMS");
                    TCChangeEvent();
                }
            }
        }

        public int HeadRowIndex
        {
            get
            {
                return _HeadRowIndex;
            }
            set
            {
                if (_HeadRowIndex != value)
                {
                    _HeadRowIndex = value;
                    RaisePropertyChanged("HeadRowIndex");
                }
            }
        }

        public int TCDirection
        {
            get
            {
                return _TCDirection;
            }
            set
            {
                if (_TCDirection != value)
                {
                    _TCDirection = value;
                    RaisePropertyChanged("TCDirection");
                    TCChangeEvent();
                }
            }
        }

        public int DiffRange
        {
            get
            {
                return _DiffRange;
            }
            set
            {
                if (_DiffRange != value)
                {
                    _DiffRange = value;
                    _DiffRangeText = value.ToString();
                    RaisePropertyChanged("DiffRange");
                    RaisePropertyChanged("DiffRangeText");
                }
            }
        }

        public int WPS
        {
            get
            {
                return _WPS;
            }
            set
            {
                if (_WPS != value)
                {
                    _WPS = value;
                    decimal div = Math.Round((decimal)_WPS/100,2);
                    _WPSText = div.ToString();
                    RaisePropertyChanged("WPS");
                    RaisePropertyChanged("WPSText");
                }
            }
        }

        public int EditorIndex
        {
            get
            {
                return _EditorIndex;
            }
            set
            {
                if (_EditorIndex != value)
                {
                    _EditorIndex = value;
                    RaisePropertyChanged("EditorIndex");
                }
            }
        }

        public int TabIndex
        {
            get
            {
                return _TabIndex;
            }
            set
            {
                if (_TabIndex != value)
                {
                    _TabIndex = value;
                    RaisePropertyChanged("TabIndex");
                }
            }
        }

        public int DelayIndex
        {
            get
            {
                return _DelayIndex;
            }
            set
            {
                if (_DelayIndex != value)
                {
                    _DelayIndex = value;
                    RaisePropertyChanged("DelayIndex");
                }
            }
        }

        public int DeviceIndex
        {
            get
            {
                return _DeviceIndex;
            }
            set
            {
                if (_DeviceIndex != value)
                {
                    _DeviceIndex = value;
                    RaisePropertyChanged("DeviceIndex");
                }
            }
        }

        public int VoiceIndex
        {
            get
            {
                return _VoiceIndex;
            }
            set
            {
                if (_VoiceIndex != value)
                {
                    _VoiceIndex = value;
                    RaisePropertyChanged("VoiceIndex");
                }
            }
        }

        public ObservableCollection<String> DeviceItems { get { return _DeviceItems; } }
        public ObservableCollection<String> VoiceItems { get { return _VoiceItems; } }
        public ObservableCollection<String> HeadRowItems { get { return _HeadRowItems; } }
        public ObservableCollection<String> TCDirectionItems { get { return _TCDirectionItems; } }
        public ObservableCollection<String> TabItems { get { return _TabItems; } }
        public ObservableCollection<String> DelayItems { get { return _DelayItems; } }
        public ObservableCollection<String> EditorItems { get { return _EditorItems; } }

        #endregion


        #region constructor

        public OptionsUserControlViewModel()
        {

        }

        #endregion

        #region private methods

        #endregion

        #region public set methods

        public void SetDeviceList(List<String> p_Devices)
        {
            _DeviceItems.Clear();
            foreach (var l_Device in p_Devices)
            {
                _DeviceItems.Add(l_Device);
            }
            RaisePropertyChanged("DeviceItems");
        }

        public void SetVoiceList(List<String> p_Voices)
        {
            _VoiceItems.Clear();
            foreach (var l_Voice in p_Voices)
            {
                _VoiceItems.Add(l_Voice);
            }
            RaisePropertyChanged("VoiceItems");
        }

        public void SetRootText(string p_Value)
        {
            _RootText = p_Value;
            RaisePropertyChanged("RootText");
        }

        public void SetEditorExe(string p_Value)
        {
            _EditorExe = p_Value;
            RaisePropertyChanged("EditorExe");
        }

        public void SetStatusWarn(string p_Value)
        {
            _StatusWarn = p_Value;
            RaisePropertyChanged("StatusWarn");
        }

        public void SetVersionNumber(string p_Value)
        {
            _VersionNumber = p_Value;
            RaisePropertyChanged("VersionNumber");
        }
        public void SetAltSuffix(string p_Value)
        {
            _AltSuffix = p_Value;
            RaisePropertyChanged("AltSuffix");
        }

        public void SetDeviceName(string p_Value)
        {
            _DeviceName = p_Value;
            RaisePropertyChanged("DeviceName");
        }

        public void SetGlossaryFolder(string p_Value)
        {
            _GlossaryFolder = p_Value;
            RaisePropertyChanged("GlossaryFolder");
        }

        public void SetAssetFolder1(string p_Value)
        {
            _AssetFolder1 = p_Value;
            RaisePropertyChanged("AssetFolder1");
        }

        public void SetDirHeader1(string p_Value)
        {
            _DirHeader1 = p_Value;
            RaisePropertyChanged("DirHeader1");
        }

        public void SetFileHeader1(string p_Value)
        {
            _FileHeader1 = p_Value;
            RaisePropertyChanged("FileHeader1");
        }

        public void SetTextHeader1(string p_Value)
        {
            _TextHeader1 = p_Value;
            RaisePropertyChanged("TextHeader1");
        }

        public void SetDirHeader1C(string p_Value)
        {
            _DirHeader1C = p_Value;
            RaisePropertyChanged("DirHeader1C");
        }

        public void SetFileHeader1C(string p_Value)
        {
            _FileHeader1C = p_Value;
            RaisePropertyChanged("FileHeader1C");
        }

        public void SetTextHeader1C(string p_Value)
        {
            _TextHeader1C = p_Value;
            RaisePropertyChanged("TextHeader1C");
        }

        public void SetAssetFolder2(string p_Value)
        {
            _AssetFolder2 = p_Value;
            RaisePropertyChanged("AssetFolder2");
        }

        public void SetDirHeader2(string p_Value)
        {
            _DirHeader2 = p_Value;
            RaisePropertyChanged("DirHeader2");
        }

        public void SetFileHeader2(string p_Value)
        {
            _FileHeader2 = p_Value;
            RaisePropertyChanged("FileHeader2");
        }

        public void SetTextHeader2(string p_Value)
        {
            _TextHeader2 = p_Value;
            RaisePropertyChanged("TextHeader2");
        }

        public void SetDirHeader2C(string p_Value)
        {
            _DirHeader2C = p_Value;
            RaisePropertyChanged("DirHeader2C");
        }

        public void SetFileHeader2C(string p_Value)
        {
            _FileHeader2C = p_Value;
            RaisePropertyChanged("FileHeader2C");
        }

        public void SetTextHeader2C(string p_Value)
        {
            _TextHeader2C = p_Value;
            RaisePropertyChanged("TextHeader2C");
        }


        public void SetCharHeader(string p_Value)
        {
            _CharHeader = p_Value;
            RaisePropertyChanged("CharHeader");
        }

        public void SetSceneHeader(string p_Value)
        {
            _SceneHeader = p_Value;
            RaisePropertyChanged("SceneHeader");
        }

        public void SetItemHeader(string p_Value)
        {
            _ItemHeader = p_Value;
            RaisePropertyChanged("ItemHeader");
        }

        public void SetVideoHeader(string p_Value)
        {
            _VideoHeader = p_Value;
            RaisePropertyChanged("VideoHeader");
        }

        public void SetMusicHeader(string p_Value)
        {
            _MusicHeader = p_Value;
            RaisePropertyChanged("MusicHeader");
        }

        public void SetSFXHeader(string p_Value)
        {
            _SFXHeader = p_Value;
            RaisePropertyChanged("SFXHeader");
        }

        public void SetLFXHeader(string p_Value)
        {
            _LFXHeader = p_Value;
            RaisePropertyChanged("LFXHeader");
        }


        public void SetCharHeaderC(string p_Value)
        {
            _CharHeaderC = p_Value;
            RaisePropertyChanged("CharHeaderC");
        }

        public void SetSceneHeaderC(string p_Value)
        {
            _SceneHeaderC = p_Value;
            RaisePropertyChanged("SceneHeaderC");
        }

        public void SetItemHeaderC(string p_Value)
        {
            _ItemHeaderC = p_Value;
            RaisePropertyChanged("ItemHeaderC");
        }

        public void SetVideoHeaderC(string p_Value)
        {
            _VideoHeaderC = p_Value;
            RaisePropertyChanged("VideoHeaderC");
        }

        public void SetMusicHeaderC(string p_Value)
        {
            _MusicHeaderC = p_Value;
            RaisePropertyChanged("MusicHeaderC");
        }

        public void SetSFXHeaderC(string p_Value)
        {
            _SFXHeaderC = p_Value;
            RaisePropertyChanged("SFXHeaderC");
        }

        public void SetLFXHeaderC(string p_Value)
        {
            _LFXHeaderC = p_Value;
            RaisePropertyChanged("LFXHeaderC");
        }



        public void SetTCValue(string p_Value)
        {
            _TCValue = p_Value;
            RaisePropertyChanged("TCValue");
        }

        public void SetTCRule(string p_Value)
        {
            _TCRule = p_Value;
            RaisePropertyChanged("TCRule");
        }
        public void SetDiffRangeText(string p_Value)
        {
            _DiffRangeText = p_Value;
            RaisePropertyChanged("DiffRangeText");
        }

        public void SetWPSText(string p_Value)
        {
            _WPSText = p_Value;
            RaisePropertyChanged("WPSText");
        }

        public void SetSynthVoice(string p_Value)
        {
            _SynthVoice = p_Value;
            RaisePropertyChanged("SynthVoice");
        }

        public void SetHeadRowIndex(int p_Value)
        {
            _HeadRowIndex = p_Value;
            RaisePropertyChanged("HeadRowIndex");
        }

        public void SetTCDirection(int p_Value)
        {
            _TCDirection = p_Value;
            RaisePropertyChanged("TCDirection");
        }

        public void SetDiffRange(int p_Value)
        {
            _DiffRange = p_Value;
            _DiffRangeText = p_Value.ToString();
            RaisePropertyChanged("DiffRange");
            RaisePropertyChanged("DiffRangeText");
        }

        public void SetWPS(int p_Value)
        {
            _WPS = p_Value;
            decimal div = Math.Round((decimal)p_Value / 100, 2);
            _WPSText = div.ToString();
            RaisePropertyChanged("WPS");
            RaisePropertyChanged("WPSText");
        }

        public void SetEditorIndex(int p_Value)
        {
            _EditorIndex = p_Value;
            RaisePropertyChanged("EditorIndex");
        }

        public void SetTabIndex(int p_Value)
        {
            _TabIndex = p_Value;
            RaisePropertyChanged("TabIndex");
        }

        public void SetDelayIndex(int p_Value)
        {
            _DelayIndex = p_Value;
            RaisePropertyChanged("DelayIndex");
        }
        
        public void SetDeviceIndex(int p_Value)
        {
            _DeviceIndex = p_Value;
            RaisePropertyChanged("DeviceIndex");
        }

        public void SetVoiceIndex(int p_Value)
        {
            _VoiceIndex = p_Value;
            RaisePropertyChanged("VoiceIndex");
        }

        public void SetAutoPlayChecked(bool p_Value)
        {
            _AutoPlayChecked = p_Value;
            RaisePropertyChanged("AutoPlayChecked");
        }

        public void SetAutoStopChecked(bool p_Value)
        {
            _AutoStopChecked = p_Value;
            RaisePropertyChanged("AutoStopChecked");
        }

        public void SetDefaultDeviceChecked(bool p_Value)
        {
            _DefaultDeviceChecked = p_Value;
            RaisePropertyChanged("DefaultDeviceChecked");
        }

        public void SetUsesDir1Checked(bool p_Value)
        {
            _UsesDir1Checked = p_Value;
            RaisePropertyChanged("UsesDir1Checked");
        }

        public void SetUsesDir2Checked(bool p_Value)
        {
            _UsesDir2Checked = p_Value;
            RaisePropertyChanged("UsesDir2Checked");
        }

        public void SetTCPerCent(bool p_Value)
        {
            _TCPerCent = p_Value;
            RaisePropertyChanged("TCPerCent");
        }

        public void SetTCMS(bool p_Value)
        {
            _TCMS = p_Value;
            RaisePropertyChanged("TCMS");
        }

        public void ClearStatusText()
        {
            _StatusWarn = "";
            RaisePropertyChanged("StatusWarn");
        }


        #endregion

        #region commands

        private void RootChangeExecute()
        {
            RootChangeButtonEvent();
        }
        public ICommand RootChange { get { return new RelayCommand(RootChangeExecute); } }

        private void EditorExeChangeExecute()
        {
            EditorExeChangeButtonEvent();
        }
        public ICommand EditorExeChange { get { return new RelayCommand(EditorExeChangeExecute); } }

        private void SaveExecute()
        {
            SaveButtonEvent();
        }
        public ICommand SaveButton { get { return new RelayCommand(SaveExecute); } }

        #endregion

        #region public send functions

        public string SendRootText()
        {
            return RootText;
        }

        public string SendEditorExe()
        {
            return EditorExe;
        }

        public string SendAltSuffix()
        {
            return AltSuffix;
        }

        public string SendDeviceName()
        {
            return DeviceName;
        }

        public string SendGlossaryFolder()
        {
            return GlossaryFolder;
        }

        public string SendAssetFolder1()
        {
            return AssetFolder1;
        }

        public string SendDirHeader1()
        {
            return DirHeader1;
        }

        public string SendFileHeader1()
        {
            return FileHeader1;
        }

        public string SendTextHeader1()
        {
            return TextHeader1;
        }

        public string SendAssetFolder2()
        {
            return AssetFolder2;
        }

        public string SendDirHeader2()
        {
            return DirHeader2;
        }

        public string SendFileHeader2()
        {
            return FileHeader2;
        }

        public string SendTextHeader2()
        {
            return TextHeader2;
        }

        public string SendCharHeader()
        {
            return CharHeader;
        }

        public string SendSceneHeader()
        {
            return SceneHeader;
        }

        public string SendItemHeader()
        {
            return ItemHeader;
        }

        public string SendVideoHeader()
        {
            return VideoHeader;
        }

        public string SendMusicHeader()
        {
            return MusicHeader;
        }

        public string SendSFXHeader()
        {
            return SFXHeader;
        }

        public string SendLFXHeader()
        {
            return LFXHeader;
        }

        public string SendTCValue()
        {
            return TCValue;
        }

        public string SendDiffRangeText()
        {
            return DiffRangeText;
        }

        public string SendWPSText()
        {
            return WPSText;
        }

        public string SendSynthVoice()
        {
            return SynthVoice;
        }

        public int SendHeadRowIndex()
        {
            return HeadRowIndex;
        }

        public int SendTCDirection()
        {
            return TCDirection;
        }

        public int SendDiffRange()
        {
            return DiffRange;
        }

        public int SendWPS()
        {
            return WPS;
        }

        public int SendEditorIndex()
        {
            return EditorIndex;
        }

        public int SendTabIndex()
        {
            return TabIndex;
        }

        public int SendDelayIndex()
        {
            return DelayIndex;
        }

        public bool SendAutoPlayChecked()
        {
            return AutoPlayChecked;
        }

        public bool SendAutoStopChecked()
        {
            return AutoStopChecked;
        }

        public bool SendDefaultDeviceChecked()
        {
            return DefaultDeviceChecked;
        }

        public bool SendUsesDir1Checked()
        {
            return UsesDir1Checked;
        }

        public bool SendUsesDir2Checked()
        {
            return UsesDir2Checked;
        }

        public bool SendTCMS()
        {
            return TCMS;
        }

        #endregion


    }
}
