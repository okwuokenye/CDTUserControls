using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CDTUserControl.Viewmodels;

namespace CDTUserControl.Usercontrols
{
    /// <summary>
    /// Interaction logic for LicenseManagerUserControl.xaml
    /// </summary>
    public partial class LicenseManagerUserControl : UserControl
    {
        LicenseManagerViewModel vm;

        #region event declarations

        public delegate void RecheckButtonEventHandler();
        public event RecheckButtonEventHandler RecheckButtonEvent;
        
        public delegate void InstallButtonEventHandler();
        public event InstallButtonEventHandler InstallButtonEvent;
        
        public delegate void UninstallButtonEventHandler();
        public event UninstallButtonEventHandler UninstallButtonEvent;

        #endregion

        #region constructor

        public LicenseManagerUserControl()
        {
            InitializeComponent();
            vm = new LicenseManagerViewModel();

            vm.RecheckButtonEvent += Vm_RecheckButtonEvent;
            vm.InstallButtonEvent += Vm_InstallButtonEvent;
            vm.UninstallButtonEvent += Vm_UninstallButtonEvent;
            //add event listeners

            base.DataContext = vm;
        }

        #endregion

        #region event handlers

        private void Vm_RecheckButtonEvent()
        {
            RecheckButtonEvent();
        }

        private void Vm_InstallButtonEvent()
        {
            InstallButtonEvent();
        }

        private void Vm_UninstallButtonEvent()
        {
            UninstallButtonEvent();
        }


        #endregion

        #region public set methods

        public void SetProductName(string p_Value)
        {
            vm.SetProductName(p_Value);
        }

        public void SetComputerID(string p_Value)
        {
            vm.SetComputerID(p_Value);
        }
        public void SetLicenseKey(string p_Value)
        {
            vm.SetLicenseKey(p_Value);
        }
        public void SetLicenseState(string p_Value)
        {
            vm.SetLicenseState(p_Value);
        }
        public void SetSerialNumber(string p_Value)
        {
            vm.SetSerialNumber(p_Value);
        }
        public void SetFirstAuth(string p_Value)
        {
            vm.SetFirstAuth(p_Value);
        }
        public void SetExpiryDate(string p_Value)
        {
            vm.SetExpiryDate(p_Value);
        }
        public void SetStatusWarn(string p_Value)
        {
            vm.SetStatusWarn(p_Value);
        }

        #endregion

    }
}
