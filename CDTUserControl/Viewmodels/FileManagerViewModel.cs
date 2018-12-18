using CDTUserControl.Usercontrols;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;
using System.Windows.Media;
using System.Windows;
using System.Data;

namespace CDTUserControl.Viewmodels
{
    public class FileManagerViewModel : ObservableObject
    {
        #region Constructor
        public FileManagerViewModel()
        {

        }

        #endregion

        #region Events



        #endregion

        #region Properties

        string _StatusPane;
        public string StatusPane { get { return _StatusPane; } }

        #region FileList

        string _FL_Root;
        bool _FL_IncExt = true;
        string _FL_IncExtStr = "wav";
        bool _FL_ExcText;
        string _FL_ExcTextStr;
        bool _FL_Add;
        bool _FL_Sub = true;
        bool _FL_Audio;
        bool _FL_File;
        bool _FL_Corrupt;
        ObservableCollection<string> _FL_FileList = new ObservableCollection<string>();
        
        public string FL_Root { get { return _FL_Root; } set { if (_FL_Root != value) { _FL_Root = value; } } }
        public bool FL_IncExt { get { return _FL_IncExt; } set { if (_FL_IncExt != value) { _FL_IncExt = value; RaisePropertyChanged("FL_Ext_Visible"); } } }
        public string FL_IncExtStr { get { return _FL_IncExtStr; } set { if (_FL_IncExtStr != value) { _FL_IncExtStr = value; } } }
        public bool FL_ExcText { get { return _FL_ExcText; } set { if (_FL_ExcText != value) { _FL_ExcText = value; RaisePropertyChanged("FL_Text_Visible"); } } }
        public string FL_ExcTextStr { get { return _FL_ExcTextStr; } set { if (_FL_ExcTextStr != value) { _FL_ExcTextStr = value; } } }
        public bool FL_Add { get { return _FL_Add; } set { if (_FL_Add != value) { _FL_Add = value; } } }
        public bool FL_Sub { get { return _FL_Sub; } set { if (_FL_Sub != value) { _FL_Sub = value; } } }
        public bool FL_Audio { get { return _FL_Audio; } set { if (_FL_Audio != value) { _FL_Audio = value; } } }
        public bool FL_File { get { return _FL_File; } set { if (_FL_File != value) { _FL_File = value; } } }
        public bool FL_Corrupt { get { return _FL_Corrupt; } set { if (_FL_Corrupt != value) { _FL_Corrupt = value; } } }
        public ObservableCollection<string> FL_FileList { get { return _FL_FileList; } }
        public Visibility FL_Ext_Visible { get { return _FL_IncExt ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility FL_Text_Visible { get { return _FL_ExcText ? Visibility.Visible : Visibility.Collapsed; } }

        #endregion

        #region Export Files

        bool _EF_MakePath = true;
        string _EF_Origin_Root;
        bool _EF_IsDir1 = true;
        string _EF_Directory1;
        string _EF_Directory_Col1;
        string _EF_FileName1;
        string _EF_FileName_Col1;
        string _EF_ExtStr = ".wav";
        bool _EF_Alts = true;
        string _EF_Dest_Root;
        bool _EF_IsDir2 = true;
        string _EF_Directory2;
        string _EF_Directory_Col2;
        string _EF_FileName2;
        string _EF_FileName_Col2;
        ObservableCollection<string> _EF_ColumnItems = new ObservableCollection<string>();
        int _EF_ColumnIndex1;
        int _EF_ColumnIndex2;
        bool _EF_SelectionOnly;
        bool _EF_IsExport_Visible = false;
        DataTable _EF_PreviewDataTable;
        
        public bool EF_MakePath { get { return _EF_MakePath; } set { if (_EF_MakePath != value) { _EF_MakePath = value; RaisePropertyChanged("EF_MakePath_Visible"); RaisePropertyChanged("EF_FullPath_Visible"); } } }
        public string EF_Origin_Root { get { return _EF_Origin_Root; } set { if (_EF_Origin_Root != value) { _EF_Origin_Root = value; } } }
        public bool EF_IsDir1 { get { return _EF_IsDir1; } set { if (_EF_IsDir1 != value) { _EF_IsDir1 = value; RaisePropertyChanged("EF_Directory1_Visible"); } } }
        public string EF_Directory1 { get { return _EF_Directory1; } set { if (_EF_Directory1 != value) { _EF_Directory1 = value; } } }
        public string EF_Directory_Col1 { get { return _EF_Directory_Col1; } set { if (_EF_Directory_Col1 != value) { _EF_Directory_Col1 = value; } } }
        public string EF_FileName1 { get { return _EF_FileName1; } set { if (_EF_FileName1 != value) { _EF_FileName1 = value; } } }
        public string EF_FileName_Col1 { get { return _EF_FileName_Col1; } set { if (_EF_FileName_Col1 != value) { _EF_FileName_Col1 = value; } } }
        public string EF_ExtStr { get { return _EF_ExtStr; } set { if (_EF_ExtStr != value) { _EF_ExtStr = value; } } }
        public bool EF_Alts { get { return _EF_Alts; } set { if (_EF_Alts != value) { _EF_Alts = value; } } }
        public string EF_Dest_Root { get { return _EF_Dest_Root; } set { if (_EF_Dest_Root != value) { _EF_Dest_Root = value; } } }
        public bool EF_IsDir2 { get { return _EF_IsDir2; } set { if (_EF_IsDir2 != value) { _EF_IsDir2 = value; RaisePropertyChanged("EF_Directory2_Visible"); } } }
        public string EF_Directory2 { get { return _EF_Directory2; } set { if (_EF_Directory2 != value) { _EF_Directory2 = value; } } }
        public string EF_Directory_Col2 { get { return _EF_Directory_Col2; } set { if (_EF_Directory_Col2 != value) { _EF_Directory_Col2 = value; } } }
        public string EF_FileName2 { get { return _EF_FileName2; } set { if (_EF_FileName2 != value) { _EF_FileName2 = value; } } }
        public string EF_FileName_Col2 { get { return _EF_FileName_Col2; } set { if (_EF_FileName_Col2 != value) { _EF_FileName_Col2 = value; } } }
        public ObservableCollection<string> EF_ColumnItems { get { return _EF_ColumnItems; } }
        public int EF_ColumnIndex1 { get { return _EF_ColumnIndex1; } set { if (_EF_ColumnIndex1 != value) { _EF_ColumnIndex1 = value; } } }
        public int EF_ColumnIndex2 { get { return _EF_ColumnIndex2; } set { if (_EF_ColumnIndex2 != value) { _EF_ColumnIndex2 = value; } } }
        public bool EF_SelectionOnly { get { return _EF_SelectionOnly; } set { if (_EF_SelectionOnly != value) { _EF_SelectionOnly = value; } } }
        public string EF_PreviewText { get { return _EF_IsExport_Visible ? "Reset Preview" : "Open Preview"; } }
        public bool EF_IsExport_Visible { get { return _EF_IsExport_Visible; } set { if (_EF_IsExport_Visible != value) { _EF_IsExport_Visible = value; RaisePropertyChanged("EF_Preview_Visible"); RaisePropertyChanged("EF_Export_Visible"); RaisePropertyChanged("EF_PreviewText"); } } }
        public Visibility EF_Directory1_Visible { get { return _EF_IsDir1 ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility EF_Directory2_Visible { get { return _EF_IsDir2 ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility EF_MakePath_Visible { get { return _EF_MakePath ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility EF_FullPath_Visible { get { return _EF_MakePath ? Visibility.Collapsed : Visibility.Visible; } }
        public Visibility EF_Export_Visible { get { return _EF_IsExport_Visible ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility EF_Preview_Visible { get { return _EF_IsExport_Visible ? Visibility.Visible : Visibility.Collapsed; } }
        public DataTable EF_PreviewDataTable { get { return _EF_PreviewDataTable; } }

        #endregion

        #region Project Overview
        
        string _PO_Root;
        
        public string PO_Root { get { return _PO_Root; } set { if (_PO_Root != value) { _PO_Root = value; } } }

        DataTable _PO_Table;
        public DataTable PO_Table { get { return _PO_Table; } set { _PO_Table = value; RaisePropertyChanged("PO_Table"); } }
               
        #endregion

        #region Compare Folders

        string _CF_Master_Root;
        string _CF_Second_Root;
        bool _CF_IncExt;
        string _CF_IncExtStr;
        bool _CF_ExcText;
        string _CF_ExcTextStr;
        bool _CF_Sub;

        public string CF_Master_Root { get { return _CF_Master_Root; } set { if (_CF_Master_Root != value) { _CF_Master_Root = value; } } }
        public string CF_Second_Root { get { return _CF_Second_Root; } set { if (_CF_Second_Root != value) { _CF_Second_Root = value; } } }
        public bool CF_IncExt { get { return _CF_IncExt; } set { if (_CF_IncExt != value) { _CF_IncExt = value; RaisePropertyChanged("CF_Ext_Visible"); } } }
        public string CF_IncExtStr { get { return _CF_IncExtStr; } set { if (_CF_IncExtStr != value) { _CF_IncExtStr = value; } } }
        public bool CF_ExcText { get { return _CF_ExcText; } set { if (_CF_ExcText != value) { _CF_ExcText = value; RaisePropertyChanged("CF_Text_Visible"); } } }
        public string CF_ExcTextStr { get { return _CF_ExcTextStr; } set { if (_CF_ExcTextStr != value) { _CF_ExcTextStr = value; } } }
        public bool CF_Sub { get { return _CF_Sub; } set { if (_CF_Sub != value) { _CF_Sub = value; } } }
        public Visibility CF_Ext_Visible { get { return _CF_IncExt ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility CF_Text_Visible { get { return _CF_ExcText ? Visibility.Visible : Visibility.Collapsed; } }

        #endregion

        #endregion

        #region public methods
        public void SetStatusPane(String p_Value)
        {
            _StatusPane = p_Value;
            RaisePropertyChanged("StatusPane");
        }

        public FileManagerViewModel getVM()
        {
            return this;
        }

        public void RefreshVM()
        {
            foreach (System.Reflection.PropertyInfo p in this.GetType().GetProperties())
            {
                RaisePropertyChanged(p.Name);
            }
        }

        #region FileList

        public void AddTo_FL_FileList(List<string> p_List)
        {
            if(!FL_Add)
                _FL_FileList.Clear();

            foreach (var l in p_List)
            {
                _FL_FileList.Add(l);
            }
            RaisePropertyChanged("FL_FileList");
        }
        
        public void Clear_FL_FileList()
        {
            _FL_FileList.Clear();
            RaisePropertyChanged("FL_FileList");
        }


        #endregion

        #region Export Files

        public void AddTo_EF_Columns(List<string> p_List)
        {
            _EF_ColumnItems.Clear();
            foreach (var l in p_List)
            {
                _EF_ColumnItems.Add(l);
            }
            RaisePropertyChanged("EF_ColumnItems");
        }

        #endregion

        #endregion

    }



}

