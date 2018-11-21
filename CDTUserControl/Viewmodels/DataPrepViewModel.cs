using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDTUserControl.Viewmodels
{
    public class DataPrepViewModel : ObservableObject
    {
        #region Constructor
        public DataPrepViewModel()
        {

        }

        #endregion

        #region Events



        #endregion

        #region Properties
        string _StatusPane;
        public string StatusPane { get { return _StatusPane; } }
        
        #endregion

        #region public methods
        public void SetStatusPane(String p_Value)
        {
            _StatusPane = p_Value;
            RaisePropertyChanged("StatusPane");
        }

        public DataPrepViewModel getVM()
        {
            return this;
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
