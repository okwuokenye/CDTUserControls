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
    class QualityAssuranceViewModel : ObservableObject
    {
        #region Events

        public delegate void LockEventHandler(Boolean p_Value);
        public event LockEventHandler LockEvent;

        #endregion

        #region private variables
        string _StatusPane;
        private ColorPickerWindow _colorPicker;
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

        #endregion

        #region properties
        
        public String StatusPane { get { return _StatusPane; } }

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
        #endregion

        #region Insert Data

        ObservableCollection<String> _TargetItems = new ObservableCollection<String> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ" };
        public ObservableCollection<string> TargetItems { get { return _TargetItems; } }

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
        
        private bool _IW_TargetColumn = false;
        
        private int _TargetIndex =0;

        private bool _S_ColourCode = false;
        
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
        
        public bool Send_PL_WordCount()
        {
            return PL_WordCount;
        }

        public bool Send_PL_EAT()
        {
            return PL_EAT;
        }

        public bool Send_PL_AAT()
        {
            return PL_AAT;
        }

        public bool Send_PL_DiffToEAT()
        {
            return PL_DiffToEAT;
        }

        public bool Send_PL_AATDiffMS()
        {
            return PL_AATDiffMS;
        }

        public bool Send_PL_AATDiffPercent()
        {
            return PL_AATDiffPercent;
        }

        public bool Send_SL_WordCount()
        {
            return SL_WordCount;
        }

        public bool Send_SL_EAT()
        {
            return SL_EAT;
        }

        public bool Send_SL_AAT()
        {
            return SL_AAT;
        }

        public bool Send_SL_DiffToEAT()
        {
            return SL_DiffToEAT;
        }

        public bool Send_SL_Min()
        {
            return SL_Min;
        }

        public bool Send_SL_Max()
        {
            return SL_Max;
        }

        public bool Send_AD_Visible()
        {
            return AD_Visible;
        }

        public bool Send_IW_TargetColumn()
        {
            return IW_TargetColumn;
        }

        public bool Send_S_ColourCode()
        {
            return S_ColourCode;
        }

        public int Send_TargetIndex()
        {
            return TargetIndex;
        }


        #endregion

    }
}

