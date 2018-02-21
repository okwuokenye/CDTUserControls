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
using CDTUserControl.Viewmodels;

namespace CDTUserControl.Usercontrols
{
    /// <summary>
    /// Interaction logic for NavigationUsercontrolView.xaml
    /// </summary>
    public partial class NavigationUsercontrolView : UserControl
    {
        NavigationUserControlViewModel vm;

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

        public NavigationUsercontrolView()
        {
            InitializeComponent();
            vm = new NavigationUserControlViewModel();

            //add event listeners
            vm.NextButtonEvent += Vm_NextButtonEvent;
            vm.PreviousButtonEvent += Vm_PreviousButtonEvent;
            vm.FirstlineButtonEvent += Vm_FirstlineButtonEvent;
            vm.LastlineButtonEvent += Vm_LastlineButtonEvent;
            vm.ReadingFontButtonEvent += Vm_ReadingFontButtonEvent;
            vm.HighlightButtonEvent += Vm_HighlightButtonEvent;
            vm.DeleteFontButtonEvent += Vm_DeleteFontButtonEvent;
            vm.ClearColourButtonEvent += Vm_ClearColourButtonEvent;
            vm.MinusButtonEvent += Vm_MinusButtonEvent;
            vm.PlusButtonEvent += Vm_PlusButtonEvent;
            vm.SelectedRangeReadingFontButtonEvent += Vm_SelectedRangeReadingFontButtonEvent;
            vm.SelectedRangeMinusButtonEvent += Vm_SelectedRangeMinusButtonEvent;
            vm.SelectedRangePlusButtonEvent += Vm_SelectedRangePlusButtonEvent;
            vm.SelectedRangeClearColourButtonEvent += Vm_SelectedRangeClearColourButtonEvent;
            vm.SaveRowButtonEvent += Vm_SaveRowButtonEvent;
            vm.GoToButtonEvent += Vm_GoToButtonEvent;
            vm.GoTSavedButtonEvent += Vm_GoTSavedButtonEvent;
            vm.OffButtonEvent += Vm_OffButtonEvent;
            vm.RefreshButtonEvent += Vm_RefreshButtonEvent;
            vm.PauseButtonEvent += Vm_PauseButtonEvent;
            vm.StartButtonEvent += Vm_StartButtonEvent;

            base.DataContext = vm;
        }

        #region event handlers
        private void Vm_StartButtonEvent()
        {
            StartButtonEvent();
        }

        private void Vm_PauseButtonEvent()
        {
            PauseButtonEvent();
        }

        private void Vm_RefreshButtonEvent()
        {
            RefreshButtonEvent();
        }

        private void Vm_OffButtonEvent()
        {
            OffButtonEvent();
        }

        private void Vm_GoTSavedButtonEvent()
        {
            GoTSavedButtonEvent();
        }

        private void Vm_GoToButtonEvent()
        {
            GoToButtonEvent();
        }

        private void Vm_SaveRowButtonEvent()
        {
            SaveRowButtonEvent();
        }

        private void Vm_SelectedRangeClearColourButtonEvent()
        {
            SelectedRangeClearColourButtonEvent();
        }

        private void Vm_SelectedRangePlusButtonEvent()
        {
            SelectedRangePlusButtonEvent();
        }

        private void Vm_SelectedRangeMinusButtonEvent()
        {
            SelectedRangeMinusButtonEvent();
        }

        private void Vm_SelectedRangeReadingFontButtonEvent()
        {
            SelectedRangeReadingFontButtonEvent();
        }

        private void Vm_PlusButtonEvent()
        {
            PlusButtonEvent();
        }

        private void Vm_MinusButtonEvent()
        {
            MinusButtonEvent();
        }

        private void Vm_ClearColourButtonEvent()
        {
            ClearColourButtonEvent();
        }

        private void Vm_DeleteFontButtonEvent()
        {
            ClearColourButtonEvent();
        }

        private void Vm_HighlightButtonEvent()
        {
            HighlightButtonEvent();
        }

        private void Vm_ReadingFontButtonEvent()
        {
            ReadingFontButtonEvent();
        }

        private void Vm_LastlineButtonEvent()
        {
            LastlineButtonEvent();
        }

        private void Vm_FirstlineButtonEvent()
        {
            FirstlineButtonEvent();
        }

        private void Vm_PreviousButtonEvent()
        {
            PreviousButtonEvent();
        }

        private void Vm_NextButtonEvent()
        {
            NextButtonEvent();
        }
        #endregion

        #region public functions
        public void AddCurrentCharacter(String p_CurrentCharacter)
        {
            vm.AddCurrentCharacter(p_CurrentCharacter);
        }
        #endregion
    }
}
