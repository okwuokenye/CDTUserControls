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
    /// Interaction logic for QualityAssuranceUserControl.xaml
    /// </summary>
    public partial class QualityAssuranceUserControl : UserControl
    {
        QualityAssuranceViewModel vm;
        public QualityAssuranceUserControl()
        {
            InitializeComponent();
            vm = new QualityAssuranceViewModel();
            base.DataContext = vm;
        }
    }
}