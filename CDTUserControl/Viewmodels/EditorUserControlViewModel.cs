using System;
using System.IO;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CDTUserControl.Viewmodels
{
    public class EditorUserControlViewModel : ObservableObject
    {

        public delegate void RowEnterHitEventHandler();
        public event RowEnterHitEventHandler RowEnterHitEvent;

        public delegate void Filter_Main_SelectedEventHandler(string p_Value);
        public event Filter_Main_SelectedEventHandler Filter_Main_SelectedEvent;

        public delegate void Filter_Second_SelectedEventHandler(string p_Value);
        public event Filter_Second_SelectedEventHandler Filter_Second_SelectedEvent;

        public delegate void Filter_Second_OnEventHandler(bool p_Value);
        public event Filter_Second_OnEventHandler Filter_Second_OnEvent;

        public delegate void Filter_Main_OnEventHandler(bool p_Value);
        public event Filter_Main_OnEventHandler Filter_Main_OnEvent;
        #region Properties

        string _StatusPane;
        public string StatusPane { get { return _StatusPane; } set { if (_StatusPane != value) { _StatusPane = value; RaisePropertyChanged("StatusPane"); } } }

        string _Selected_Filter_Main;
        public string Selected_Filter_Main { get { return _Selected_Filter_Main; } set { if (_Selected_Filter_Main != value) { _Selected_Filter_Main = value; RaisePropertyChanged("Selected_Filter_Main"); Filter_Main_SelectedEvent(value); } } }
        
        string _Selected_Filter_Second;
        public string Selected_Filter_Second { get { return _Selected_Filter_Second; } set { if (_Selected_Filter_Second != value) { _Selected_Filter_Second = value; RaisePropertyChanged("Selected_Filter_Second"); Filter_Second_SelectedEvent(value); } } }

        string _SavedRow;
        public string SavedRow { get { return _SavedRow; } set { if (_SavedRow != value) { _SavedRow = value; RaisePropertyChanged("SavedRow"); } } }

        string _PreviousText;
        public string PreviousText { get { return _PreviousText; } set { if (_PreviousText != value) { _PreviousText = value; RaisePropertyChanged("PreviousText"); } } }

        string _CurrentText;
        public string CurrentText { get { return _CurrentText; } set { if (_CurrentText != value) { _CurrentText = value; RaisePropertyChanged("CurrentText"); } } }
        
        string _NextText;
        public string NextText { get { return _NextText; } set { if (_NextText != value) { _NextText = value; RaisePropertyChanged("NextText"); } } }

        string _FileName;
        public string FileName { get { return _FileName; } set { if (_FileName != value) { _FileName = value; RaisePropertyChanged("FileName"); } } }

        string _RowNo;
        public string RowNo { get { return _RowNo; } set { if (_RowNo != value) { _RowNo = value; RaisePropertyChanged("RowNo"); } } }

        string _Selected_File;
        public string Selected_File { get { return _Selected_File; } set { if (_Selected_File != value) { _Selected_File = value; RaisePropertyChanged("Selected_File"); } } }

        int _Selected_File_Index;
        public int Selected_File_Index { get { return _Selected_File_Index; } set { if (_Selected_File_Index != value) { _Selected_File_Index = value; RaisePropertyChanged("Selected_File_Index"); } } }

        int _Selected_Filter_Main_Index;
        public int Selected_Filter_Main_Index { get { return _Selected_Filter_Main_Index; } set { if (_Selected_Filter_Main_Index != value) { _Selected_Filter_Main_Index = value; RaisePropertyChanged("Selected_Filter_Main_Index"); } } }

        int _Selected_Filter_Second_Index;
        public int Selected_Filter_Second_Index { get { return _Selected_Filter_Second_Index; } set { if (_Selected_Filter_Second_Index != value) { _Selected_Filter_Second_Index = value; RaisePropertyChanged("Selected_Filter_Second_Index"); } } }


        ObservableCollection<string> _Filter_Main = new ObservableCollection<string>();
        public ObservableCollection<string> Filter_Main { get { return _Filter_Main; } }
        
        ObservableCollection<string> _Filter_Second = new ObservableCollection<string>();
        public ObservableCollection<string> Filter_Second { get { return _Filter_Second; } }

        ObservableCollection<string> _FileList = new ObservableCollection<string>();
        public ObservableCollection<string> FileList { get { return _FileList; } }

        bool _Filter_Second_On = false;
        public bool Filter_Second_On { get { return _Filter_Second_On; } set { if (_Filter_Second_On != value) { _Filter_Second_On = value; RaisePropertyChanged("Filter_Second_On"); Filter_Second_OnEvent(value); } } }

        bool _Filter_Main_On = false;
        public bool Filter_Main_On { get { return _Filter_Main_On; } set { if (_Filter_Main_On != value) { _Filter_Main_On = value; RaisePropertyChanged("Filter_Main_On"); Filter_Main_OnEvent(value); } } }

        bool _ButtonsEnabled = true;
        public bool ButtonsEnabled { get { return _ButtonsEnabled; } set { if (_ButtonsEnabled != value) { _ButtonsEnabled = value; RaisePropertyChanged("ButtonsEnabled"); } } }

        bool _Second_Filter_Exists = false;
        public bool Second_Filter_Exists { get { return _Second_Filter_Exists; } set { if (_Second_Filter_Exists != value) { _Second_Filter_Exists = value; RaisePropertyChanged("Second_Filter_Exists"); RaisePropertyChanged("Filter_Second_Visibility"); } } }

        public Visibility Filter_Second_Visibility { get { return _Second_Filter_Exists ? Visibility.Visible : Visibility.Collapsed; } }

        int _FontSize = 10;
        public int FontSize { get { return _FontSize; } set { if (_FontSize != value) { _FontSize = value; RaisePropertyChanged("FontSize"); } } }
        
        int _LargeFontSize = 11;
        public int LargeFontSize { get { return _LargeFontSize; } set { if (_LargeFontSize != value) { _LargeFontSize = value; RaisePropertyChanged("LargeFontSize"); } } }

        #endregion

        #region Constructors

        public EditorUserControlViewModel()
        {

        }

        private void RowEnterHitExecute()
        {
            RowEnterHitEvent();
        }
        public ICommand RowEnterHit { get { return new RelayCommand(RowEnterHitExecute); } }

        #endregion

        #region Public Methods

        public EditorUserControlViewModel getVM()
        {
            return this;
        }

        public void SetStatusPane(string p_Value)
        {
            _StatusPane = p_Value;
        }

        public void SetFileName(string p_Value)
        {
            _FileName = p_Value;
        }

        public void SetRowNo(string p_Value)
        {
            _RowNo = p_Value;
        }

        public void RefreshVM()
        {
            foreach (System.Reflection.PropertyInfo p in this.GetType().GetProperties())
            {
                RaisePropertyChanged(p.Name);
            }
        }

        public void AddTo_Filter_Main(List<string> p_List)
        {
            _Filter_Main.Clear();
            foreach (var l in p_List)
            {
                _Filter_Main.Add(l);
            }
            RaisePropertyChanged("Filter_Main");
        }

        public void Change_Filter_Main_Index(string p_Value)
        {
            Selected_Filter_Main_Index = Filter_Main.IndexOf(p_Value);            
        }


        public void Clear_Filter_Main()
        {
            _Filter_Main.Clear();
            RaisePropertyChanged("Filter_Main");
        }
        public void AddTo_Filter_Second(List<string> p_List)
        {
            _Filter_Second.Clear();
            foreach (var l in p_List)
            {
                _Filter_Second.Add(l);
            }
            RaisePropertyChanged("Filter_Second");
        }

        public void Change_Filter_Second_Index(string p_Value)
        {
            Selected_Filter_Second_Index = Filter_Second.IndexOf(p_Value);
        }

        public void Clear_Filter_Second()
        {
            _Filter_Second.Clear();
            RaisePropertyChanged("Filter_Second");
        }
        
        public void AddTo_FileList(List<string> p_List)
        {
            _FileList.Clear();
            foreach (var l in p_List)
            {
                _FileList.Add(l);
            }
            RaisePropertyChanged("FileList");
        }

        public void Clear_FileList()
        {
            _FileList.Clear();
            RaisePropertyChanged("FileList");
        }

        #endregion


    }
}
