using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDTUserControl.Viewmodels
{
    public class VisualViewerViewModel : ObservableObject
    {
        #region Events
        
        public delegate void LockEventHandler(Boolean p_Value);
        public event LockEventHandler LockEvent;

        #endregion

        #region private variables
        string _ImageSource = string.Empty;
        bool _IsLocked = false;
        public String LockImage { get { return _IsLocked ?"../Resources/padlock.png" : null; } }
        
        #endregion

        #region properties

        public string ImageSource { get { return _ImageSource; } }

        public bool IsLocked
        {
            get { return _IsLocked; }
            set
            {
                if (_IsLocked != value)
                {
                    _IsLocked = value;
                    RaisePropertyChanged("LockImage");
                    LockEvent(value);
                }
            }
        }

        #endregion

        #region Constructor
        public VisualViewerViewModel()
        {

        }
        #endregion

        #region Commands

        #endregion

        #region private methods

        #endregion

        #region public methods

        public void SetImage(string p_ImageSource)
        {
            _ImageSource = p_ImageSource;
            RaisePropertyChanged("ImageSource");
        }
        #endregion
    }
}
