using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDTUserControl.Viewmodels
{
    class VisualViewerViewModel : ObservableObject
    {
        #region Events

        #endregion

        #region private variables
        string _ImageSource = string.Empty;
        #endregion

        #region properties
        public string ImageSource { get { return _ImageSource; } }
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
