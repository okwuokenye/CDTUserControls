using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CDTUserControl.Viewmodels
{
    class NavigationUserControlViewModel : ObservableObject
    {
        #region private variables
        ObservableCollection<String> _CurrentCharacters = new ObservableCollection<String>();
        String _CurrentCharacter;
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

        public delegate void HighlightButtonEventHandler();
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

        public delegate void GoToButtonEventHandler();
        public event GoToButtonEventHandler GoToButtonEvent;

        public delegate void GoTSavedButtonEventHandler();
        public event GoTSavedButtonEventHandler GoTSavedButtonEvent;

        public delegate void OffButtonEventHandler();
        public event OffButtonEventHandler OffButtonEvent;

        public delegate void RefreshButtonEventHandler();
        public event RefreshButtonEventHandler RefreshButtonEvent;

        public delegate void StartButtonEventHandler();
        public event StartButtonEventHandler StartButtonEvent;

        public delegate void PauseButtonEventHandler();
        public event PauseButtonEventHandler PauseButtonEvent;
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
        public void AddCurrentCharacter(String p_CurrentCharacter)
        {
            _CurrentCharacters.Add(p_CurrentCharacter);
            RaisePropertyChanged("CurrentCharacters");
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
            HighlightButtonEvent();
        }
        public ICommand Highlight { get { return new RelayCommand(HighlightExecute); } }

        private void GoToFirstExecute()
        {
            //GoToFirstCheckboxEvent();
        }
        public ICommand GoToFirst { get { return new RelayCommand(GoToFirstExecute); } }

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
            GoToButtonEvent();
        }
        public ICommand GoTo { get { return new RelayCommand(GoToExecute); } }

        private void GoTSavedExecute()
        {
            GoTSavedButtonEvent();
        }
        public ICommand GoTSaved { get { return new RelayCommand(GoTSavedExecute); } }

        private void OffExecute()
        {
            OffButtonEvent();
        }
        public ICommand Off { get { return new RelayCommand(OffExecute); } }

        private void RefreshExecute()
        {
            RefreshButtonEvent();
        }
        public ICommand Refresh { get { return new RelayCommand(RefreshExecute); } }

        private void StartExecute()
        {
            StartButtonEvent();
        }
        public ICommand Start { get { return new RelayCommand(StartExecute); } }

        private void PauseExecute()
        {
            PauseButtonEvent();
        }
        public ICommand Pause { get { return new RelayCommand(PauseExecute); } }

        #endregion
    }
}
