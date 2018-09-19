using CDTUserControl.Viewmodels;
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

namespace CDTUserControl.Usercontrols
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : UserControl
    {
        SplashScreenViewModel vm;
        
        public SplashScreen()
        {
            InitializeComponent();
            vm = new SplashScreenViewModel();
            base.DataContext = vm;
        }


        #region events declaration
        public delegate void CancelClickEvent();
        public event CancelClickEvent Cancel;

        public delegate void MinimizeClickEvent();
        public event MinimizeClickEvent Minimize;

        #endregion
        
        #region view event handlers
        private void CancelClick(object sender, RoutedEventArgs args)
        {
            if (Cancel != null)
            {
                Cancel();
            }
        }
        
        private void MinClick(object sender, RoutedEventArgs args)
        {
            if (Cancel != null)
            {
                Minimize();
            }
        }

        #endregion

        #region Set Methods

        public void SetTitle(string p_Value)
        {
            vm.SetTitle(p_Value);
        }

        public void SetProgressText(string p_Value)
        {
            vm.SetProgressText(p_Value);
        }

        public void SetProgressValue(int p_Value)
        {
            vm.SetProgressValue(p_Value);
        }

        public void SetProgressMax(int p_Value)
        {
            vm.SetProgressMax(p_Value);
        }
        
        public void SetProgressSet(bool p_Value)
        {
            vm.SetProgressSet(p_Value);
        }

        public void SendStartup(string p_Title, string p_Text, int p_Max, int p_Value,bool p_Bool)
        {
            vm.SetProgressText(p_Text);
            vm.SetTitle(p_Title);
            vm.SetProgressValue(p_Value);
            vm.SetProgressMax(p_Max);
            vm.SetProgressSet(p_Bool);

        }

        public void SendUpdate(string p_Text, int p_Value)
        {
            vm.SetProgressText(p_Text);
            vm.SetProgressValue(p_Value);
        }

        #endregion

    }
}
