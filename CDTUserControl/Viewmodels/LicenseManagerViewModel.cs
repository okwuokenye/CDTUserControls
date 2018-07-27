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
    class LicenseManagerViewModel : ObservableObject
    {
        #region private variables

        private string _ProductName;
        private string _ComputerID;
        private string _LicenseKey;
        private string _LicenseState;
        private string _SerialNumber;
        private string _FirstAuth;
        private string _ExpiryDate;
        private string _StatusWarn;

        #endregion

        #region event declarations

        public delegate void RecheckButtonEventHandler();
        public event RecheckButtonEventHandler RecheckButtonEvent;

        public delegate void InstallButtonEventHandler();
        public event InstallButtonEventHandler InstallButtonEvent;

        public delegate void UninstallButtonEventHandler();
        public event UninstallButtonEventHandler UninstallButtonEvent;

        #endregion

        #region properties

        public String ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                if (_ProductName != value)
                {
                    _ProductName = value;
                    RaisePropertyChanged("ProductName");
                }
            }
        }
        public String ComputerID
        {
            get
            {
                return _ComputerID;
            }
            set
            {
                if (_ComputerID != value)
                {
                    _ComputerID = value;
                    RaisePropertyChanged("ComputerID");
                }
            }
        }
        public String LicenseKey
        {
            get
            {
                return _LicenseKey;
            }
            set
            {
                if (_LicenseKey != value)
                {
                    _LicenseKey = value;
                    RaisePropertyChanged("LicenseKey");
                }
            }
        }
        public String LicenseState
        {
            get
            {
                return _LicenseState;
            }
            set
            {
                if (_LicenseState != value)
                {
                    _LicenseState = value;
                    RaisePropertyChanged("LicenseState");
                }
            }
        }
        public String SerialNumber
        {
            get
            {
                return _SerialNumber;
            }
            set
            {
                if (_SerialNumber != value)
                {
                    _SerialNumber = value;
                    RaisePropertyChanged("SerialNumber");
                }
            }
        }
        public String FirstAuth
        {
            get
            {
                return _FirstAuth;
            }
            set
            {
                if (_FirstAuth != value)
                {
                    _FirstAuth = value;
                    RaisePropertyChanged("FirstAuth");
                }
            }
        }
        public String ExpiryDate
        {
            get
            {
                return _ExpiryDate;
            }
            set
            {
                if (_ExpiryDate != value)
                {
                    _ExpiryDate = value;
                    RaisePropertyChanged("ExpiryDate");
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
        #endregion

        #region constructor

        public LicenseManagerViewModel()
        {

        }

        #endregion

        #region private methods

        #endregion

        #region public set methods

        public void SetProductName(string p_Value)
        {
            _ProductName = p_Value;
            RaisePropertyChanged("ProductName");
        }

        public void SetComputerID(string p_Value)
        {
            _ComputerID = p_Value;
            RaisePropertyChanged("ComputerID");
        }

        public void SetLicenseKey(string p_Value)
        {
            _LicenseKey = p_Value;
            RaisePropertyChanged("LicenseKey");
        }

        public void SetLicenseState(string p_Value)
        {
            _LicenseState = p_Value;
            RaisePropertyChanged("LicenseState");
        }

        public void SetSerialNumber(string p_Value)
        {
            _SerialNumber = p_Value;
            RaisePropertyChanged("SerialNumber");
        }

        public void SetFirstAuth(string p_Value)
        {
            _FirstAuth = p_Value;
            RaisePropertyChanged("FirstAuth");
        }

        public void SetExpiryDate(string p_Value)
        {
            _ExpiryDate = p_Value;
            RaisePropertyChanged("ExpiryDate");
        }

        public void SetStatusWarn(string p_Value)
        {
            _StatusWarn = p_Value;
            RaisePropertyChanged("StatusWarn");
        }
        #endregion

        #region commands


        private void UninstallExecute()
        {
            UninstallButtonEvent();
        }
        public ICommand Uninstall { get { return new RelayCommand(UninstallExecute); } }
        
        private void InstallExecute()
        {
            InstallButtonEvent();
        }
        public ICommand Install { get { return new RelayCommand(InstallExecute); } }
        
        private void RecheckExecute()
        {
            RecheckButtonEvent();
        }
        public ICommand Recheck { get { return new RelayCommand(RecheckExecute); } }

        #endregion


    }
}
