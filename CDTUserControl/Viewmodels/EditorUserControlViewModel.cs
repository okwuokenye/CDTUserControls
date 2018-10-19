using System;
using System.IO;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CDTUserControl.Viewmodels
{
    public class EditorUserControlViewModel : ObservableObject
    {
        #region Properties
        
        string _StatusPane;

        public string StatusPane { get { return _StatusPane; } set { if (_StatusPane != value) { _StatusPane = value; RaisePropertyChanged("StatusPane"); } } }

        #endregion
        
        #region Constructors

        public EditorUserControlViewModel()
        {

        }


        #endregion

        #region Public Methods

        public EditorUserControlViewModel getVM()
        {
            return this;
        }

        public void SetStatusPane(String p_Value)
        {
            _StatusPane = p_Value;
        }

        public void RefreshVM()
        {
            foreach (System.Reflection.PropertyInfo p in this.GetType().GetProperties())
            {
                RaisePropertyChanged(p.Name);
            }
        }

        #endregion


    }
}
