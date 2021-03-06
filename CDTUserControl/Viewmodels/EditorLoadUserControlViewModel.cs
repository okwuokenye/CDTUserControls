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
    class EditorLoadUserControlViewModel : ObservableObject
    {
        #region private variables

        private string _RootText;
        private string _EditorExe;
        private string _StatusWarn;
        private int _EditorIndex;
        private bool _UsesDir1Checked = true;
        private bool _AddMetaDataChecked = true;

        private string _AssetFolder1;
        private string _DirHeader1;
        private string _FileHeader1;
        private string _TextHeader1;
        private string _CharHeader;
        private string _SceneHeader;
        private string _MetaHeader;

        private string _DirHeader1C;
        private string _FileHeader1C;
        private string _TextHeader1C;
        private string _CharHeaderC;
        private string _SceneHeaderC;
        private string _MetaHeaderC;

        ObservableCollection<String> _EditorItems = new ObservableCollection<String> { "Adobe Audition 3.0", "Adobe Audition CC"};
        
        public Visibility Dir1Visibility { get { return _UsesDir1Checked ? Visibility.Visible : Visibility.Collapsed; } }

        public Visibility MetaVisibility { get { return _AddMetaDataChecked ? Visibility.Visible : Visibility.Collapsed; } }

        private string _ExampleChar;
        private string _ExampleScene;
        private string _ExampleFilename;
        private string _ExampleText;
        private string _ExamplePath;
        private string _ExampleMeta;


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

        public delegate void EditorChangedEventHandler();
        public event EditorChangedEventHandler EditorChangedEvent;

        public delegate void ExitButtonEventHandler();
        public event ExitButtonEventHandler ExitButtonEvent;

        public delegate void LoadButtonEventHandler();
        public event LoadButtonEventHandler LoadButtonEvent;
        #endregion


        #region properties

        public String ExampleMeta
        {
            get
            {
                return _ExampleMeta;
            }
            set
            {
                if (_ExampleMeta != value)
                {
                    _ExampleMeta = value;
                    RaisePropertyChanged("ExampleMeta");
                }
            }
        }
        public String ExampleChar
        {
            get
            {
                return _ExampleChar;
            }
            set
            {
                if (_ExampleChar != value)
                {
                    _ExampleChar = value;
                    RaisePropertyChanged("ExampleChar");
                }
            }
        }
        public String ExampleText
        {
            get
            {
                return _ExampleText;
            }
            set
            {
                if (_ExampleText != value)
                {
                    _ExampleText = value;
                    RaisePropertyChanged("ExampleText");
                }
            }
        }
        public String ExampleFilename
        {
            get
            {
                return _ExampleFilename;
            }
            set
            {
                if (_ExampleFilename != value)
                {
                    _ExampleFilename = value;
                    RaisePropertyChanged("ExampleFilename");
                }
            }
        }
        public String ExamplePath
        {
            get
            {
                return _ExamplePath;
            }
            set
            {
                if (_ExamplePath != value)
                {
                    _ExamplePath = value;
                    RaisePropertyChanged("ExamplePath");
                }
            }
        }
        public String ExampleScene
        {
            get
            {
                return _ExampleScene;
            }
            set
            {
                if (_ExampleScene != value)
                {
                    _ExampleScene = value;
                    RaisePropertyChanged("ExampleScene");
                }
            }
        }
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

        public String MetaHeader
        {
            get
            {
                return _MetaHeader;
            }
            set
            {
                if (_MetaHeader != value)
                {
                    _MetaHeader = value;
                    RaisePropertyChanged("MetaHeader");
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

        public String MetaHeaderC
        {
            get
            {
                return _MetaHeaderC;
            }
            set
            {
                if (_MetaHeaderC != value)
                {
                    _MetaHeaderC = value;
                    RaisePropertyChanged("MetaHeaderC");
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

        public bool AddMetaDataChecked
        {
            get
            {
                return _AddMetaDataChecked;
            }
            set
            {
                if (_AddMetaDataChecked != value)
                {
                    _AddMetaDataChecked = value;
                    RaisePropertyChanged("AddMetaDataChecked");
                    RaisePropertyChanged("MetaVisibility");
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
                
        public ObservableCollection<String> EditorItems { get { return _EditorItems; } }

        #endregion


        #region constructor

        public EditorLoadUserControlViewModel()
        {

        }

        #endregion

        #region private methods

        #endregion

        #region public set methods
        
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

        public void SetMetaHeader(string p_Value)
        {
            _MetaHeader = p_Value;
            RaisePropertyChanged("MetaHeader");
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

        public void SetMetaHeaderC(string p_Value)
        {
            _MetaHeaderC = p_Value;
            RaisePropertyChanged("MetaHeaderC");
        }

        public void SetEditorIndex(int p_Value)
        {
            _EditorIndex = p_Value;
            RaisePropertyChanged("EditorIndex");
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

        public void SetExampleChar(string p_value)
        {
            _ExampleChar = p_value;
            RaisePropertyChanged("ExampleChar");
        }
        public void SetExampleScene(string p_value)
        {
            _ExampleScene = p_value;
            RaisePropertyChanged("ExampleScene");
        }
        public void SetExamplePath(string p_value)
        {
            _ExamplePath = p_value;
            RaisePropertyChanged("ExamplePath");
        }
        public void SetExampleFilename(string p_value)
        {
            _ExampleFilename = p_value;
            RaisePropertyChanged("ExampleFilename");
        }
        public void SetExampleText(string p_value)
        {
            _ExampleText = p_value;
            RaisePropertyChanged("ExampleText");
        }

        public void SetExampleMeta(string p_value)
        {
            _ExampleMeta = p_value;
            RaisePropertyChanged("ExampleMeta");
        }
        public void SetAddMetaDataChecked(bool p_Value)
        {
            _AddMetaDataChecked = p_Value;
            RaisePropertyChanged("AddMetaDataChecked");
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
        
        private void LoadExecute()
        {
            LoadButtonEvent();
        }
        public ICommand LoadButton { get { return new RelayCommand(LoadExecute); } }


        private void ExitExecute()
        {
            ExitButtonEvent();
        }
        public ICommand ExitButton { get { return new RelayCommand(ExitExecute); } }

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

        public string SendMetaHeader()
        {
            return MetaHeader;
        }
        public int SendEditorIndex()
        {
            return EditorIndex;
        }
        
        public bool SendUsesDir1Checked()
        {
            return UsesDir1Checked;
        }

        public bool SendAddMetaDataChecked()
        {
            return AddMetaDataChecked;
        }

        public void LoadVisible()
        {
            RaisePropertyChanged("Dir1Visibility");
            RaisePropertyChanged("MetaVisibility");
        }

        #endregion


    }
}
