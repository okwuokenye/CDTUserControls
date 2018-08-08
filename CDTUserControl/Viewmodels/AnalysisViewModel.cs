﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CDTUserControl.Viewmodels
{
    public class AnalysisViewModel : ObservableObject
    {
        #region Events

        public delegate void ActiveSheetChangeEventHandler(string p_Value);
        public event ActiveSheetChangeEventHandler ActiveSheetChangeEvent;

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

        string _CharacterTxt = string.Empty;
        string _TextTxt = string.Empty;
        string _SceneTxt = string.Empty;
        
        ObservableCollection<String> _HeadRowItems = new ObservableCollection<String> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
        string _HeaderRow;
        bool _IncludeLinesWithNoText = false;
        bool _IgnoreStrikethroughText = false;
        bool _IncludeLinesWithNoCharacter = false;
        bool _CloseUponCompletion = true;
        bool _AddToExistingSheet = false;
        bool _SheetsExist = false;
        ObservableCollection<string> _UListItems = new ObservableCollection<string>();
        string _UListItem;
        string _StatusPane;
        int _HeadRowIndex;
        int _ExistingSheetsIndex;
        int _SheetsIndex;
        int _MultiAnalysisInt = 0;
        #endregion

        #region properties

        public String StatusPane { get { return _StatusPane; } }
        
        public ObservableCollection<string> Sheets { get { return _Sheets; } }

        public string Sheet
        {
            get { return _Sheet; }
            set
            {
                if (_Sheet != value)
                {
                    _Sheet = value;
                    ActiveSheetChangeEvent(Sheet);
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
                RaisePropertyChanged("AnalyzeRadioButtonsVisibility");
                RaisePropertyChanged("NotAnalyzeRadioButtonsVisibility");
            }
        }
        public Visibility AnalyzeRadioButtonsVisibility { get { return _AnalyzeMultipleSheets ? Visibility.Visible : Visibility.Hidden; } }
        public Visibility NotAnalyzeRadioButtonsVisibility { get { return !_AnalyzeMultipleSheets ? Visibility.Visible : Visibility.Hidden; } }

        public Visibility SceneVisibility { get { return _IsScene ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility AddtoExistingVisibility { get { return _AddToExistingSheet ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility ExistingVisibility { get { return _SheetsExist ? Visibility.Visible : Visibility.Collapsed; } }

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
                    RaisePropertyChanged("SceneVisibility");
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

        public string CharacterTxt
        {
            get { return _CharacterTxt; }
            set
            {
                if (_CharacterTxt != value)
                {
                    _CharacterTxt = value;
                }
            }
        }

        public string TextTxt
        {
            get { return _TextTxt; }
            set
            {
                if (_TextTxt != value)
                {
                    _TextTxt = value;
                }
            }
        }
        
        public string SceneTxt
        {
            get { return _SceneTxt; }
            set
            {
                if (_SceneTxt != value)
                {
                    _SceneTxt = value;
                }
            }
        }
        
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
                    RaisePropertyChanged("AddtoExistingVisibility");
                }
            }
        }

        public bool SheetsExist
        {
            get { return _SheetsExist; }
            set
            {
                if (_SheetsExist != value)
                {
                    _SheetsExist = value;
                    RaisePropertyChanged("ExistingVisibility");
                    if(!value)
                    {
                        AddToExistingSheet = false;
                    }
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
        
        public int HeadRowIndex
        {
            get
            {
                return _HeadRowIndex;
            }
            set
            {
                if (_HeadRowIndex != value)
                {
                    _HeadRowIndex = value;
                    RaisePropertyChanged("HeadRowIndex");
                }
            }
        }

        public ObservableCollection<string> HeadRowItems
        {
            get
            {
                return _HeadRowItems;
            }
            set
            {
                if (_HeadRowItems != value)
                {
                    _HeadRowItems = value;
                    RaisePropertyChanged("HeadRowItems");
                }
            }
        }

        public int SheetsIndex
        {
            get
            {
                return _SheetsIndex;
            }
            set
            {
                if (_SheetsIndex != value)
                {
                    _SheetsIndex = value;
                    RaisePropertyChanged("SheetsIndex");
                    RaisePropertyChanged("Sheet");
                }
            }
        }
        public int ExistingSheetsIndex
        {
            get
            {
                return _ExistingSheetsIndex;
            }
            set
            {
                if (_ExistingSheetsIndex != value)
                {
                    _ExistingSheetsIndex = value;
                    RaisePropertyChanged("ExistingSheetsIndex");
                }
            }
        }
        
        public int MultiAnalysisInt
        {
            get
            {
                return _MultiAnalysisInt;
            }
            set
            {
                if (_MultiAnalysisInt != value)
                {
                    _MultiAnalysisInt = value;
                    RaisePropertyChanged("MultiAnalysisInt");
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

        public void SetCharacterTxt(string p_Item)
        {
            _CharacterTxt = p_Item;
            RaisePropertyChanged("CharacterTxt");
        }

        public void SetTextTxt(string p_Item)
        {
            _TextTxt = p_Item;
            RaisePropertyChanged("TextTxt");
        }

        public void SetSceneTxt(string p_Item)
        {
            _SceneTxt = p_Item;
            RaisePropertyChanged("SceneTxt");
        }

        public void SetSheetsExist(bool p_Value)
        {
            _SheetsExist = p_Value;
            RaisePropertyChanged("SheetsExist");
        }

        public void SetHeadRowIndex(int p_Value)
        {
            _HeadRowIndex = p_Value;
            RaisePropertyChanged("HeadRowIndex");
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

        public void AddSheetsList(List<String> p_Sheets)
        {
            _Sheets.Clear();
            foreach (var l_Sheets in p_Sheets)
            {
                _Sheets.Add(l_Sheets);
            }
            RaisePropertyChanged("Sheets");
        }

        public void AddExistingSheetsList(List<String> p_Sheets)
        {
            _UListItems.Clear();
            if(p_Sheets.Count>0)
            {
                SheetsExist = true;
                foreach (var l_Sheets in p_Sheets)
            {
                _UListItems.Add(l_Sheets);
            }
            }
            else
            {
                SheetsExist = false;
            }
            
            RaisePropertyChanged("UListItems");
        }

        public void SetExistingSheetsIndex(int p_Value)
        {
            if(UListItems.Count>0)
            {
            _ExistingSheetsIndex = p_Value;
            RaisePropertyChanged("ExistingSheetsIndex");
            }            
        }

        public void SetSheetsIndex(int p_Value)
        {
            if(Sheets.Count>0)
            {
            _SheetsIndex = p_Value;
            RaisePropertyChanged("SheetsIndex");
            }            
        }

        public void SetStatusPane(String p_Value)
        {
            _StatusPane = p_Value;
            RaisePropertyChanged("StatusPane");
        }

        public void SetHeaderIndex(int p_Value)
        {
            _HeadRowIndex = p_Value;
            RaisePropertyChanged("HeadRowIndex");
        }
        
        public int GetMultiAnalysis()
        {
            if(!AnalyzeMultipleSheets)
            {
                MultiAnalysisInt = 0;
            }
            else if(IsSelected)
            {
                MultiAnalysisInt = 1;
            }
            else if (IsVisible)
            {
                MultiAnalysisInt = 2;
            }
            else if (IsAll)
            {
                MultiAnalysisInt = 3;
            }
            return MultiAnalysisInt;
        }

        #endregion

        #region send methods

        public string SendCharacter()
        {
            return Character;
        }
        public string SendText()
        {
            return Text;
        }
        public string SendScene()
        {
            return Scene;
        }
        public bool SendIsScene()
        {
            return IsScene;
        }
        public int SendHeadRow()
        {
            return HeadRowIndex + 1;
        }

        public bool SendIncludeLinesWithNoText()
        {
            return IncludeLinesWithNoText;
        }
        public bool SendIgnoreStrikethroughText()
        {
            return IgnoreStrikethroughText;
        }
        public bool SendIncludeLinesWithNoCharacter()
        {
            return IncludeLinesWithNoCharacter;
        }
        public bool SendCloseUponCompletion()
        {
            return CloseUponCompletion;
        }
        public bool SendAddToExistingSheet()
        {
            return AddToExistingSheet;
        }
        public string SendExistingSheet()
        {
            return UListItem;
        }


        #endregion
    }
}
