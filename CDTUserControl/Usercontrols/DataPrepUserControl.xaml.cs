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
    /// Interaction logic for DataPrepUserControl.xaml
    /// </summary>
    public partial class DataPrepUserControl : UserControl
    {
       

        bool ControlIsLoaded = false;

        #region events

        public delegate void ExpanderChangeEventHandler(int WhichExpanded);
        public event ExpanderChangeEventHandler ExpanderChangeEvent;

        #endregion

        #region Constructor

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

        DataPrepViewModel vm;
        public DataPrepUserControl()
        {
            EnsureApplicationResources();
            InitializeComponent();
            vm = new DataPrepViewModel();
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
                    if (head == "Functions")
                    {
                        ExpanderChangeEvent(0);
                    }
                    else if (head == "Cleaning/Formatting")
                    {
                        ExpanderChangeEvent(1);
                    }
                    else if (head == "Brackets")
                    {
                        ExpanderChangeEvent(2);
                    }
                    else if (head == "FileName Creator")
                    {
                        ExpanderChangeEvent(3);
                    }
                    else if (head == "Character/Scene Manager")
                    {
                        ExpanderChangeEvent(3);
                    }
                }
            }
        }

        #endregion

        #region public methods

        public void SetStatusPane(string p_Value)
        {
            vm.SetStatusPane(p_Value);
        }
        
        public DataPrepViewModel getVM()
        {
            return vm.getVM();
        }



        #endregion

        #region Button handlers

        #region Functions

        public delegate void F_DeleteRows_ClickEventHandler();
        public event F_DeleteRows_ClickEventHandler F_DeleteRows_ClickEvent;

        private void F_DeleteRows_Click(object sender, RoutedEventArgs args)
        {
            F_DeleteRows_ClickEvent();
        }

        public delegate void F_Jumble_ClickEventHandler();
        public event F_Jumble_ClickEventHandler F_Jumble_ClickEvent;

        private void F_Jumble_Click(object sender, RoutedEventArgs args)
        {
            F_Jumble_ClickEvent();
        }

        public delegate void F_Fill_ClickEventHandler();
        public event F_Fill_ClickEventHandler F_Fill_ClickEvent;

        private void F_Fill_Click(object sender, RoutedEventArgs args)
        {
            F_Fill_ClickEvent();
        }

        public delegate void F_ResetLast_ClickEventHandler();
        public event F_ResetLast_ClickEventHandler F_ResetLast_ClickEvent;

        private void F_ResetLast_Click(object sender, RoutedEventArgs args)
        {
            F_ResetLast_ClickEvent();
        }

        public delegate void F_AddRowNo_ClickEventHandler();
        public event F_AddRowNo_ClickEventHandler F_AddRowNo_ClickEvent;

        private void F_AddRowNo_Click(object sender, RoutedEventArgs args)
        {
            F_AddRowNo_ClickEvent();
        }




        #endregion

        #region Cleaning/Formatting
        public delegate void C_Run_ClickEventHandler();
        public event C_Run_ClickEventHandler C_Run_ClickEvent;

        private void C_Run_Click(object sender, RoutedEventArgs args)
        {
            C_Run_ClickEvent();
        }





        #endregion

        #region Brackets
        public delegate void B_Extract_ClickEventHandler();
        public event B_Extract_ClickEventHandler B_Extract_ClickEvent;

        private void B_Extract_Click(object sender, RoutedEventArgs args)
        {
            B_Extract_ClickEvent();
        }


        #endregion

        #region FileName Creator

        public delegate void FN_Add_ClickEventHandler();
        public event FN_Add_ClickEventHandler FN_Add_ClickEvent;

        private void FN_Add_Click(object sender, RoutedEventArgs args)
        {
            FN_Add_ClickEvent();
        }

        public delegate void FN_Left_ClickEventHandler();
        public event FN_Left_ClickEventHandler FN_Left_ClickEvent;

        private void FN_Left_Click(object sender, RoutedEventArgs args)
        {
            FN_Left_ClickEvent();
        }

        public delegate void FN_Right_ClickEventHandler();
        public event FN_Right_ClickEventHandler FN_Right_ClickEvent;

        private void FN_Right_Click(object sender, RoutedEventArgs args)
        {
            FN_Right_ClickEvent();
        }

        public delegate void FN_Remove_ClickEventHandler();
        public event FN_Remove_ClickEventHandler FN_Remove_ClickEvent;

        private void FN_Remove_Click(object sender, RoutedEventArgs args)
        {
            FN_Remove_ClickEvent();
        }

        public delegate void FN_Reset_ClickEventHandler();
        public event FN_Reset_ClickEventHandler FN_Reset_ClickEvent;

        private void FN_Reset_Click(object sender, RoutedEventArgs args)
        {
            FN_Reset_ClickEvent();
        }

        public delegate void FN_Insert_ClickEventHandler();
        public event FN_Insert_ClickEventHandler FN_Insert_ClickEvent;

        private void FN_Insert_Click(object sender, RoutedEventArgs args)
        {
            FN_Insert_ClickEvent();
        }


        #endregion



        #region Character/Scene Manager

        public delegate void CS_Reload_ClickEventHandler();
        public event CS_Reload_ClickEventHandler CS_Reload_ClickEvent;

        private void CS_Reload_Click(object sender, RoutedEventArgs args)
        {
            CS_Reload_ClickEvent();
        }

        public delegate void CS_Apply_ClickEventHandler();
        public event CS_Apply_ClickEventHandler CS_Apply_ClickEvent;

        private void CS_Apply_Click(object sender, RoutedEventArgs args)
        {
            CS_Apply_ClickEvent();
        }

        #endregion

        #endregion
    }
}
