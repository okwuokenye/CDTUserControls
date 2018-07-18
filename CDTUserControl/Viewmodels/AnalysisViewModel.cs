using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDTUserControl.Viewmodels
{
    public class AnalysisViewModel : ObservableObject
    {
        #region Events

        #endregion

        #region private variables

        ObservableCollection<string> _Sheets = new ObservableCollection<string>();
        string _Sheet;
        bool _AnalyzeMultipleSheets = false;
        bool _IsAll = true;
        bool _IsVisible = false;
        bool _IsSelected = false;
        string _Character = string.Empty;
        string _Text = string.Empty;
        bool _IsScene = false;
        string _Scene = string.Empty;
        ObservableCollection<string> _HeaderRows = new ObservableCollection<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
        string _HeaderRow;
        bool _IncludeLinesWithNoText = false;
        bool _IgnoreStrikethroughText = false;
        bool _IncludeLinesWithNoCharacter = false;
        bool _CloseUponCompletion = false;
        bool _AddToExistingSheet = false;
        ObservableCollection<string> _UListItems = new ObservableCollection<string>();
        string _UListItem;

        #endregion

        #region properties
        public ObservableCollection<string> Sheets { get { return _Sheets; } }
        public string Sheet
        {
            get { return _Sheet; }
            set
            {
                if (_Sheet != value)
                {
                    _Sheet = value;
                }
            }
        }
        public bool AnalyzeMultipleSheets
        {
            get { return _AnalyzeMultipleSheets; }
            set
            {
                if (_AnalyzeMultipleSheets != value)
                {
                    _AnalyzeMultipleSheets = value;
                }
            }
        }
        public bool IsAll
        {
            get { return _IsAll; }
            set
            {
                if (_IsAll != value)
                {
                    _IsAll = value;
                }
            }
        }
        public bool IsVisible
        {
            get { return _IsVisible; }
            set
            {
                if (_IsVisible != value)
                {
                    _IsVisible = value;
                }
            }
        }
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                }
            }
        }
        public string Character
        {
            get { return _Character; }
            set
            {
                if (_Character != value)
                {
                    _Character = value;
                }
            }
        }
        public string Text
        {
            get { return _Text; }
            set
            {
                if (_Text != value)
                {
                    _Text = value;
                }
            }
        }
        public bool IsScene
        {
            get { return _IsScene; }
            set
            {
                if (_IsScene != value)
                {
                    _IsScene = value;
                }
            }
        }
        public string Scene
        {
            get { return _Scene; }
            set
            {
                if (_Scene != value)
                {
                    _Scene = value;
                }
            }
        }
        public ObservableCollection<string> HeaderRows { get { return _HeaderRows; } }
        public string HeaderRow
        {
            get { return _HeaderRow; }
            set
            {
                if (_HeaderRow != value)
                {
                    _HeaderRow = value;
                }
            }
        }
        public bool IncludeLinesWithNoText
        {
            get { return _IncludeLinesWithNoText; }
            set
            {
                if (_IncludeLinesWithNoText != value)
                {
                    _IncludeLinesWithNoText = value;
                }
            }
        }
        public bool IgnoreStrikethroughText
        {
            get { return _IgnoreStrikethroughText; }
            set
            {
                if (_IgnoreStrikethroughText != value)
                {
                    _IgnoreStrikethroughText = value;
                }
            }
        }
        public bool IncludeLinesWithNoCharacter
        {
            get { return _IncludeLinesWithNoCharacter; }
            set
            {
                if (_IncludeLinesWithNoCharacter != value)
                {
                    _IncludeLinesWithNoCharacter = value;
                }
            }
        }
        public bool CloseUponCompletion
        {
            get { return _CloseUponCompletion; }
            set
            {
                if (_CloseUponCompletion != value)
                {
                    _CloseUponCompletion = value;
                }
            }
        }
        public bool AddToExistingSheet
        {
            get { return _AddToExistingSheet; }
            set
            {
                if (_AddToExistingSheet != value)
                {
                    _AddToExistingSheet = value;
                }
            }
        }
        public ObservableCollection<string> UListItems { get { return _UListItems; } }
        public string UListItem
        {
            get { return _UListItem; }
            set
            {
                if (_UListItem != value)
                {
                    _UListItem = value;
                }
            }
        }

        #endregion

        #region Constructor
        public AnalysisViewModel()
        {

        }
        #endregion

        #region Commands

        #endregion

        #region private methods

        #endregion

        #region public methods
        public void AddSheetToAnalyze(string p_ItemToAdd)
        {
            _Sheets.Add(p_ItemToAdd);
            RaisePropertyChanged("Sheets");
        }

        public void RemoveFromSheetToAnalyze(string p_ItemToRemove)
        {
            _Sheets.Remove(p_ItemToRemove);
            RaisePropertyChanged("Sheets");
        }

        public void SetCharacter(string p_Item)
        {
            _Character = p_Item;
            RaisePropertyChanged("Character");
        }

        public void SetText(string p_Item)
        {
            _Text = p_Item;
            RaisePropertyChanged("Text");
        }

        public void SetScene(string p_Item)
        {
            _Scene = p_Item;
            RaisePropertyChanged("Scene");
        }

        public void AddHeaderRowItem(string p_ItemToAdd)
        {
            _HeaderRows.Add(p_ItemToAdd);
            RaisePropertyChanged("HeaderRows");
        }

        public void RemoveFromHeaderRows(string p_ItemToRemove)
        {
            _HeaderRows.Remove(p_ItemToRemove);
            RaisePropertyChanged("HeaderRows");
        }


        public void AddUListItem(string p_ItemToAdd)
        {
            _UListItems.Add(p_ItemToAdd);
            RaisePropertyChanged("UListItems");
        }

        public void RemoveFromUListItem(string p_ItemToRemove)
        {
            _UListItems.Remove(p_ItemToRemove);
            RaisePropertyChanged("UListItems");
        }
        #endregion
    }
}
