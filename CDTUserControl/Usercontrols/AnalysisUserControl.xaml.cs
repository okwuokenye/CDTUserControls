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
    /// Interaction logic for AnalysisUserControl.xaml
    /// </summary>
    public partial class AnalysisUserControl : UserControl
    {
        AnalysisViewModel vm;
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


        public AnalysisUserControl()
        {
            EnsureApplicationResources();
            InitializeComponent();
            vm = new AnalysisViewModel();
            base.DataContext = vm;

            vm.ActiveSheetChangeEvent += Vm_ActiveSheetChangeEvent;
            ControlIsLoaded = true;
        }

        #region events declaration
        public delegate void CancelClickEvent();
        public event CancelClickEvent Cancel;

        public delegate void ReloadClickEvent();
        public event ReloadClickEvent Reload;

        public delegate void AnalyzeClickEvent();
        public event AnalyzeClickEvent Analyze;


        public delegate void ExpanderChangeEventHandler(int WhichExpanded);
        public event ExpanderChangeEventHandler ExpanderChangeEvent;
        
        public delegate void ActiveSheetChangeEventHandler(string p_Value);
        public event ActiveSheetChangeEventHandler ActiveSheetChangeEvent;

        public delegate void RecountClickEvent();
        public event RecountClickEvent Recount;

        public delegate void CopyEATClickEvent();
        public event CopyEATClickEvent CopyEAT;

        public delegate void CopyWCClickEvent();
        public event CopyWCClickEvent CopyWC;
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

        private void RecountClick(object sender, RoutedEventArgs args)
        {
            if (Recount != null)
            {
                Recount();
            }
        }

        private void AnalyzeClick(object sender, RoutedEventArgs args)
        {
            if (Analyze != null)
            {
                Analyze();
            }
        }

        private void CopyWCClick(object sender, RoutedEventArgs args)
        {
            if (CopyWC != null)
            {
                CopyWC();
            }
        }
        
        private void CopyEATClick(object sender, RoutedEventArgs args)
        {
            if (CopyEAT != null)
            {
                CopyEAT();
            }
        }
        #endregion

        #region public methods
        public AnalysisViewModel GetVM()
        {
            return vm;
        }


        public void AddExistingSheetsList(List<String> p_Sheets)
        {
            vm.AddExistingSheetsList(p_Sheets);
        }

        public void AddSheetsList(List<String> p_Sheets)
        {
            vm.AddSheetsList(p_Sheets);
        }

        public void SetStatusPane(string p_Value)
        {
            vm.SetStatusPane(p_Value);
        }

        public void SetSheetsIndex(int p_Value)
        {
            vm.SetSheetsIndex(p_Value);
        }

        public void SetExistingSheetsIndex(int p_Value)
        {
            vm.SetExistingSheetsIndex(p_Value);
        }


        public void SetCharacter(string p_Value)
        {
            vm.SetCharacter(p_Value);
        }

        public void SetText(string p_Value)
        {
            vm.SetText(p_Value);
        }
        public void SetScene(string p_Value)
        {
            vm.SetScene(p_Value);
        }
        public void SetSceneTxt(string p_Value)
        {
            vm.SetSceneTxt(p_Value);
        }

        public void SetTextTxt(string p_Value)
        {
            vm.SetTextTxt(p_Value);
        }
        public void SetCharacterTxt(string p_Value)
        {
            vm.SetCharacterTxt(p_Value);
        }
        
        public void SetHeaderIndex(int p_Value)
        {
            vm.SetHeaderIndex(p_Value);
        }

        private void Vm_ActiveSheetChangeEvent(string p_Value)
        {
            ActiveSheetChangeEvent(p_Value);
        }
        
        public void SetWCResult(string p_Value)
        {
            vm.SetWCResult(p_Value);
        }

        public void SetEATResult(string p_Value)
        {
            vm.SetEATResult(p_Value);
        }

        #endregion

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
                if(ControlIsLoaded)
                {
                    string head = exp1.Header.ToString();
                    if (head == "Production Analysis")
                    {
                        ExpanderChangeEvent(0);
                    }
                    else if (head == "Word Count")
                    {
                        ExpanderChangeEvent(1);
                    }
                }
                

            }
        }
        

        #region send methods
        public int SendMultiAnalysis()
        {
            return vm.GetMultiAnalysis();
        }
        public string SendCharacter()
        {
            return vm.SendCharacter();
        }
        public string SendText()
        {
            return vm.SendText();
        }
        public string SendScene()
        {
            return vm.SendScene();
        }
        public bool SendIsScene()
        {
            return vm.SendIsScene();
        }
        public int SendHeadRow()
        {
            return vm.SendHeadRow();
        }

        public bool SendIncludeLinesWithNoText()
        {
            return vm.SendIncludeLinesWithNoText();
        }
        public bool SendIgnoreStrikethroughText()
        {
            return vm.SendIgnoreStrikethroughText();
        }
        public bool SendIncludeLinesWithNoCharacter()
        {
            return vm.SendIncludeLinesWithNoCharacter();
        }
        public bool SendCloseUponCompletion()
        {
            return vm.SendCloseUponCompletion();
        }
        public bool SendAddToExistingSheet()
        {
            return vm.SendAddToExistingSheet();
        }
        public string SendExistingSheet()
        {
            return vm.SendExistingSheet();
        }


        public bool SendAutoRecount()
        {
            return vm.SendAutoRecount();
        }
        public bool SendExcludeHeader()
        {
            return vm.SendExcludeHeader();
        }
        public bool SendVisibleOnly()
        {
            return vm.SendVisibleOnly();
        }
        public bool SendIgnoreStrikeThrough()
        {
            return vm.SendIgnoreStrikeThrough();
        }
        public bool SendIgnoreItalics()
        {
            return vm.SendIgnoreItalics();
        }




        #endregion

    }
}
