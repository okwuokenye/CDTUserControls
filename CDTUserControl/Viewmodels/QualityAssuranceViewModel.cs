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

        //private ColorPickerWindow _colorPicker;

        #endregion

        #region properties


        #endregion

        #region Constructor
        public QualityAssuranceViewModel()
        {
            //ShowColorPicker = new DelegateCommand(ShowColorPickerExecute, () => true);
            //Ok = new DelegateCommand(OkExecuted, () => true);
            //Cancel = new DelegateCommand(CancelExecuted, () => true);

            //// Create windows instance and set the DataContext to MainViewModel
            //_colorPicker = new ColorPickerWindow();
            //_colorPicker.DataContext = this;
        }
        

        public Color Color1 { get; set; }

        public ICommand ShowColorPicker { get; set; }

        public ICommand Ok { get; set; }
        public ICommand Cancel { get; set; }

        //private void CancelExecuted()
        //{
        //    _colorPicker.DialogResult = false;
        //    _colorPicker.Close();
        //}

        //private void OkExecuted()
        //{
        //    _colorPicker.DialogResult = true;
        //    _colorPicker.Close();
        //}


        #endregion
        #region Commands

        #endregion

        #region private methods

        #endregion

        #region public methods

        #endregion
    }
}

