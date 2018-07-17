using System;
using CDTUserControl.Usercontrols;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCDT
{
    public partial class NavigationTest : Form
    {
        NavigationUserControl ctrl;
        public NavigationTest()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            ctrl = new NavigationUserControl();

            //navigation control and event listener
            ctrl.PreviousButtonEvent += Nav_PreviousButtonEvent;
            ctrl.Visibility = System.Windows.Visibility.Visible;

            ctrl.Visibility = System.Windows.Visibility.Visible;
            //add control to element host
            elementHost1.Child = ctrl;

        }
        
        private void Nav_PreviousButtonEvent()
        {
            MessageBox.Show("Previous Clicked");
        }
    }
}
