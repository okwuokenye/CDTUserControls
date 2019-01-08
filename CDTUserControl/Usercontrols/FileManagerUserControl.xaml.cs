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
using System.IO;
using System.Data;
using System.Drawing;

namespace CDTUserControl.Usercontrols
{
    /// <summary>
    /// Interaction logic for FileManagerUserControl.xaml
    /// </summary>
    public partial class FileManagerUserControl : UserControl
    {
        bool ControlIsLoaded = false;
        private readonly object _dummyNode = null;
        System.Windows.Forms.TreeListView tvOverview;

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

        FileManagerViewModel vm;
        public FileManagerUserControl()
        {
            EnsureApplicationResources();
            InitializeComponent();
            vm = new FileManagerViewModel();
            base.DataContext = vm;

            ControlIsLoaded = true;
        }

        void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (e.Source is Expander)
                {
                    var exp1 = (Expander)sender;
                    foreach (Expander exp in ExpanderGrid.Children)
                    {
                        string h = exp.Header.ToString();
                        if (exp != exp1)
                        {
                            exp.IsExpanded = false;
                        }
                    }
                    if (ControlIsLoaded)
                    {
                        string head = exp1.Header.ToString();
                        if (head == "File List")
                        {
                            ExpanderChangeEvent(0);
                        }
                        else if (head == "Export Files")
                        {
                            ExpanderChangeEvent(1);
                        }
                        else if (head == "Project Overview")
                        {
                            ExpanderChangeEvent(2);
                        }
                        else if (head == "Compare Folders")
                        {
                            ExpanderChangeEvent(3);
                        }
                    }
                }
            }
            catch (Exception ex)
            {            
            
            }
        }

        #endregion

        #region public methods

        public void SetStatusPane(string p_Value)
        {
            vm.SetStatusPane(p_Value);
        }


        public FileManagerViewModel getVM()
        {
            return vm.getVM();
        }



        #endregion

        #region Button handlers

        #region FileList
        public delegate void FL_Root_ClickEventHandler();
        public event FL_Root_ClickEventHandler FL_Root_ClickEvent;

        private void FL_Root_Click(object sender, RoutedEventArgs args)
        {
            FL_Root_ClickEvent();
        }

        public delegate void FL_Load_ClickEventHandler();
        public event FL_Load_ClickEventHandler FL_Load_ClickEvent;

        private void FL_Load_Click(object sender, RoutedEventArgs args)
        {
            FL_Load_ClickEvent();
        }

        public delegate void FL_Clear_ClickEventHandler();
        public event FL_Clear_ClickEventHandler FL_Clear_ClickEvent;

        private void FL_Clear_Click(object sender, RoutedEventArgs args)
        {
            FL_Clear_ClickEvent();
        }

        public delegate void FL_Export_ClickEventHandler();
        public event FL_Export_ClickEventHandler FL_Export_ClickEvent;

        private void FL_Export_Click(object sender, RoutedEventArgs args)
        {
            FL_Export_ClickEvent();
        }

        #endregion

        #region Export Files
        public delegate void EF_Root1_ClickEventHandler();
        public event EF_Root1_ClickEventHandler EF_Root1_ClickEvent;

        private void EF_Root1_Click(object sender, RoutedEventArgs args)
        {
            EF_Root1_ClickEvent();
        }

        public delegate void EF_Root2_ClickEventHandler();
        public event EF_Root2_ClickEventHandler EF_Root2_ClickEvent;

        private void EF_Root2_Click(object sender, RoutedEventArgs args)
        {
            EF_Root2_ClickEvent();
        }

        public delegate void EF_Preview_ClickEventHandler();
        public event EF_Preview_ClickEventHandler EF_Preview_ClickEvent;

        private void EF_Preview_Click(object sender, RoutedEventArgs args)
        {
            EF_Preview_ClickEvent();
        }

        public delegate void EF_Export_ClickEventHandler();
        public event EF_Export_ClickEventHandler EF_Export_ClickEvent;

        private void EF_Export_Click(object sender, RoutedEventArgs args)
        {
            EF_Export_ClickEvent();
        }

        public void SetPreviewDataGrid(DataTable p_Tbl)
        {
            PreviewDataGrid.ItemsSource = p_Tbl.AsDataView();
            PreviewDataGrid.Columns[0].Width = 50;
            PreviewDataGrid.Columns[1].Width = 300;
            PreviewDataGrid.Columns[2].Width = 300;
        }

        #endregion

        #region Project Overview

        public void ProjectOverviewLoad()
        {
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();
            
            tvOverview = new System.Windows.Forms.TreeListView();
            
            System.Windows.Forms.ImageList myImageList = new System.Windows.Forms.ImageList();
            BitmapImage bmp = new BitmapImage(new Uri("../Resources/mute.png", UriKind.Relative));

            myImageList.Images.Add("0",bmp);

            //tvOverview.SmallImageList = myImageList;
            host.Child = tvOverview;
            this.gridTree.Children.Add(host);
        }
        
        public delegate void PO_Root_ClickEventHandler();
        public event PO_Root_ClickEventHandler PO_Root_ClickEvent;

        private void PO_Root_Click(object sender, RoutedEventArgs args)
        {
            PO_Root_ClickEvent();
        }

        public delegate void PO_Load_ClickEventHandler(System.Windows.Forms.TreeListView tv);
        public event PO_Load_ClickEventHandler PO_Load_ClickEvent;

        private void PO_Load_Click(object sender, RoutedEventArgs args)
        {
            ProjectOverviewLoad();
            PO_Load_ClickEvent(tvOverview);
        }

        public delegate void PO_Reset_ClickEventHandler();
        public event PO_Reset_ClickEventHandler PO_Reset_ClickEvent;

        private void PO_Reset_Click(object sender, RoutedEventArgs args)
        {
            PO_Reset_ClickEvent();
        }
        
        public delegate void PO_Expand_ClickEventHandler();
        public event PO_Expand_ClickEventHandler PO_Expand_ClickEvent;

        private void PO_Expand_Click(object sender, RoutedEventArgs args)
        {
            PO_Expand_ClickEvent();
        }

        public delegate void PO_Collapse_ClickEventHandler();
        public event PO_Collapse_ClickEventHandler PO_Collapse_ClickEvent;

        private void PO_Collapse_Click(object sender, RoutedEventArgs args)
        {
            PO_Collapse_ClickEvent();
        }

        #endregion

        #region Folder Compare
        public delegate void CF_Root1_ClickEventHandler();
        public event CF_Root1_ClickEventHandler CF_Root1_ClickEvent;

        private void CF_Root1_Click(object sender, RoutedEventArgs args)
        {
            CF_Root1_ClickEvent();
        }

        public delegate void CF_Root2_ClickEventHandler();
        public event CF_Root2_ClickEventHandler CF_Root2_ClickEvent;

        private void CF_Root2_Click(object sender, RoutedEventArgs args)
        {
            CF_Root2_ClickEvent();
        }

        public delegate void CF_Compare_ClickEventHandler();
        public event CF_Compare_ClickEventHandler CF_Compare_ClickEvent;

        private void CF_Compare_Click(object sender, RoutedEventArgs args)
        {
            CF_Compare_ClickEvent();
        }

        #endregion
        #endregion
        #region DragDrop

        public delegate void FL_DropEventHandler(string[] files);
        public event FL_DropEventHandler FL_DropEvent;

        private void DropList_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop) ||
                sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
            else
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void DropList_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {  
            string[] files = (string[])(e.Data.GetData(DataFormats.FileDrop, false));
            FL_DropEvent(files);
            }
        }

        #endregion


    }
    
}
