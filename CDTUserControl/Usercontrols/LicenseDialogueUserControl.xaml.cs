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
    /// Interaction logic for LicenseDialogueUserControl.xaml
    /// </summary>
    public partial class LicenseDialogueUserControl : UserControl
    {
        LicenseDialogueViewModel vm;

        #region event declarations





        #endregion

        #region constructor

        public LicenseDialogueUserControl()
        {
            InitializeComponent();
            vm = new LicenseDialogueViewModel();

            //add event listeners




            base.DataContext = vm;
        }

        #endregion

        #region event handlers




        #endregion

        #region public set methods



        #endregion

        #region public send functions


        #endregion
    }
}
