using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CDTUserControl.Viewmodels
{
    class NavigationUserControlViewModel : ObservableObject
    {
        #region private variables
        ObservableCollection<String> _CurrentCharacters = new ObservableCollection<String>();
        String _CurrentCharacter;
        String _StatusPane = "";
        Boolean _IsCheckBox1Checked = false;
        Boolean _IsCheckBox2Checked = false;
        Boolean _IsCheckBox3Checked = false;
        Boolean _IsGoToFirst = true;
        ObservableCollection<String> _ClearColourComboItems = new ObservableCollection<String>{"All columns", "Selected columns", "Text column only" };
        Int32 _ClearColourComboItemIndex = 2;
        String _SaveRowText1 = String.Empty;
        String _SaveRowText2 = String.Empty;
        String _Actor = "";

        Boolean _AnalysisOn = false;
        String _AnalysisTabName = "";
        Color? _HighlightColor;
        Color? _FilterColor;
        Brush _FilterBrush;
        Boolean _StartOn = false;
        Boolean _PauseOn = false;

        #endregion

        #region event declarations
        public delegate void NextButtonEventHandler();
        public event NextButtonEventHandler NextButtonEvent;

        public delegate void PreviousButtonEventHandler();
        public event PreviousButtonEventHandler PreviousButtonEvent;

        public delegate void FirstlineButtonEventHandler();
        public event FirstlineButtonEventHandler FirstlineButtonEvent;

        public delegate void LastlineButtonEventHandler();
        public event LastlineButtonEventHandler LastlineButtonEvent;

        public delegate void ReadingFontButtonEventHandler();
        public event ReadingFontButtonEventHandler ReadingFontButtonEvent;

        public delegate void HighlightButtonEventHandler(Boolean p_Value);
        public event HighlightButtonEventHandler HighlightButtonEvent;

        public delegate void DeleteFontButtonEventHandler();
        public event DeleteFontButtonEventHandler DeleteFontButtonEvent;

        public delegate void ClearColourButtonEventHandler();
        public event ClearColourButtonEventHandler ClearColourButtonEvent;

        public delegate void PlusButtonEventHandler();
        public event PlusButtonEventHandler PlusButtonEvent;

        public delegate void MinusButtonEventHandler();
        public event MinusButtonEventHandler MinusButtonEvent;

        public delegate void SelectedRangeReadingFontButtonEventHandler();
        public event SelectedRangeReadingFontButtonEventHandler SelectedRangeReadingFontButtonEvent;

        public delegate void SelectedRangeMinusButtonEventHandler();
        public event SelectedRangeMinusButtonEventHandler SelectedRangeMinusButtonEvent;

        public delegate void SelectedRangePlusButtonEventHandler();
        public event SelectedRangePlusButtonEventHandler SelectedRangePlusButtonEvent;

        public delegate void SelectedRangeClearColourButtonEventHandler();
        public event SelectedRangeClearColourButtonEventHandler SelectedRangeClearColourButtonEvent;

        public delegate void SaveRowButtonEventHandler();
        public event SaveRowButtonEventHandler SaveRowButtonEvent;

        public delegate void GoToButtonEventHandler(String p_Value);
        public event GoToButtonEventHandler GoToButtonEvent;

        public delegate void GoTSavedButtonEventHandler();
        public event GoTSavedButtonEventHandler GoTSavedButtonEvent;

        public delegate void OffButtonEventHandler(Boolean p_Value);
        public event OffButtonEventHandler OffButtonEvent;

        public delegate void RefreshButtonEventHandler();
        public event RefreshButtonEventHandler RefreshButtonEvent;

        public delegate void StartButtonEventHandler(Boolean p_Value);
        public event StartButtonEventHandler StartButtonEvent;

        public delegate void OpenLogButtonEventHandler();
        public event OpenLogButtonEventHandler OpenLogButtonEvent;

        public delegate void FilterColourChangedEventHandler();
        public event FilterColourChangedEventHandler FilterColourChangedEvent;

        public delegate void ActorChangedEventHandler(String p_Value);
        public event ActorChangedEventHandler ActorChangedEvent;

        public delegate void PauseButtonEventHandler(Boolean p_Value);
        public event PauseButtonEventHandler PauseButtonEvent;

        public delegate void CurrentCharacterSelectedEventHandler(Int32 p_Index);
        public event CurrentCharacterSelectedEventHandler CurrentCharacterSelectedEvent;

        public delegate void Checkbox1CheckedEventHandler(Boolean p_Value);
        public event Checkbox1CheckedEventHandler Checkbox1CheckedEvent;

        public delegate void Checkbox2CheckedEventHandler(Boolean p_Value);
        public event Checkbox2CheckedEventHandler Checkbox2CheckedEvent;

        public delegate void Checkbox3CheckedEventHandler(Boolean p_Value);
        public event Checkbox3CheckedEventHandler Checkbox3CheckedEvent;

        public delegate void GotoFirstCheckboxEventHandler(Boolean p_Value);
        public event GotoFirstCheckboxEventHandler GotoFirstCheckboxEvent;
        
        public delegate void HighlightColorEventHandler(Color? p_Value);
        public event HighlightColorEventHandler HighlightColorEvent;
        
        public delegate void ClearColourComboIndexEventHandler(Int32 p_Index);
        public event ClearColourComboIndexEventHandler ClearColourComboIndexEvent;

        #endregion

        #region properties
        public ObservableCollection<String> CurrentCharacters { get { return _CurrentCharacters; } }
        public String CurrentCharacter
        {
            get
            {
                return _CurrentCharacter;
            }
            set
            {
                if (_CurrentCharacter != value)
                {
                    _CurrentCharacter = value;
                    CurrentCharacterSelectedEvent(_CurrentCharacters.IndexOf(value));
                }
            }
        }
        public String StatusPane { get { return _StatusPane; } }
        
        public Boolean IsCheckBox1Checked
        {
            get { return _IsCheckBox1Checked; }
            set
            {
                if (_IsCheckBox1Checked != value)
                {
                    _IsCheckBox1Checked = value;
                    Checkbox1CheckedEvent(value);
                }
            }
        }

        public Boolean IsCheckBox2Checked
        {
            get { return _IsCheckBox2Checked; }
            set
            {
                if (_IsCheckBox2Checked != value)
                {
                    _IsCheckBox2Checked = value;
                    Checkbox2CheckedEvent(value);
                }
            }
        }
        public Boolean IsCheckBox3Checked
        {
            get { return _IsCheckBox3Checked; }
            set
            {
                if (_IsCheckBox3Checked != value)
                {
                    _IsCheckBox3Checked = value;
                    Checkbox3CheckedEvent(value);
                }
            }
        }
        public Boolean IsGoToFirst
        {
            get { return _IsGoToFirst; }
            set
            {
                if (_IsGoToFirst = value)
                {
                    _IsGoToFirst = value;
                    GotoFirstCheckboxEvent(value);
                }
            }
        }
        public ObservableCollection<String> ClearColourComboItems { get { return _ClearColourComboItems; } }
        public Int32 ClearColourComboItemIndex { get { return _ClearColourComboItemIndex; }
            set
            {
                if (_ClearColourComboItemIndex != value)
                {
                    _ClearColourComboItemIndex = value;
                    ClearColourComboIndexEvent(value);
                }
            }
        }
        public String SaveRowText1
        {
            get
            {
                return _SaveRowText1;
            }
            set
            {
                if (_SaveRowText1 != value)
                {
                    _SaveRowText1 = value;
                }
            }
        }
        public String SaveRowText2
        {
            get
            {
                return _SaveRowText2;
            }
            set
            {
                if (_SaveRowText2 != value)
                {
                    _SaveRowText2 = value;
                }
            }
        }

        public String Actor
        {
            get
            {
                return _Actor;
            }
            set
            {
                if (_Actor != value)
                {
                    _Actor = value;
                }
            }
        }

        public Boolean AnalysisOn
        {
            get { return _AnalysisOn; }
            set
            {
                if (_AnalysisOn != value)
                {
                    _AnalysisOn = value;
                }
            }
        }

        public Boolean StartOn
        {
            get { return _StartOn; }
            set
            {
                if (_StartOn != value)
                {
                    _StartOn = value;
                    RaisePropertyChanged("StartOn");
                }
            }
        }
        
        public Boolean PauseOn
        {
            get { return _PauseOn; }
            set
            {
                if (_PauseOn != value)
                {
                    _PauseOn = value;
                }
            }
        }

        public String AnalysisTabName
        {
            get
            {
                return _AnalysisTabName;
            }
            set
            {
                if (_AnalysisTabName != value)
                {
                    _AnalysisTabName = value;
                    RaisePropertyChanged("AnalysisTabName");
                }
            }
        }

        public String AnalysisText { get { return _AnalysisOn ? "Off" : "On"; } }

        public String StartText { get { return _StartOn ? "Stop" : "Start"; } }
        public String PauseText { get { return _PauseOn ? "Unpause" : "Pause"; } }
        
        public Visibility PauseVisibility { get { return _StartOn ? Visibility.Visible : Visibility.Collapsed; } }

        public Color? HighlightColor
        {
            get { return _HighlightColor; }
            set
            {
                if (_HighlightColor != value)
                {
                    _HighlightColor = value;
                    HighlightColorEvent(value);
                }
            }
        }

        public Color? FilterColor
        {
            get { return _FilterColor; }
            set
            {
                if (_FilterColor != value)
                {
                    _FilterColor = value;
                    RaisePropertyChanged("FilterColor");
                    System.Windows.Media.Color cl = (System.Windows.Media.Color)value;
                    FilterBrush = new SolidColorBrush(cl);
                }
            }
        }
        public Brush FilterBrush
        {
            get { return _FilterBrush; }
            set
            {
                if (_FilterBrush != value)
                {
                    _FilterBrush = value;
                    RaisePropertyChanged("FilterBrush");
                }
            }
        }
        #endregion

        #region constructor
        public NavigationUserControlViewModel()
        {

        }
        #endregion

        #region private methods

        #endregion

        #region public methods

        public string ReturnCharacter()
        {
            return CurrentCharacter;
        }

        public void ChangeCharacter(String p_Value)
        {
            CurrentCharacter = p_Value;
            RaisePropertyChanged("CurrentCharacter");
        }

        public void AddCurrentCharacters(List<String> p_CurrentCharacters)
        {
            _CurrentCharacters.Clear();
            foreach (var l_CurrentCharacter in p_CurrentCharacters)
            {
                _CurrentCharacters.Add(l_CurrentCharacter);
            }
            RaisePropertyChanged("CurrentCharacters");
        }

        public void ClearCurrentCharacters()
        {
            _CurrentCharacters.Clear();
            RaisePropertyChanged("CurrentCharacters");
        }

        public void SetStatusPaneText(String p_Value)
        {
            _StatusPane = p_Value;
            RaisePropertyChanged("StatusPane");
        }

        public void SetSaveRowText1(String p_Value)
        {
            _SaveRowText1 = p_Value;
            RaisePropertyChanged("SaveRowText1");
        }

        public void SetSaveRowText2(String p_Value)
        {
            _SaveRowText2 = p_Value;
            RaisePropertyChanged("SaveRowText2");
        }

        public void SetAnalysisTabName(String p_Value)
        {
            _AnalysisTabName = p_Value;
            RaisePropertyChanged("AnalysisTabName");
        }

        public void SetFilterColor(Color? p_Value)
        {
            FilterColor = p_Value;
            RaisePropertyChanged("FilterColor");
        }


        public void SetHighlightColor(Color? p_Value)
        {
            HighlightColor = p_Value;
            RaisePropertyChanged("HighlightColor");
        }

        #endregion

        #region commands
        private void NextExecute()
        {
            NextButtonEvent();
        }
        public ICommand Next { get { return new RelayCommand(NextExecute); } }

        private void PreviousExecute()
        {
            PreviousButtonEvent();
        }
        public ICommand Previous { get { return new RelayCommand(PreviousExecute); } }

        private void FirstLineExecute()
        {
            FirstlineButtonEvent();
        }
        public ICommand FirstLine { get { return new RelayCommand(FirstLineExecute); } }

        private void LastLineExecute()
        {
            LastlineButtonEvent();
        }
        public ICommand LastLine { get { return new RelayCommand(LastLineExecute); } }

        private void ReadingFontExecute()
        {
            ReadingFontButtonEvent();
        }
        public ICommand ReadingFont { get { return new RelayCommand(ReadingFontExecute); } }

        private void HighlightExecute()
        {
            HighlightButtonEvent(IsGoToFirst);
        }
        public ICommand Highlight { get { return new RelayCommand(HighlightExecute); } }
        
        private void DeleteFontExecute()
        {
            DeleteFontButtonEvent();
        }
        public ICommand DeleteFont { get { return new RelayCommand(DeleteFontExecute); } }

        private void ClearColourExecute()
        {
            ClearColourButtonEvent();
        }
        public ICommand ClearColour { get { return new RelayCommand(ClearColourExecute); } }

        private void MinusExecute()
        {
            MinusButtonEvent();
        }
        public ICommand Minus { get { return new RelayCommand(MinusExecute); } }

        private void PlusExecute()
        {
            PlusButtonEvent();
        }
        public ICommand Plus { get { return new RelayCommand(PlusExecute); } }

        private void SelectedRangeReadingFontExecute()
        {
            SelectedRangeReadingFontButtonEvent();
        }
        public ICommand SelectedRangeReadingFont { get { return new RelayCommand(SelectedRangeReadingFontExecute); } }

        private void SelectedRangeMinusExecute()
        {
            SelectedRangeMinusButtonEvent();
        }
        public ICommand SelectedRangeMinus { get { return new RelayCommand(SelectedRangeMinusExecute); } }

        private void SelectedRangePlusExecute()
        {
            SelectedRangePlusButtonEvent();
        }
        public ICommand SelectedRangePlus { get { return new RelayCommand(SelectedRangePlusExecute); } }

        private void SelectedRangeClearColourExecute()
        {
            SelectedRangeClearColourButtonEvent();
        }
        public ICommand SelectedRangeClearColour { get { return new RelayCommand(SelectedRangeClearColourExecute); } }

        private void SaveRowExecute()
        {
            SaveRowButtonEvent();
        }
        public ICommand SaveRow { get { return new RelayCommand(SaveRowExecute); } }

        private void GoToExecute()
        {
            GoToButtonEvent(SaveRowText2);
        }
        public ICommand GoTo { get { return new RelayCommand(GoToExecute); } }

        private void GoTSavedExecute()
        {
            GoTSavedButtonEvent();
        }
        public ICommand GoTSaved { get { return new RelayCommand(GoTSavedExecute); } }

        private void OffExecute()
        {
            _AnalysisOn = _AnalysisOn ? false : true;
            OffButtonEvent(_AnalysisOn);
            RaisePropertyChanged("AnalysisOn");
        }
        public ICommand Off { get { return new RelayCommand(OffExecute); } }

        private void RefreshExecute()
        {
            RefreshButtonEvent();
        }
        public ICommand Refresh { get { return new RelayCommand(RefreshExecute); } }

        private void StartExecute()
        {
            _StartOn = _StartOn ? false : true;
            StartButtonEvent(StartOn);
            RaisePropertyChanged("PauseVisibility");
            RaisePropertyChanged("StartText");
        }
        public ICommand Start { get { return new RelayCommand(StartExecute); } }
        
        private void ActorChangedExecute()
        {
            ActorChangedEvent(Actor);
        }
        public ICommand ActorChanged { get { return new RelayCommand(ActorChangedExecute); } }

        private void OpenLogExecute()
        {
            OpenLogButtonEvent();
        }
        public ICommand OpenLog { get { return new RelayCommand(OpenLogExecute); } }

        private void PauseExecute()
        {
            _PauseOn = _PauseOn ? false : true;
            PauseButtonEvent(PauseOn);
            RaisePropertyChanged("PauseText");
        }
        public ICommand Pause { get { return new RelayCommand(PauseExecute); } }
        
        private void FilterColourChangedExecute()
        {
            FilterColourChangedEvent();
        }
        public ICommand FilterColourChanged { get { return new RelayCommand(FilterColourChangedExecute); } }

        #endregion
    }
}
