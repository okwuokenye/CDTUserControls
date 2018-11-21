using CDTUserControl.Usercontrols;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;
using System.Windows.Media;
using System.Windows;

namespace CDTUserControl.Viewmodels
{
    public class QualityAssuranceViewModel : ObservableObject
    {
        #region Events

        public delegate void LockEventHandler(Boolean p_Value);
        public event LockEventHandler LockEvent;

        public delegate void ResetEventHandler();
        public event ResetEventHandler ResetEvent;

        public delegate void CheckFilesEventHandler(QualityAssuranceViewModel vm);
        public event CheckFilesEventHandler CheckFilesEvent;

        public delegate void CompareColumnsEventHandler();
        public event CompareColumnsEventHandler CompareColumnsEvent;

        public delegate void UpdateHeadersEventHandler();
        public event UpdateHeadersEventHandler UpdateHeadersEvent;

        public delegate void FindAssetsEventHandler();
        public event FindAssetsEventHandler FindAssetsEvent;

        public delegate void MarkDuplicatesEventHandler();
        public event MarkDuplicatesEventHandler MarkDuplicatesEvent;

        public delegate void InsertDataEventHandler();
        public event InsertDataEventHandler InsertDataEvent;

        #endregion

        #region private variables
        string _StatusPane;
        private ColorPickerWindow _colorPicker;

            #region Mark Missing
                private bool _MarkMissingFiles = true;
                private bool _MarkCorruptedFiles = false;
                private bool _CountFiles = false;
                private bool _AddResultColumn = false;
                private bool _MarkPossMissedits = false;
                private bool _FindLostPrimaries = false;
                private bool _ReorderAltFiles = false;
                private bool _TrimSpacesFromFile = false;
        
                private bool _IsSecondaryChecked = false;
                private bool _IsVideoChecked = false;
                private bool _IsSelectionChecked = false;
                private bool _IsCreateLogSheet = true;

                string _RowsChecked = string.Empty;
                string _MissingFiles = string.Empty;
                string _CorruptedFiles = string.Empty;
                string _FilesTrimmed = string.Empty;
                string _MisEditedFiles = string.Empty;
                string _PrimaryTakesFound = string.Empty;
                string _FilesCounted = string.Empty;
                string _AltsReordered = string.Empty;
                string _OverallResult = string.Empty;


                Color? _Color1;
                Color? _Color2;
                Color? _Color3;
                Color? _Color4;
                Color? _Color5;
                Color? _Color6;

        private Brush _BrushColor1;
        public Brush BrushColor1 {
            get { return _BrushColor1; }
            set
            {
                if (_BrushColor1 != value)
                {
                    _BrushColor1 = value;
                    RaisePropertyChanged("BrushColor1");
                }
            }
        }
        
        private Brush _BrushColor2;
        public Brush BrushColor2
        {
            get { return _BrushColor2; }
            set
            {
                if (_BrushColor2 != value)
                {
                    _BrushColor2 = value;
                    RaisePropertyChanged("BrushColor2");
                }
            }
        }
        
        private Brush _BrushColor3;
        public Brush BrushColor3
        {
            get { return _BrushColor3; }
            set
            {
                if (_BrushColor3 != value)
                {
                    _BrushColor3 = value;
                    RaisePropertyChanged("BrushColor3");
                }
            }
        }
        
        private Brush _BrushColor4;
        public Brush BrushColor4
        {
            get { return _BrushColor4; }
            set
            {
                if (_BrushColor4 != value)
                {
                    _BrushColor4 = value;
                    RaisePropertyChanged("BrushColor4");
                }
            }
        }
        
        private Brush _BrushColor5;
        public Brush BrushColor5
        {
            get { return _BrushColor5; }
            set
            {
                if (_BrushColor5 != value)
                {
                    _BrushColor5 = value;
                    RaisePropertyChanged("BrushColor5");
                }
            }
        }

        private Brush _BrushColor6;
        public Brush BrushColor6
        {
            get { return _BrushColor6; }
            set
            {
                if (_BrushColor6 != value)
                {
                    _BrushColor6 = value;
                    RaisePropertyChanged("BrushColor6");
                }
            }
        }

        private Color? ConvertColor(System.Drawing.Color cl)
        {
            Color? MediaCl = System.Windows.Media.Color.FromArgb(cl.A, cl.R, cl.G, cl.B);
            return MediaCl;
        }

        private Brush CreateBrush(Color? cl)
        {
        System.Windows.Media.Color clo = (System.Windows.Media.Color)cl;
        Brush FBrush = new SolidColorBrush(clo);
        return FBrush;
        }
        
        #endregion

        #region Compare Cols
        ObservableCollection<string> _CompareCols_CompareColumns = new ObservableCollection<string>();

                int _CompareCols_CompareIndex = 0;
        int _CompareCols_WithIndex = 0;

        string _CompareCols_CompareLetter = string.Empty;
        string _CompareCols_WithLetter = string.Empty;
        bool _CompareCols_Highlight_IsColumnL = false;
                bool _CompareCols_Highlight_IsColumnM = false;
                bool _CompareCols_Highlight_IsColumnBoth = true;
                bool _CompareCols_Settings_CreateLogSheet = true;
                bool _CompareCols_AppliesTo_Selection = false;
            #endregion

            #region Missing Assets
                string _CharHeader = string.Empty;
                string _CharHeaderC = string.Empty;
                string _SceneHeader = string.Empty;
                string _SceneHeaderC = string.Empty;
                string _ItemHeader = string.Empty;
                string _ItemHeaderC = string.Empty;
                string _VideoHeader = string.Empty;
                string _VideoHeaderC = string.Empty;

                string _LFXHeader = string.Empty;
                string _LFXHeaderC = string.Empty;
                string _SFXHeader = string.Empty;
                string _SFXHeaderC = string.Empty;
                string _MusicHeader = string.Empty;
                string _MusicHeaderC = string.Empty;

                bool _MissingAssets_SettingsCreateLogSheet = true;
                bool _MissingAssets_AppliesToSelection = false;

            bool _FAFindCharacter = false;
        bool _FAFindScene = false;
        bool _FAFindItem = false;
        bool _FAFindVideo = false;
        bool _FAFindSFX = false;
        bool _FAFindLFX = false;
        bool _FAFindMusic = false;

        #endregion

        #region Mark Duplicates
        ObservableCollection<string> _MarkDuplicates_ColumnsToAnalyze = new ObservableCollection<string>();
        ObservableCollection<string> _MarkDuplicates_SuffixTypes = new ObservableCollection<string>{ "_1,_2,_3...", "_01,_02,_03...", "_001,_002,_003..."};
        int _MarkDuplicates_ColumnIndex = 0;
        int _MarkDuplicates_SuffixIndex = 1;
        string _MarkDuplicates_ColumnToAnalyze = string.Empty;
                bool _MarkDuplicates_SettingsCreateLogSheet = true;
                bool _MarkDuplicates_SettingsAddSuffix = false;
                bool _MarkDuplicates_AppliesToSelection = false;
        #endregion

        #region Insert Audio Data

        private bool _PL_Text_Enabled = false;
        private bool _PL_File_Enabled = false;
        private bool _Compare_Enabled = false;
        private bool _SL_Text_Enabled = false;
        private bool _SL_File_Enabled = false;
        private bool _SL_TextFile_Enabled = false;
        private bool _PL_TextFile_Enabled = false;

        private bool _PL_WordCount = false;
        private bool _PL_EAT = false;
        private bool _PL_AAT = false;
        private bool _PL_DiffToEAT = false;
        private bool _PL_AATDiffMS = false;
        private bool _PL_AATDiffPercent = false;

        private bool _SL_WordCount = false;
        private bool _SL_EAT = false;
        private bool _SL_AAT = false;
        private bool _SL_DiffToEAT = false;
        private bool _SL_Min = false;
        private bool _SL_Max = false;

        private bool _AD_Visible = false;

        private bool _IW_TargetColumn = true;

        private int _TargetIndex = 0;

        private bool _S_ColourCode = true;
        #endregion

        #endregion

        #region properties

        public String StatusPane { get { return _StatusPane; } }

        #region Mark Missing Properties

        bool _MMShowResults = false;
        public bool MMShowResults { get { return _MMShowResults; } set { if (_MMShowResults != value) { _MMShowResults = value; RaisePropertyChanged("ResultsVisibility"); } } }
        public Visibility ResultsVisibility { get { return _MMShowResults ? Visibility.Visible : Visibility.Collapsed; } }

        public Color? Color1
        {
            get { return _Color1; }
            set
            {
                if (_Color1 != value)
                {
                    _Color1 = value;
                    RaisePropertyChanged("Color1");
                    BrushColor1 = CreateBrush(value);
                }
            }
        }

        public Color? Color2
        {
            get { return _Color2; }
            set
            {
                if (_Color2 != value)
                {
                    _Color2 = value;
                    RaisePropertyChanged("Color2");
                    BrushColor2 = CreateBrush(value);
                }
            }
        }

        public Color? Color3
        {
            get { return _Color3; }
            set
            {
                if (_Color3 != value)
                {
                    _Color3 = value;
                    RaisePropertyChanged("Color3");
                    BrushColor3 = CreateBrush(value);
                }
            }
        }

        public Color? Color4
        {
            get { return _Color4; }
            set
            {
                if (_Color4 != value)
                {
                    _Color4 = value;
                    RaisePropertyChanged("Color4");
                    BrushColor4 = CreateBrush(value);
                }
            }
        }

        public Color? Color5
        {
            get { return _Color5; }
            set
            {
                if (_Color5 != value)
                {
                    _Color5 = value;
                    RaisePropertyChanged("Color5");
                    BrushColor5 = CreateBrush(value);

                }
            }
        }

        public Color? Color6
        {
            get { return _Color6; }
            set
            {
                if (_Color6 != value)
                {
                    _Color6 = value;
                    RaisePropertyChanged("Color6");
                    BrushColor6 = CreateBrush(value);
                }
            }
        }

        public bool MarkMissingFiles
                {
                    get { return _MarkMissingFiles; }
                    set
                    {
                        if (_MarkMissingFiles != value)
                        {
                            _MarkMissingFiles = value;
                        }
                    }
                }
        public bool MarkCorruptedFiles
        {
            get { return _MarkCorruptedFiles; }
            set
            {
                if (_MarkCorruptedFiles != value)
                {
                    _MarkCorruptedFiles = value;
                }
            }
        }
        public bool CountFiles
        {
            get { return _CountFiles; }
            set
            {
                if (_CountFiles != value)
                {
                    _CountFiles = value;
                }
            }
        }
        public bool AddResultColumn
        {
            get { return _AddResultColumn; }
            set
            {
                if (_AddResultColumn != value)
                {
                    _AddResultColumn = value;
                }
            }
        }
        public bool MarkPossMissedits
        {
            get { return _MarkPossMissedits; }
            set
            {
                if (_MarkPossMissedits != value)
                {
                    _MarkPossMissedits = value;
                }
            }
        }
        public bool FindLostPrimaries
        {
            get { return _FindLostPrimaries; }
            set
            {
                if (_FindLostPrimaries != value)
                {
                    _FindLostPrimaries = value;
                }
            }
        }
        public bool ReorderAltFiles
        {
            get { return _ReorderAltFiles; }
            set
            {
                if (_ReorderAltFiles != value)
                {
                    _ReorderAltFiles = value;
                }
            }
        }
        public bool TrimSpacesFromFile
        {
            get { return _TrimSpacesFromFile; }
            set
            {
                if (_TrimSpacesFromFile != value)
                {
                    _TrimSpacesFromFile = value;
                }
            }
        }
        
        public bool IsSecondaryChecked
        {
            get { return _IsSecondaryChecked; }
            set
            {
                if (_IsSecondaryChecked != value)
                {
                    _IsSecondaryChecked = value;
                }
            }
        }        
        public bool IsVideoChecked
        {
            get { return _IsVideoChecked; }
            set
            {
                if (_IsVideoChecked != value)
                {
                    _IsVideoChecked = value;
                }
            }
        }
        public bool IsSelectionChecked
        {
            get { return _IsSelectionChecked; }
            set
            {
                if (_IsSelectionChecked != value)
                {
                    _IsSelectionChecked = value;
                }
            }
        }
        public bool IsCreateLogSheet
        {
            get { return _IsCreateLogSheet; }
            set
            {
                if (_IsCreateLogSheet != value)
                {
                    _IsCreateLogSheet = value;
                }
            }
        }

        public string RowsChecked
        {
            get { return _RowsChecked; }
            set
            {
                if (_RowsChecked != value)
                {
                    _RowsChecked = value;
                }
            }
        }

        public string MissingFiles
        {
            get { return _MissingFiles; }
            set
            {
                if (_MissingFiles != value)
                {
                    _MissingFiles = value;
                }
            }
        }

        public string CorruptedFiles
        {
            get { return _CorruptedFiles; }
            set
            {
                if (_CorruptedFiles != value)
                {
                    _CorruptedFiles = value;
                }
            }
        }

        public string FilesTrimmed
        {
            get { return _FilesTrimmed; }
            set
            {
                if (_FilesTrimmed != value)
                {
                    _FilesTrimmed = value;
                }
            }
        }

        public string MisEditedFiles
        {
            get { return _MisEditedFiles; }
            set
            {
                if (_MisEditedFiles != value)
                {
                    _MisEditedFiles = value;
                }
            }
        }

        public string PrimaryTakesFound
        {
            get { return _PrimaryTakesFound; }
            set
            {
                if (_PrimaryTakesFound != value)
                {
                    _PrimaryTakesFound = value;
                }
            }
        }

        public string FilesCounted
        {
            get { return _FilesCounted; }
            set
            {
                if (_FilesCounted != value)
                {
                    _FilesCounted = value;
                }
            }
        }

        public string AltsReordered
        {
            get { return _AltsReordered; }
            set
            {
                if (_AltsReordered != value)
                {
                    _AltsReordered = value;
                }
            }
        }

        public string OverallResult
        {
            get { return _OverallResult; }
            set
            {
                if (_OverallResult != value)
                {
                    _OverallResult = value;
                    if(value == "")
                    {
                        MMShowResults = false;
                    }
                    else
                    {
                        MMShowResults = true;
                    }

                }
            }
        }
        #endregion

        #region Compare Cols Properties
        public ObservableCollection<string> CompareCols_CompareColumns { get { return _CompareCols_CompareColumns; } }
                public int CompareCols_CompareIndex { get { return _CompareCols_CompareIndex; } set { if (_CompareCols_CompareIndex != value) { _CompareCols_CompareIndex = value; } } }

        public int CompareCols_WithIndex { get { return _CompareCols_WithIndex; } set { if (_CompareCols_WithIndex != value) { _CompareCols_WithIndex = value; } } }

        public string CompareCols_CompareLetter { get { return _CompareCols_CompareLetter; } set { if (_CompareCols_CompareLetter != value) { _CompareCols_CompareLetter = value; RaisePropertyChanged("CompareCols_CompareLetter"); } } }
        public string CompareCols_WithLetter { get { return _CompareCols_WithLetter; } set { if (_CompareCols_WithLetter != value) { _CompareCols_WithLetter = value; RaisePropertyChanged("CompareCols_WithLetter"); } } }
        public bool CompareCols_Highlight_IsColumnL { get { return _CompareCols_Highlight_IsColumnL; } set { if (_CompareCols_Highlight_IsColumnL != value) { _CompareCols_Highlight_IsColumnL = value; } } }
                public bool CompareCols_Highlight_IsColumnM { get { return _CompareCols_Highlight_IsColumnM; } set { if (_CompareCols_Highlight_IsColumnM != value) { _CompareCols_Highlight_IsColumnM = value; } } }
                public bool CompareCols_Highlight_IsColumnBoth { get { return _CompareCols_Highlight_IsColumnBoth; } set { if (_CompareCols_Highlight_IsColumnBoth != value) { _CompareCols_Highlight_IsColumnBoth = value; } } }
                public bool CompareCols_Settings_CreateLogSheet { get { return _CompareCols_Settings_CreateLogSheet; } set { if (_CompareCols_Settings_CreateLogSheet != value) { _CompareCols_Settings_CreateLogSheet = value; } } }
                public bool CompareCols_AppliesTo_Selection { get { return _CompareCols_AppliesTo_Selection; } set { if (_CompareCols_AppliesTo_Selection != value) { _CompareCols_AppliesTo_Selection = value; } } }
        #endregion

        #region Missing Assets
                public string CharHeader { get { return _CharHeader; } set { if (_CharHeader != value) { _CharHeader = value; } } }
                public string CharHeaderC { get { return _CharHeaderC; } set { if (_CharHeaderC != value) { _CharHeaderC = value; } } }
                public string SceneHeader { get { return _SceneHeader; } set { if (_SceneHeader != value) { _SceneHeader = value; } } }
                public string SceneHeaderC { get { return _SceneHeaderC; } set { if (_SceneHeaderC != value) { _SceneHeaderC = value; } } }
                public string ItemHeader { get { return _ItemHeader; } set { if (_ItemHeader != value) { _ItemHeader = value; } } }
                public string ItemHeaderC { get { return _ItemHeaderC; } set { if (_ItemHeaderC != value) { _ItemHeaderC = value; } } }
                public string VideoHeader { get { return _VideoHeader; } set { if (_VideoHeader != value) { _VideoHeader = value; } } }
                public string VideoHeaderC { get { return _VideoHeaderC; } set { if (_VideoHeaderC != value) { _VideoHeaderC = value; } } }
                public string LFXHeader { get { return _LFXHeader; } set { if (_LFXHeader != value) { _LFXHeader = value; } } }
                public string LFXHeaderC { get { return _LFXHeaderC; } set { if (_LFXHeaderC != value) { _LFXHeaderC = value; } } }
                public string SFXHeader { get { return _SFXHeader; } set { if (_SFXHeader != value) { _SFXHeader = value; } } }
                public string SFXHeaderC { get { return _SFXHeaderC; } set { if (_SFXHeaderC != value) { _SFXHeaderC = value; } } }
                public string MusicHeader { get { return _MusicHeader; } set { if (_MusicHeader != value) { _MusicHeader = value; } } }
                public string MusicHeaderC { get { return _MusicHeaderC; } set { if (_MusicHeaderC != value) { _MusicHeaderC = value; } } }
                public bool MissingAssets_SettingsCreateLogSheet { get { return _MissingAssets_SettingsCreateLogSheet; } set { if (_MissingAssets_SettingsCreateLogSheet != value) { _MissingAssets_SettingsCreateLogSheet = value; } } }
                public bool MissingAssets_AppliesToSelection { get { return _MissingAssets_AppliesToSelection; } set { if (_MissingAssets_AppliesToSelection != value) { _MissingAssets_AppliesToSelection = value; } } }

        public bool FAFindCharacter { get { return _FAFindCharacter; } set { if (_FAFindCharacter != value) { _FAFindCharacter = value; RaisePropertyChanged("VisibilityChar"); } } }
        public bool FAFindScene { get { return _FAFindScene; } set { if (_FAFindScene != value) { _FAFindScene = value; RaisePropertyChanged("VisibilityScene"); } } }
        public bool FAFindItem { get { return _FAFindItem; } set { if (_FAFindItem != value) { _FAFindItem = value; RaisePropertyChanged("VisibilityItem"); } } }
        public bool FAFindVideo { get { return _FAFindVideo; } set { if (_FAFindVideo != value) { _FAFindVideo = value; RaisePropertyChanged("VisibilityVideo"); } } }
        public bool FAFindSFX { get { return _FAFindSFX; } set { if (_FAFindSFX != value) { _FAFindSFX = value; RaisePropertyChanged("VisibilitySFX"); } } }
        public bool FAFindLFX { get { return _FAFindLFX; } set { if (_FAFindLFX != value) { _FAFindLFX = value; RaisePropertyChanged("VisibilityLFX"); } } }
        public bool FAFindMusic { get { return _FAFindMusic; } set { if (_FAFindMusic != value) { _FAFindMusic = value; RaisePropertyChanged("VisibilityMusic"); } } }

        public Visibility VisibilityChar { get { return _FAFindCharacter ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility VisibilityScene { get { return _FAFindScene ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility VisibilityItem { get { return _FAFindItem ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility VisibilityVideo { get { return _FAFindVideo ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility VisibilityLFX { get { return _FAFindLFX ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility VisibilitySFX { get { return _FAFindSFX ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility VisibilityMusic { get { return _FAFindMusic ? Visibility.Visible : Visibility.Collapsed; } }

        #endregion

        #region Mark Duplicates
        public ObservableCollection<string> MarkDuplicates_ColumnsToAnalyze { get { return _MarkDuplicates_ColumnsToAnalyze; } }
        public ObservableCollection<string> MarkDuplicates_SuffixTypes { get { return _MarkDuplicates_SuffixTypes; } }
        public int MarkDuplicates_ColumnIndex { get { return _MarkDuplicates_ColumnIndex; } set { if (_MarkDuplicates_ColumnIndex != value) { _MarkDuplicates_ColumnIndex = value; } } }

        public int MarkDuplicates_SuffixIndex { get { return _MarkDuplicates_SuffixIndex; } set { if (_MarkDuplicates_SuffixIndex != value) { _MarkDuplicates_SuffixIndex = value; } } }
        public string MarkDuplicates_ColumnToAnalyze { get { return _MarkDuplicates_ColumnToAnalyze; } set { if (_MarkDuplicates_ColumnToAnalyze != value) { _MarkDuplicates_ColumnToAnalyze = value; } } }
                public bool MarkDuplicates_SettingsCreateLogSheet { get { return _MarkDuplicates_SettingsCreateLogSheet; } set { if (_MarkDuplicates_SettingsCreateLogSheet != value) { _MarkDuplicates_SettingsCreateLogSheet = value; } } }
                public bool MarkDuplicates_SettingsAddSuffix { get { return _MarkDuplicates_SettingsAddSuffix; } set { if (_MarkDuplicates_SettingsAddSuffix != value) { _MarkDuplicates_SettingsAddSuffix = value; RaisePropertyChanged("AltVisible"); } } }
                public bool MarkDuplicates_AppliesToSelection { get { return _MarkDuplicates_AppliesToSelection; } set { if (_MarkDuplicates_AppliesToSelection != value) { _MarkDuplicates_AppliesToSelection = value;  } } }
        public Visibility AltVisible { get { return _MarkDuplicates_SettingsAddSuffix ? Visibility.Visible : Visibility.Collapsed; } }

        #endregion

        #region Insert Data

        ObservableCollection<String> _TargetItems = new ObservableCollection<string>();
        public ObservableCollection<string> TargetItems { get { return _TargetItems; } }


        public bool PL_Text_Enabled
        {
            get { return _PL_Text_Enabled; }
            set
            {
                if (_PL_Text_Enabled != value)
                {
                    _PL_Text_Enabled = value;
                    SetPLFileText();
                }
            }
        }

        public bool PL_File_Enabled
        {
            get { return _PL_File_Enabled; }
            set
            {
                if (_PL_File_Enabled != value)
                {
                    _PL_File_Enabled = value;
                    SetPLFileText();
                    SetCompare();
                }
            }
        }

        public bool PL_TextFile_Enabled
        {
            get { return _PL_TextFile_Enabled; }
            set
            {
                if (_PL_TextFile_Enabled != value)
                {
                    _PL_TextFile_Enabled = value;
                    
                }
            }
        }

        public bool SL_TextFile_Enabled
        {
            get { return _SL_TextFile_Enabled; }
            set
            {
                if (_SL_TextFile_Enabled != value)
                {
                    _SL_TextFile_Enabled = value;
                }
            }
        }

        

        public bool SL_File_Enabled
        {
            get { return _SL_File_Enabled; }
            set
            {
                if (_SL_File_Enabled != value)
                {
                    _SL_File_Enabled = value;
                    SetSLFileText();
                    SetCompare();
                }
            }
        }

        public bool SL_Text_Enabled
        {
            get { return _SL_Text_Enabled; }
            set
            {
                if (_SL_Text_Enabled != value)
                {
                    _SL_Text_Enabled = value;
                    SetSLFileText();
                }
            }
        }

        public bool Compare_Enabled
        {
            get { return _Compare_Enabled; }
            set
            {
                if (_Compare_Enabled != value)
                {
                    _Compare_Enabled = value;
                }
            }
        }

        public bool PL_WordCount
        {
            get { return _PL_WordCount; }
            set
            {
                if (_PL_WordCount != value)
                {
                    _PL_WordCount = value;
                }
            }
        }

        public bool PL_EAT
        {
            get { return _PL_EAT; }
            set
            {
                if (_PL_EAT != value)
                {
                    _PL_EAT = value;
                }
            }
        }

        public bool PL_AAT
        {
            get { return _PL_AAT; }
            set
            {
                if (_PL_AAT != value)
                {
                    _PL_AAT = value;
                }
            }
        }

        public bool PL_DiffToEAT
        {
            get { return _PL_DiffToEAT; }
            set
            {
                if (_PL_DiffToEAT != value)
                {
                    _PL_DiffToEAT = value;
                }
            }
        }

        public bool PL_AATDiffMS
        {
            get { return _PL_AATDiffMS; }
            set
            {
                if (_PL_AATDiffMS != value)
                {
                    _PL_AATDiffMS = value;
                }
            }
        }

        public bool PL_AATDiffPercent
        {
            get { return _PL_AATDiffPercent; }
            set
            {
                if (_PL_AATDiffPercent != value)
                {
                    _PL_AATDiffPercent = value;
                }
            }
        }

        public bool SL_WordCount
        {
            get { return _SL_WordCount; }
            set
            {
                if (_SL_WordCount != value)
                {
                    _SL_WordCount = value;
                }
            }
        }

        public bool SL_EAT
        {
            get { return _SL_EAT; }
            set
            {
                if (_SL_EAT != value)
                {
                    _SL_EAT = value;
                }
            }
        }

        public bool SL_AAT
        {
            get { return _SL_AAT; }
            set
            {
                if (_SL_AAT != value)
                {
                    _SL_AAT = value;
                }
            }
        }

        public bool SL_DiffToEAT
        {
            get { return _SL_DiffToEAT; }
            set
            {
                if (_SL_DiffToEAT != value)
                {
                    _SL_DiffToEAT = value;
                }
            }
        }

        public bool SL_Min
        {
            get { return _SL_Min; }
            set
            {
                if (_SL_Min != value)
                {
                    _SL_Min = value;
                }
            }
        }

        public bool SL_Max
        {
            get { return _SL_Max; }
            set
            {
                if (_SL_Max != value)
                {
                    _SL_Max = value;
                }
            }
        }

        public bool AD_Visible
        {
            get { return _AD_Visible; }
            set
            {
                if (_AD_Visible != value)
                {
                    _AD_Visible = value;
                }
            }
        }

        public bool IW_TargetColumn
        {
            get { return _IW_TargetColumn; }
            set
            {
                if (_IW_TargetColumn != value)
                {
                    _IW_TargetColumn = value;
                }
            }
        }

        public bool S_ColourCode
        {
            get { return _S_ColourCode; }
            set
            {
                if (_S_ColourCode != value)
                {
                    _S_ColourCode = value;
                }
            }
        }

        public int TargetIndex
        {
            get { return _TargetIndex; }
            set
            {
                if (_TargetIndex != value)
                {
                    _TargetIndex = value;
                }
            }
        }

        //public bool Send_PL_WordCount()
        //{
        //    return PL_WordCount;
        //}

        //public bool Send_PL_EAT()
        //{
        //    return PL_EAT;
        //}

        //public bool Send_PL_AAT()
        //{
        //    return PL_AAT;
        //}

        //public bool Send_PL_DiffToEAT()
        //{
        //    return PL_DiffToEAT;
        //}

        //public bool Send_PL_AATDiffMS()
        //{
        //    return PL_AATDiffMS;
        //}

        //public bool Send_PL_AATDiffPercent()
        //{
        //    return PL_AATDiffPercent;
        //}

        //public bool Send_SL_WordCount()
        //{
        //    return SL_WordCount;
        //}

        //public bool Send_SL_EAT()
        //{
        //    return SL_EAT;
        //}

        //public bool Send_SL_AAT()
        //{
        //    return SL_AAT;
        //}

        //public bool Send_SL_DiffToEAT()
        //{
        //    return SL_DiffToEAT;
        //}

        //public bool Send_SL_Min()
        //{
        //    return SL_Min;
        //}

        //public bool Send_SL_Max()
        //{
        //    return SL_Max;
        //}

        //public bool Send_AD_Visible()
        //{
        //    return AD_Visible;
        //}

        //public bool Send_IW_TargetColumn()
        //{
        //    return IW_TargetColumn;
        //}

        //public bool Send_S_ColourCode()
        //{
        //    return S_ColourCode;
        //}

        //public int Send_TargetIndex()
        //{
        //    return TargetIndex;
        //}

        //public void Set_TargetIndex(int p_Value)
        //{
        //    TargetIndex = p_Value;
        //    RaisePropertyChanged("TargetIndex");
        //}
         

        private void SetCompare()
        {
            if (!SL_File_Enabled | !PL_File_Enabled)
            {
                Compare_Enabled = false;
            }
            else
            {
                Compare_Enabled = true;
            }

            RaisePropertyChanged("Compare_Enabled");
        }

        private void SetPLFileText()
        {
            if (!PL_Text_Enabled | !PL_File_Enabled)
            {
                PL_TextFile_Enabled = false;
            }
            else
            {
                PL_TextFile_Enabled = true;
            }

            RaisePropertyChanged("PL_TextFile_Enabled");
        }

        private void SetSLFileText()
        {
            if (!SL_Text_Enabled | !SL_File_Enabled)
            {
                SL_TextFile_Enabled = false;
            }
            else
            {
                SL_TextFile_Enabled = true;
            }

            RaisePropertyChanged("SL_TextFile_Enabled");
        }
        
        //private bool _PL_WordCount = false;
        //private bool _PL_EAT = false;
        //private bool _PL_AAT = false;
        //private bool _PL_DiffToEAT = false;
        //private bool _PL_AATDiffMS = false;
        //private bool _PL_AATDiffPercent = false;

        //private bool _SL_WordCount = false;
        //private bool _SL_EAT = false;
        //private bool _SL_AAT = false;
        //private bool _SL_DiffToEAT = false;
        //private bool _SL_Min = false;
        //private bool _SL_Max = false;

        //private bool _AD_Visible = false;

        //private bool _IW_TargetColumn = false;

        //private int _TargetIndex =0;

        //private bool _S_ColourCode = false;

        //public bool PL_WordCount
        //{
        //    get { return _PL_WordCount; }
        //    set
        //    {
        //        if (_PL_WordCount != value)
        //        {
        //            _PL_WordCount = value;
        //        }
        //    }
        //}

        //public bool PL_EAT
        //{
        //    get { return _PL_EAT; }
        //    set
        //    {
        //        if (_PL_EAT != value)
        //        {
        //            _PL_EAT = value;
        //        }
        //    }
        //}

        //public bool PL_AAT
        //{
        //    get { return _PL_AAT; }
        //    set
        //    {
        //        if (_PL_AAT != value)
        //        {
        //            _PL_AAT = value;
        //        }
        //    }
        //}

        //public bool PL_DiffToEAT
        //{
        //    get { return _PL_DiffToEAT; }
        //    set
        //    {
        //        if (_PL_DiffToEAT != value)
        //        {
        //            _PL_DiffToEAT = value;
        //        }
        //    }
        //}

        //public bool PL_AATDiffMS
        //{
        //    get { return _PL_AATDiffMS; }
        //    set
        //    {
        //        if (_PL_AATDiffMS != value)
        //        {
        //            _PL_AATDiffMS = value;
        //        }
        //    }
        //}

        //public bool PL_AATDiffPercent
        //{
        //    get { return _PL_AATDiffPercent; }
        //    set
        //    {
        //        if (_PL_AATDiffPercent != value)
        //        {
        //            _PL_AATDiffPercent = value;
        //        }
        //    }
        //}

        //public bool SL_WordCount
        //{
        //    get { return _SL_WordCount; }
        //    set
        //    {
        //        if (_SL_WordCount != value)
        //        {
        //            _SL_WordCount = value;
        //        }
        //    }
        //}

        //public bool SL_EAT
        //{
        //    get { return _SL_EAT; }
        //    set
        //    {
        //        if (_SL_EAT != value)
        //        {
        //            _SL_EAT = value;
        //        }
        //    }
        //}

        //public bool SL_AAT
        //{
        //    get { return _SL_AAT; }
        //    set
        //    {
        //        if (_SL_AAT != value)
        //        {
        //            _SL_AAT = value;
        //        }
        //    }
        //}

        //public bool SL_DiffToEAT
        //{
        //    get { return _SL_DiffToEAT; }
        //    set
        //    {
        //        if (_SL_DiffToEAT != value)
        //        {
        //            _SL_DiffToEAT = value;
        //        }
        //    }
        //}

        //public bool SL_Min
        //{
        //    get { return _SL_Min; }
        //    set
        //    {
        //        if (_SL_Min != value)
        //        {
        //            _SL_Min = value;
        //        }
        //    }
        //}

        //public bool SL_Max
        //{
        //    get { return _SL_Max; }
        //    set
        //    {
        //        if (_SL_Max != value)
        //        {
        //            _SL_Max = value;
        //        }
        //    }
        //}

        //public bool AD_Visible
        //{
        //    get { return _AD_Visible; }
        //    set
        //    {
        //        if (_AD_Visible != value)
        //        {
        //            _AD_Visible = value;
        //        }
        //    }
        //}

        //public bool IW_TargetColumn
        //{
        //    get { return _IW_TargetColumn; }
        //    set
        //    {
        //        if (_IW_TargetColumn != value)
        //        {
        //            _IW_TargetColumn = value;
        //        }
        //    }
        //}

        //public bool S_ColourCode
        //{
        //    get { return _S_ColourCode; }
        //    set
        //    {
        //        if (_S_ColourCode != value)
        //        {
        //            _S_ColourCode = value;
        //        }
        //    }
        //}

        //public int TargetIndex
        //{
        //    get { return _TargetIndex; }
        //    set
        //    {
        //        if (_TargetIndex != value)
        //        {
        //            _TargetIndex = value;
        //        }
        //    }
        //}

        //public bool Send_PL_WordCount()
        //{
        //    return PL_WordCount;
        //}

        //public bool Send_PL_EAT()
        //{
        //    return PL_EAT;
        //}

        //public bool Send_PL_AAT()
        //{
        //    return PL_AAT;
        //}

        //public bool Send_PL_DiffToEAT()
        //{
        //    return PL_DiffToEAT;
        //}

        //public bool Send_PL_AATDiffMS()
        //{
        //    return PL_AATDiffMS;
        //}

        //public bool Send_PL_AATDiffPercent()
        //{
        //    return PL_AATDiffPercent;
        //}

        //public bool Send_SL_WordCount()
        //{
        //    return SL_WordCount;
        //}

        //public bool Send_SL_EAT()
        //{
        //    return SL_EAT;
        //}

        //public bool Send_SL_AAT()
        //{
        //    return SL_AAT;
        //}

        //public bool Send_SL_DiffToEAT()
        //{
        //    return SL_DiffToEAT;
        //}

        //public bool Send_SL_Min()
        //{
        //    return SL_Min;
        //}

        //public bool Send_SL_Max()
        //{
        //    return SL_Max;
        //}

        //public bool Send_AD_Visible()
        //{
        //    return AD_Visible;
        //}

        //public bool Send_IW_TargetColumn()
        //{
        //    return IW_TargetColumn;
        //}

        //public bool Send_S_ColourCode()
        //{
        //    return S_ColourCode;
        //}

        //public int Send_TargetIndex()
        //{
        //    return TargetIndex;
        //}

        //public bool PL_WordCount { get { return _PL_WordCount; } set { if (_PL_WordCount != value) { _PL_WordCount = value; } } }
        //        public bool SL_EAT { get { return _SL_EAT; } set { if (_SL_EAT != value) { _SL_EAT = value; } } }
        //        public bool SL_AAT { get { return _SL_AAT; } set { if (_SL_AAT != value) { _SL_AAT = value; } } }
        //        public bool SL_DiffToEAT { get { return _SL_DiffToEAT; } set { if (_SL_DiffToEAT != value) { _SL_DiffToEAT = value; } } }
        //        public bool SL_Min { get { return _SL_Min; } set { if (_SL_Min != value) { _SL_Min = value; } } }
        //        public bool SL_Max { get { return _SL_Max; } set { if (_SL_Max != value) { _SL_Max = value; } } }
        //        public bool AD_All { get { return _AD_All; } set { if (_AD_All != value) { _AD_All = value; } } }
        //        public bool AD_Visible { get { return _AD_Visible; } set { if (_AD_Visible != value) { _AD_Visible = value; } } }
        //        public bool IW_EndOfScript { get { return _IW_EndOfScript; } set { if (_IW_EndOfScript != value) { _IW_EndOfScript = value; } } }
        //        public bool IW_TargetColumn { get { return _IW_TargetColumn; } set { if (_IW_TargetColumn != value) { _IW_TargetColumn = value; } } }
        //        public bool S_ColourCode { get { return _S_ColourCode; } set { if (_S_ColourCode != value) { _S_ColourCode = value; } } }

        #endregion
            
        #endregion

        #region Constructor
        public QualityAssuranceViewModel()
        {

        }
        #endregion

        #region Commands
        private void ResetExecute()
        {

        }
        public ICommand Reset { get { return new RelayCommand(ResetExecute); } }

        private void CheckFilesExecute()
        {

        }
        public ICommand CheckFiles { get { return new RelayCommand(CheckFilesExecute); } }
        #endregion

        #region private methods

        #endregion

        #region public methods
        public void SetStatusPane(String p_Value)
        {
            _StatusPane = p_Value;
            RaisePropertyChanged("StatusPane");
        }

        public QualityAssuranceViewModel getVM()
        {
            return this;
        }

        public void AddTo_CompareCols_CompareColumns(List<string> p_List)
        {
            foreach (var l in p_List)
            {
                _CompareCols_CompareColumns.Add(l);
            }
            RaisePropertyChanged("CompareCols_CompareColumns");
        }

        public void AddTo_TargetItems(List<string> p_List)
        {
            foreach(var l in p_List)
            {
                _TargetItems.Add(l);
            }
            RaisePropertyChanged("TargetItems");
        }

        public void Clear_CompareCols_CompareColumns()
        {
            _CompareCols_CompareColumns.Clear();
            RaisePropertyChanged("CompareCols_CompareColumns");
        }

        public void AddTo_MarkDuplicates_ColumnsToAnalyze(List<string> p_List)
        {
            foreach(var l in p_List)
            {
                _MarkDuplicates_ColumnsToAnalyze.Add(l);
            }
            RaisePropertyChanged("MarkDuplicates_ColumnsToAnalyze");
        }

        public void Clear_MarkDuplicates_ColumnsToAnalyze()
        {
            _MarkDuplicates_ColumnsToAnalyze.Clear();
            RaisePropertyChanged("MarkDuplicates_ColumnsToAnalyze");
        }

        public void RefreshVM()
        {
            foreach (System.Reflection.PropertyInfo p in this.GetType().GetProperties())
            {
                RaisePropertyChanged(p.Name);
            }
        }
        
        public void ChangeColor1(System.Drawing.Color cl)
        {
            Color1 = ConvertColor(cl);
        }

        public void ChangeColor6(System.Drawing.Color cl)
        {
            Color6 = ConvertColor(cl);
        }

        public void ChangeColor5(System.Drawing.Color cl)
        {
            Color5 = ConvertColor(cl);
        }

        public void ChangeColor4(System.Drawing.Color cl)
        {
            Color4 = ConvertColor(cl);
        }

        public void ChangeColor3(System.Drawing.Color cl)
        {
            Color3 = ConvertColor(cl);
        }

        public void ChangeColor2(System.Drawing.Color cl)
        {
            Color2 = ConvertColor(cl);
        }

        #endregion

    }
}

