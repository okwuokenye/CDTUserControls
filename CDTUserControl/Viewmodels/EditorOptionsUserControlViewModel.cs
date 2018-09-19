﻿using System;
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
    class EditorOptionsUserControlViewModel : ObservableObject
    {
        #region private variables

        private string _RootText;
        private string _EditorExe;
        private string _StatusWarn;
        private string _VersionNumber;
        private string _AltSuffix;
        private string _DeviceName;
        private string _AssetFolder1;
        private string _DirHeader1;
        private string _FileHeader1;
        private string _TextHeader1;
        private string _CharHeader;
        private string _SceneHeader;

        private string _DirHeader1C;
        private string _FileHeader1C;
        private string _TextHeader1C;
        private string _CharHeaderC;
        private string _SceneHeaderC;

        private int _HeadRowIndex;
        private int _EditorIndex;
        private int _TabIndex;
        private int _DelayIndex;
        private int _DeviceIndex;
        private bool _AutoPlayChecked;
        private bool _AutoStopChecked;
        private bool _DefaultDeviceChecked;
        private bool _UsesDir1Checked = true;

        ObservableCollection<String> _DeviceItems = new ObservableCollection<String>();
                ObservableCollection<String> _HeadRowItems = new ObservableCollection<String> {"1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20"};
        ObservableCollection<String> _TabItems = new ObservableCollection<String> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
        ObservableCollection<String> _DelayItems = new ObservableCollection<String> {"20ms", "40ms", "60ms", "80ms", "100ms", "120ms", "140ms", "160ms", "180ms", "200ms"};
        ObservableCollection<String> _EditorItems = new ObservableCollection<String> { "Adobe Audition 3.0", "Adobe Audition CC"};

        public Visibility DeviceVisibility { get { return _DefaultDeviceChecked ? Visibility.Collapsed: Visibility.Visible; } }
        public Visibility Dir1Visibility { get { return _UsesDir1Checked ? Visibility.Visible : Visibility.Collapsed; } }        

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

        public delegate void UpdateButtonEventHandler();
        public event UpdateButtonEventHandler UpdateButtonEvent;

        public delegate void EditorChangedEventHandler();
        public event EditorChangedEventHandler EditorChangedEvent;

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
                    EditorChangedEvent();
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
        
        public ObservableCollection<String> DeviceItems { get { return _DeviceItems; } }
        public ObservableCollection<String> HeadRowItems { get { return _HeadRowItems; } }
        public ObservableCollection<String> TabItems { get { return _TabItems; } }
        public ObservableCollection<String> DelayItems { get { return _DelayItems; } }
        public ObservableCollection<String> EditorItems { get { return _EditorItems; } }

        #endregion


        #region constructor

        public EditorOptionsUserControlViewModel()
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
        
        
        public void SetHeadRowIndex(int p_Value)
        {
            _HeadRowIndex = p_Value;
            RaisePropertyChanged("HeadRowIndex");
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

        private void UpdateExecute()
        {
            UpdateButtonEvent();
        }
        public ICommand UpdateButton { get { return new RelayCommand(UpdateExecute); } }
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
        
        public string SendCharHeader()
        {
            return CharHeader;
        }

        public string SendSceneHeader()
        {
            return SceneHeader;
        }
        
        
        public int SendHeadRowIndex()
        {
            return HeadRowIndex;
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
        
        #endregion


    }
}
