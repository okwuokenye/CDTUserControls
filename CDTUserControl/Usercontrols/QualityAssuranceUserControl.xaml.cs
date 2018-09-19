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
    /// Interaction logic for QualityAssuranceUserControl.xaml
    /// </summary>
    public partial class QualityAssuranceUserControl : UserControl
    {

        public static void EnsureApplicationResources()
        {
            if (System.Windows.Application.Current == null)
            {
                new System.Windows.Application
                {
                    ShutdownMode = ShutdownMode.OnExplicitShutdown
                };
            }
        }

        QualityAssuranceViewModel vm;
        public QualityAssuranceUserControl()
        {
            EnsureApplicationResources();
            InitializeComponent();
            vm = new QualityAssuranceViewModel();
            base.DataContext = vm;
        }


        void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            if (e.Source is Expander)
            {
                var exp1 = (Expander)sender;
                foreach (Expander exp in ExpanderGrid.Children)
                {
                    if (exp != exp1)
                    {
                        exp.IsExpanded = false;
                    }
                }
            }
        }

        public void SetStatusPane(string p_Value)
        {
            vm.SetStatusPane(p_Value);
        }


    }
}
