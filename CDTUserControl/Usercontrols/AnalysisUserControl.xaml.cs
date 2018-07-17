﻿using CDTUserControl.Viewmodels;
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
    /// Interaction logic for AnalysisUserControl.xaml
    /// </summary>
    public partial class AnalysisUserControl : UserControl
    {
        AnalysisViewModel vm;
        public AnalysisUserControl()
        {
            InitializeComponent();
            vm = new AnalysisViewModel();
            base.DataContext = vm;
        }

        #region events declaration
        public delegate void CancelClickEvent();
        public event CancelClickEvent Cancel;

        public delegate void ReloadClickEvent();
        public event ReloadClickEvent Reload;

        public delegate void AnalyzeClickEvent();
        public event AnalyzeClickEvent Analyze;
        #endregion

        #region view event handlers
        private void CancelClick(object sender, RoutedEventArgs args)
        {
            if(Cancel != null)
            {
                Cancel();
            }
        }

        private void ReloadClick(object sender, RoutedEventArgs args)
        {
            if (Reload != null)
            {
                Reload();
            }
        }

        private void AnalyzeClick(object sender, RoutedEventArgs args)
        {
            if (Analyze != null)
            {
                Analyze();
            }
        }
        #endregion

        #region public methods
        public AnalysisViewModel GetVM()
        {
            return vm;
        }
        #endregion
    }
}