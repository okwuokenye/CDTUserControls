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
        bool ControlIsLoaded = false;

        #region events

        public delegate void ExpanderChangeEventHandler(int WhichExpanded);
        public event ExpanderChangeEventHandler ExpanderChangeEvent;

        public delegate void ResetFilesEventHandler();
        public event ResetFilesEventHandler ResetFilesEvent;

        public delegate void CheckFilesEventHandler();
        public event CheckFilesEventHandler CheckFilesEvent;

        public delegate void CompareColumnsEventHandler();
        public event CompareColumnsEventHandler CompareColumnsEvent;

        public delegate void UpdateHeadersEventHandler();
        public event UpdateHeadersEventHandler UpdateHeadersEvent;

        public delegate void FindAssetsEventHandler();
        public event FindAssetsEventHandler FindAssetsEvent;

        public delegate void MarkDuplicatesEventHandler();
        public event MarkDuplicatesEventHandler MarkDuplicatesEvent;

        public delegate void InsertClickEvent();
        public event InsertClickEvent InsertEvent;

        public delegate void ResetInsertClickEvent();
        public event ResetInsertClickEvent ResetInsertEvent;

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

        #endregion

        #region public methods

        public void SetStatusPane(string p_Value)
        {
            vm.SetStatusPane(p_Value);
        }


        public QualityAssuranceViewModel getVM()
        {
            return vm.getVM();
        }



        #endregion

        #region Button handlers
        
        private void CheckFilesClick(object sender, RoutedEventArgs args)
        {
            if (CheckFilesEvent != null)
            {
                CheckFilesEvent();
            }
        }
        
        private void ResetClick(object sender, RoutedEventArgs args)
        {
            if (ResetFilesEvent != null)
            {
                ResetFilesEvent();
            }
        }
        
        private void CompareColsClick(object sender, RoutedEventArgs args)
        {
            if (CompareColumnsEvent != null)
            {
                CompareColumnsEvent();
            }
        }

        private void FindAssetsClick(object sender, RoutedEventArgs args)
        {
            if (FindAssetsEvent != null)
            {
                FindAssetsEvent();
            }
        }

        private void UpdateHeadClick(object sender, RoutedEventArgs args)
        {
            if (UpdateHeadersEvent != null)
            {
                UpdateHeadersEvent();
            }
        }

        private void MarkDuplicatesClick(object sender, RoutedEventArgs args)
        {
            if (MarkDuplicatesEvent != null)
            {
                MarkDuplicatesEvent();
            }
        }
        
        private void InsertDataClick(object sender, RoutedEventArgs args)
        {
            if (InsertEvent != null)
            {
                InsertEvent();
            }
        }

        private void ResetInsertDataClick(object sender, RoutedEventArgs args)
        {
            if (ResetInsertEvent != null)
            {
                ResetInsertEvent();
            }
        }

        private void OpenColor(object sender, MouseButtonEventArgs e)
        {
            Color? cl = null;
            
                var cb1 = (CheckBox)sender;                
                    string head = cb1.Content.ToString();
                    if (head == "Mark missing files")
                    {
                    cl = vm.Color1;
                }
                    else if (head == "Mark corrupted files")
                    {
                    cl = vm.Color2;
                }
                    else if (head == "Mark possible missedits")
                    {
                    cl = vm.Color3;
                }
                    else if (head == "Find lost primaries")
                    {
                    cl = vm.Color4;
                }
                    else if (head == "Reorder Alt Files")
                    {
                    cl = vm.Color5;
                }
                    else if (head == "Trim Spaces from File")
                    {
                    cl = vm.Color6;
                }
                       
                        

            ColorPickerWindow l_Color = new ColorPickerWindow(cl);

            //This is meant to open the window at the position of the mouse pointer but it does not work with dual screens. Any ideas?
            var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
            var mouse = transform.Transform(GetMousePosition());
            l_Color.Left = mouse.X - this.ActualWidth;
            l_Color.Top = mouse.Y - this.ActualHeight;            
            
            bool? result =  l_Color.ShowDialog();

            if (head == "Mark missing files")
            {
                vm.Color1 = l_Color.ColorSelected;
            }
            else if (head == "Mark corrupted files")
            {
                vm.Color2 = l_Color.ColorSelected;
            }
            else if (head == "Mark possible missedits")
            {
                vm.Color3 = l_Color.ColorSelected;
            }
            else if (head == "Find lost primaries")
            {
                vm.Color4 = l_Color.ColorSelected;
            }
            else if (head == "Reorder Alt Files")
            {
                vm.Color5 = l_Color.ColorSelected;
            }
            else if (head == "Trim Spaces from File")
            {
                vm.Color6 = l_Color.ColorSelected;
            }                
            
        }
               

        public System.Windows.Point GetMousePosition()
        {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            return new System.Windows.Point(point.X, point.Y);
        }



        #endregion


    }
}
