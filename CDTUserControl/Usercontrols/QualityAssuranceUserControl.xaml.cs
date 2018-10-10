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

        #region events

        public delegate void ResetEventHandler();
        public event ResetEventHandler ResetEvent;

        public delegate void CheckFilesEventHandler(QualityAssuranceViewModel vm);
        public event CheckFilesEventHandler CheckFilesEvent;

        public delegate void CompareColumnsEventHandler();
        public event CompareColumnsEventHandler CompareColumnsEvent;

        public delegate void UpdateHeadersEventHandler();
        public event UpdateHeadersEventHandler UpdateHeadersEvent;

        public delegate void FindAssetsEventHandler();
        public event FindAssetsEventHandler FindAssetsEvent;

        public delegate void MarkDuplicatesEventHandler();
        public event MarkDuplicatesEventHandler MarkDuplicatesEvent;

        public delegate void InsertDataEventHandler();
        public event InsertDataEventHandler InsertDataEvent;

        #endregion

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


        public QualityAssuranceViewModel getVM()
        {
            return vm.getVM();
        }
        #region InsertData

        public delegate void InsertClickEvent();
        public event InsertClickEvent InsertClick;

        private void InsertDataClick(object sender, RoutedEventArgs args)
        {
            if (InsertClick != null)
            {
                InsertClick();
            }
        }
        
        //public bool Send_PL_WordCount()
        //{
        //    return vm.Send_PL_WordCount();
        //}

        //public bool Send_PL_EAT()
        //{
        //    return vm.Send_PL_EAT();
        //}

        //public bool Send_PL_AAT()
        //{
        //    return vm.Send_PL_AAT();
        //}

        //public bool Send_PL_DiffToEAT()
        //{
        //    return vm.Send_PL_DiffToEAT();
        //}

        //public bool Send_PL_AATDiffMS()
        //{
        //    return vm.Send_PL_AATDiffMS();
        //}

        //public bool Send_PL_AATDiffPercent()
        //{
        //    return vm.Send_PL_AATDiffPercent();
        //}

        //public bool Send_SL_WordCount()
        //{
        //    return vm.Send_SL_WordCount();
        //}

        //public bool Send_SL_EAT()
        //{
        //    return vm.Send_SL_EAT();
        //}

        //public bool Send_SL_AAT()
        //{
        //    return vm.Send_SL_AAT();
        //}

        //public bool Send_SL_DiffToEAT()
        //{
        //    return vm.Send_SL_DiffToEAT();
        //}
        
        //public bool Send_SL_Min()
        //{
        //    return vm.Send_SL_Min();
        //}

        //public bool Send_SL_Max()
        //{
        //    return vm.Send_SL_Max();
        //}

        //public bool Send_AD_Visible()
        //{
        //    return vm.Send_AD_Visible();
        //}

        //public bool Send_IW_TargetColumn()
        //{
        //    return vm.Send_IW_TargetColumn();
        //}

        //public bool Send_S_ColourCode()
        //{
        //    return vm.Send_S_ColourCode();
        //}

        //public int Send_TargetIndex()
        //{
        //    return vm.Send_TargetIndex();
        //}

        #endregion


    }
}
