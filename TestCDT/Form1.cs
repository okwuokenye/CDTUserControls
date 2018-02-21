using CDTUserControl.Usercontrols;
using System;
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
    public partial class Form1 : Form
    {
        nCDT ctrl;
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load_1(object sender, EventArgs e)
        {
            ctrl = new nCDT();

            //navigation control and event listener
            ctrl.Nav.PreviousButtonEvent += Nav_PreviousButtonEvent;
            ctrl.Nav.Visibility = System.Windows.Visibility.Visible;

            ctrl.Visibility = System.Windows.Visibility.Visible;
            //elementHost1.BackColor = Color.Black;
            ctrl.AddItemToEnglishTab("Try Me");

            //add event listener here
            ctrl.DeleteButtonEvent += Ctrl_DeleteButtonEvent;
            ctrl.EditButtonEvent += Ctrl_EditButtonEvent;
            ctrl.NavigateButtonEvent += Ctrl_NavigateButtonEvent;
            //add control to element host
            elementHost1.Child = ctrl;
        }

        private void Ctrl_NavigateButtonEvent()
        {
            elementHost1.Child = ctrl.Nav;
        }

        private void Nav_PreviousButtonEvent()
        {
            MessageBox.Show("Previous Clicked");
        }

        #region event handlers
        private void Ctrl_EditButtonEvent(string p_FileName)
        {
            MessageBox.Show("Edit clicked for " +p_FileName);
        }

        private void Ctrl_DeleteButtonEvent(string p_FileName)
        {
            MessageBox.Show("Delete clicked for " + p_FileName);
        }
        #endregion
    }
}
