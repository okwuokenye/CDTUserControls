using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CDTUserControl.Viewmodels
{
    class SplashScreenViewModel : ObservableObject
    {

        #region private variables

        string _Title = string.Empty;
        string _ProgressText = string.Empty;
        int _ProgressValue = 1;
        int _ProgressMax = 100;
        bool _IsSet = true;

                #endregion

        #region properties
        
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                }
            }
        }
        
        public string ProgressText
        {
            get { return _ProgressText; }
            set
            {
                if (_ProgressText != value)
                {
                    _ProgressText = value;
                }
            }
        }

        public int ProgressValue
        {
            get { return _ProgressValue; }
            set
            {
                if (_ProgressValue != value)
                {
                    _ProgressValue = value;
                }
            }
        }

        public int ProgressMax
        {
            get { return _ProgressMax; }
            set
            {
                if (_ProgressMax != value)
                {
                    _ProgressMax = value;
                }
            }
        }

        public bool IsSet
        {
            get { return _IsSet; }
            set
            {
                if (_IsSet != value)
                {
                    _IsSet = value;
                }
            }
        }

        //public String BackSource { get { return "../Resources/CDTSplashCube.jpg"; } }
        #endregion

        #region Constructor
        public SplashScreenViewModel()
        {

        }
        #endregion
        
        #region public methods
        
        public void SetTitle(string p_Value)
        {
            _Title = p_Value;
            RaisePropertyChanged("Title");
        }

        public void SetProgressText(string p_Value)
        {
            _ProgressText = p_Value;
            RaisePropertyChanged("ProgressText");
        }

        public void SetProgressValue(int p_Value)
        {
            _ProgressValue = p_Value;
            RaisePropertyChanged("ProgressValue");
        }

        public void SetProgressMax(int p_Value)
        {
            _ProgressMax = p_Value;
            RaisePropertyChanged("ProgressMax");
        }
        
        public void SetProgressSet(bool p_Value)
        {
            _IsSet = p_Value;
            RaisePropertyChanged("IsSet");
        }
        #endregion


    }
}
