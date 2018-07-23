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
        AnalysisUserControl ctrl;
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load_1(object sender, EventArgs e)
        {
            ctrl = new AnalysisUserControl();
            ctrl.Visibility = System.Windows.Visibility.Visible;
            
            //get the viewmodel
            var vm = ctrl.GetVM();

            //the view model has all the methods to set text in textboxes and refresh the view

            //add item to the sheets combobox
            vm.AddSheetToAnalyze("Test");

            //add to the UIList item combo box
            vm.AddUListItem("Test 2");

            //methods to set textboxes
            vm.SetText("Text");
            vm.SetTextTxt("2");

            vm.SetCharacter("Character");
            vm.SetCharacterTxt("2");

            vm.SetScene("Scene");
            vm.SetSceneTxt("2");

            //event handler for SettingsExpanderChange
            ctrl.SettingsExpanderChangeEvent += Ctrl_SettingsExpanderChangeEvent;
            elementHost1.Child = ctrl;
        }

        private void Ctrl_SettingsExpanderChangeEvent(bool IsExpanded)
        {
            MessageBox.Show("Settings has changed: " + IsExpanded.ToString());
        }

        private void Ctrl_ShowMetaDataEvent(bool p_bool, int p_Value)
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

        private void Ctrl_IsSliderVisibleEvent(bool p_bool, int p_Value)
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

        private void Ctrl_ExtendSliderHeightEvent(bool p_bool, int p_Value)
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
          //  ctrl.RemoveItemFromEnglishTab(p_Index);
        }

        private void Form_Resized(object sender, EventArgs e)
        {
            Control control = (Control)sender;
        }
        #endregion
    }
}
