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

        public delegate void ExpanderChangeEventHandler(int WhichExpanded);
        public event ExpanderChangeEventHandler ExpanderChangeEvent;

        bool ControlIsLoaded = false;

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
            ControlIsLoaded = true;
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
                if (ControlIsLoaded)
                {
                    string head = exp1.Header.ToString();
                    if (head == "File Checks (mark missing)")
                    {
                        ExpanderChangeEvent(0);
                    }
                    else if (head == "Compare Columns")
                    {
                        ExpanderChangeEvent(1);
                    }
                    else if (head == "Find Missing Assets")
                    {
                        ExpanderChangeEvent(2);
                    }
                    else if (head == "Mark Duplicates")
                    {
                        ExpanderChangeEvent(3);
                    }
                    else if (head == "Insert Audio Data")
                    {
                        ExpanderChangeEvent(4);
                    }
                }
            }
        }

        public void SetStatusPane(string p_Value)
        {
            vm.SetStatusPane(p_Value);
        }


        #region InsertData

        public delegate void InsertClickEvent();
        public event InsertClickEvent InsertClick;

        public delegate void ResetInsertClickEvent();
        public event ResetInsertClickEvent ResetInsertClick;

        private void ResetInsertDataClick(object sender, RoutedEventArgs args)
        {
            if (ResetInsertClick != null)
            {
                ResetInsertClick();
            }
        }

        private void InsertDataClick(object sender, RoutedEventArgs args)
        {
            if (InsertClick != null)
            {
                InsertClick();
            }
        }
        public bool Send_PL_WordCount()
        {
            return vm.Send_PL_WordCount();
        }

        public bool Send_PL_EAT()
        {
            return vm.Send_PL_EAT();
        }

        public bool Send_PL_AAT()
        {
            return vm.Send_PL_AAT();
        }

        public bool Send_PL_DiffToEAT()
        {
            return vm.Send_PL_DiffToEAT();
        }

        public bool Send_PL_AATDiffMS()
        {
            return vm.Send_PL_AATDiffMS();
        }

        public bool Send_PL_AATDiffPercent()
        {
            return vm.Send_PL_AATDiffPercent();
        }

        public bool Send_SL_WordCount()
        {
            return vm.Send_SL_WordCount();
        }

        public bool Send_SL_EAT()
        {
            return vm.Send_SL_EAT();
        }

        public bool Send_SL_AAT()
        {
            return vm.Send_SL_AAT();
        }

        public bool Send_SL_DiffToEAT()
        {
            return vm.Send_SL_DiffToEAT();
        }
        
        public bool Send_SL_Min()
        {
            return vm.Send_SL_Min();
        }

        public bool Send_SL_Max()
        {
            return vm.Send_SL_Max();
        }

        public bool Send_AD_Visible()
        {
            return vm.Send_AD_Visible();
        }

        public bool Send_IW_TargetColumn()
        {
            return vm.Send_IW_TargetColumn();
        }

        public bool Send_S_ColourCode()
        {
            return vm.Send_S_ColourCode();
        }

        public int Send_TargetIndex()
        {
            return vm.Send_TargetIndex();
        }



        public void SetPLText(bool p_Value)
        {
            vm.SetPLText(p_Value);
        }
        public void SetSLText(bool p_Value)
        {
            vm.SetSLText(p_Value);
        }
        public void SetPLFile(bool p_Value)
        {
            vm.SetPLFile(p_Value);
        }
        public void SetSLFile(bool p_Value)
        {
            vm.SetSLFile(p_Value);
        }

        public void Set_TargetIndex(int p_Value)
        {
            vm.Set_TargetIndex(p_Value);
        }
        #endregion


    }
}
