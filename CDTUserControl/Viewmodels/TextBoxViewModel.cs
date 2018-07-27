using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDTUserControl.Viewmodels
{
    public class TextBoxViewModel : ObservableObject
    {
        #region Events
        
        public delegate void LockEventHandler(Boolean p_Value);
        public event LockEventHandler LockEvent;

        #endregion

        #region private variables
        string _TextSource = string.Empty;
        int _FontSize = 12;
        bool _IsLocked = false;
        public String LockImage { get { return _IsLocked ?"../Resources/padlock.png" : null; } }
        
        #endregion

        #region properties

        public string TextSource { get { return _TextSource; } }

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

        public int FontSize
        {
            get { return _FontSize; }
            set
            {
                if (_FontSize != value)
                {
                    _FontSize = value;
                    RaisePropertyChanged("FontSize");
                }
            }
        }
        #endregion

        #region Constructor
        public TextBoxViewModel()
        {

        }
        #endregion

        #region Commands

        #endregion

        #region private methods

        #endregion

        #region public methods

        public void SetText(string p_Text)
        {
            _TextSource = p_Text;
            RaisePropertyChanged("TextSource");
        }

        public void SetFontSize(int p_Size)
        {
            _FontSize = p_Size;
            RaisePropertyChanged("FontSize");
        }
        #endregion
    }
}
