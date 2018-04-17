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
            List<String> l_Items = new List<String>() { "Try Me", "Try Me", "Try Me" };
            //ctrl.AddItemToEnglishTab(l_Items);

            //add event listener here
            ctrl.DeleteButtonEvent += Ctrl_DeleteButtonEvent;
            ctrl.EditButtonEvent += Ctrl_EditButtonEvent;
            ctrl.NavigateButtonEvent += Ctrl_NavigateButtonEvent;

            //add event for resizing winform screen
            //ctrl.ExtendSliderHeightEvent += Ctrl_ExtendSliderHeightEvent;
            //ctrl.IsSliderVisibleEvent += Ctrl_IsSliderVisibleEvent;
            //ctrl.ShowMetaDataEvent += Ctrl_ShowMetaDataEvent;

            //add control to element host
            elementHost1.Child = ctrl;
        }

        private void Ctrl_ShowMetaDataEvent(bool p_bool)
        {
            if (p_bool)
            {
                this.Width = this.Width + 150;
            }
            else
            {
                this.Width = this.Width - 150;
            }
        }

        private void Ctrl_IsSliderVisibleEvent(bool p_bool)
        {
            if (p_bool)
            {
                this.Height = this.Height + 130;
            }
            else
            {
                this.Height = this.Height - 130;
            }
        }

        private void Ctrl_ExtendSliderHeightEvent(bool p_bool)
        {
            if (p_bool)
            {
                this.Height = this.Height + 200;
            }
            else
            {
                this.Height = this.Height - 200;
            }
        }

        private void Ctrl_NavigateButtonEvent()
        {
            NavigationTest nav = new NavigationTest();
            nav.ShowDialog();
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

        private void Ctrl_DeleteButtonEvent(string p_FileName, Int32 p_Index)
        {
            MessageBox.Show("Delete clicked for " + p_FileName);
            ctrl.RemoveItemFromEnglishTab(p_Index);
        }

        private void Form_Resized(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            //ctrl.ResizeControl(control.Size.Width);
        }
        #endregion
    }
}
