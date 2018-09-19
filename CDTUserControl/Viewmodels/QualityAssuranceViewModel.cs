using CDTUserControl.Usercontrols;
using System;
using System.Collections.Generic;
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
    }
}

