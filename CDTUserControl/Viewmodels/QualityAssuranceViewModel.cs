using CDTUserControl.Usercontrols;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

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
                private bool _MarkMissingFiles = false;
                private bool _MarkCorruptedFiles = false;
                private bool _CountFiles = false;
                private bool _AddResultColumn = false;
                private bool _MarkPossMissedits = false;
                private bool _FindLostPrimaries = false;
                private bool _ReorderAltFiles = false;
                private bool _TrimSpacesFromFile = false;

                private bool _IsPrimaryChecked = false;
                private bool _IsSecondaryChecked = false;
                private bool _IsAudioChecked = false;
                private bool _IsVideoChecked = false;
                private bool _IsAllChecked = false;
                private bool _IsSelectionChecked = false;
                private bool _IsCreateLogSheet = false;

                string _RowsChecked = string.Empty;
                string _MissingFIles = string.Empty;
                string _CorruptedFiles = string.Empty;
                string _FilesTrimmed = string.Empty;
                string _MisEditedFiles = string.Empty;
                string _PrimaryTakesFound = string.Empty;
                string _FilesCounted = string.Empty;
                string _AltsReordered = string.Empty;
                string _OverallResult = string.Empty;
            #endregion

            #region Compare Cols
                ObservableCollection<string> _CompareCols_CompareColumns = new ObservableCollection<string>();
                int _CompareCols_CompareIndex = 0;
                string _CompareCols_CompareLetter = string.Empty;
                bool _CompareCols_Highlight_IsColumnL = false;
                bool _CompareCols_Highlight_IsColumnM = false;
                bool _CompareCols_Highlight_IsColumnBoth = false;
                bool _CompareCols_Settings_CreateLogSheet = false;
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
                bool _MissingAssets_SettingsCreateLogSheet = false;
                bool _MissingAssets_AppliesToSelection = false;
            #endregion

            #region Mark Duplicates
                ObservableCollection<string> _MarkDuplicates_ColumnsToAnalyze = new ObservableCollection<string>();
                int _MarkDuplicates_ColumnIndex = 0;
                string _MarkDuplicates_ColumnToAnalyze = string.Empty;
                bool _MarkDuplicates_SettingsCreateLogSheet = false;
                bool _MarkDuplicates_SettingsAddSuffix = false;
                bool _MarkDuplicates_AppliesToSelection = false;
            #endregion

            #region Insert Audio Data
                bool _PL_WordCount = false;
                bool _SL_EAT = false;
                bool _SL_AAT = false;
                bool _SL_DiffToEAT = false;
                bool _SL_Min = false;
                bool _SL_Max = false;

                bool _AD_All = false;
                bool _AD_Visible = false;
                bool _IW_EndOfScript = false;
                bool _IW_TargetColumn = false;
                bool _S_ColourCode = false;
            #endregion
        #endregion

        #region properties

        public String StatusPane { get { return _StatusPane; } }

            #region Mark Missing Properties
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

                public bool IsPrimaryChecked
                {
                    get { return _IsPrimaryChecked; }
                    set
                    {
                        if (_IsPrimaryChecked != value)
                        {
                            _IsPrimaryChecked = value;
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

                public bool IsAudioChecked
                {
                    get { return _IsAudioChecked; }
                    set
                    {
                        if (_IsAudioChecked != value)
                        {
                            _IsAudioChecked = value;
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
                public bool IsAllChecked
                {
                    get { return _IsAllChecked; }
                    set
                    {
                        if (_IsAllChecked != value)
                        {
                            _IsAllChecked = value;
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

                public string MissingFIles
                {
                    get { return _MissingFIles; }
                    set
                    {
                        if (_MissingFIles != value)
                        {
                            _MissingFIles = value;
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
        #endregion

            #region Compare Cols Properties
                public ObservableCollection<string> CompareCols_CompareColumns { get { return _CompareCols_CompareColumns; } }
                public int CompareCols_CompareIndex { get { return _CompareCols_CompareIndex; } set { if (_CompareCols_CompareIndex != value) { _CompareCols_CompareIndex = value; } } }
                public string CompareCols_CompareLetter { get { return _CompareCols_CompareLetter; } set { if (_CompareCols_CompareLetter != value) { _CompareCols_CompareLetter = value; } } }
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
        #endregion

            #region Mark Duplicates
                public ObservableCollection<string> MarkDuplicates_ColumnsToAnalyze { get { return _MarkDuplicates_ColumnsToAnalyze; } }
                public int MarkDuplicates_ColumnIndex { get { return _MarkDuplicates_ColumnIndex; } set { if (_MarkDuplicates_ColumnIndex != value) { _MarkDuplicates_ColumnIndex = value; } } }
                public string MarkDuplicates_ColumnToAnalyze { get { return _MarkDuplicates_ColumnToAnalyze; } set { if (_MarkDuplicates_ColumnToAnalyze != value) { _MarkDuplicates_ColumnToAnalyze = value; } } }
                public bool MarkDuplicates_SettingsCreateLogSheet { get { return _MarkDuplicates_SettingsCreateLogSheet; } set { if (_MarkDuplicates_SettingsCreateLogSheet != value) { _MarkDuplicates_SettingsCreateLogSheet = value; } } }
                public bool MarkDuplicates_SettingsAddSuffix { get { return _MarkDuplicates_SettingsAddSuffix; } set { if (_MarkDuplicates_SettingsAddSuffix != value) { _MarkDuplicates_SettingsAddSuffix = value; } } }
                public bool MarkDuplicates_AppliesToSelection { get { return _MarkDuplicates_AppliesToSelection; } set { if (_MarkDuplicates_AppliesToSelection != value) { _MarkDuplicates_AppliesToSelection = value; } } }
        #endregion

            #region
                public bool PL_WordCount { get { return _PL_WordCount; } set { if (_PL_WordCount != value) { _PL_WordCount = value; } } }
                public bool SL_EAT { get { return _SL_EAT; } set { if (_SL_EAT != value) { _SL_EAT = value; } } }
                public bool SL_AAT { get { return _SL_AAT; } set { if (_SL_AAT != value) { _SL_AAT = value; } } }
                public bool SL_DiffToEAT { get { return _SL_DiffToEAT; } set { if (_SL_DiffToEAT != value) { _SL_DiffToEAT = value; } } }
                public bool SL_Min { get { return _SL_Min; } set { if (_SL_Min != value) { _SL_Min = value; } } }
                public bool SL_Max { get { return _SL_Max; } set { if (_SL_Max != value) { _SL_Max = value; } } }
                public bool AD_All { get { return _AD_All; } set { if (_AD_All != value) { _AD_All = value; } } }
                public bool AD_Visible { get { return _AD_Visible; } set { if (_AD_Visible != value) { _AD_Visible = value; } } }
                public bool IW_EndOfScript { get { return _IW_EndOfScript; } set { if (_IW_EndOfScript != value) { _IW_EndOfScript = value; } } }
                public bool IW_TargetColumn { get { return _IW_TargetColumn; } set { if (_IW_TargetColumn != value) { _IW_TargetColumn = value; } } }
                public bool S_ColourCode { get { return _S_ColourCode; } set { if (_S_ColourCode != value) { _S_ColourCode = value; } } }
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
            foreach(var l in p_List)
            {
                _CompareCols_CompareColumns.Add(l);
            }
            RaisePropertyChanged("CompareCols_CompareColumns");
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
        #endregion

        #region Insert Data

        ObservableCollection<String> _TargetItems = new ObservableCollection<String> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ" };
        public ObservableCollection<string> TargetItems { get { return _TargetItems; } }

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


        #endregion

    }
}

