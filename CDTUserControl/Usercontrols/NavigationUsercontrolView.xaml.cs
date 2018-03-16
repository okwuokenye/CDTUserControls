using System;
using System.Collections.Generic;
using System.Data;
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

        public delegate void OffButtonEventHandler(Boolean p_Value);
        public event OffButtonEventHandler OffButtonEvent;

        public delegate void RefreshButtonEventHandler();
        public event RefreshButtonEventHandler RefreshButtonEvent;

        public delegate void StartButtonEventHandler();
        public event StartButtonEventHandler StartButtonEvent;

        public delegate void PauseButtonEventHandler();
        public event PauseButtonEventHandler PauseButtonEvent;

        public delegate void CurrentCharacterSelectedEventHandler(Int32 p_Index);
        public event CurrentCharacterSelectedEventHandler CurrentCharacterSelectedEvent;
        public delegate void Checkbox1CheckedEventHandler(Boolean p_Value);
        public event Checkbox1CheckedEventHandler Checkbox1CheckedEvent;

        public delegate void Checkbox2CheckedEventHandler(Boolean p_Value);
        public event Checkbox2CheckedEventHandler Checkbox2CheckedEvent;

        public delegate void Checkbox3CheckedEventHandler(Boolean p_Value);
        public event Checkbox3CheckedEventHandler Checkbox3CheckedEvent;

        public delegate void GotoFirstCheckboxEventHandler();
        public event GotoFirstCheckboxEventHandler GotoFirstCheckboxEvent;

        public delegate void ColorBoxClickEventHandler();
        public event ColorBoxClickEventHandler ColorBoxClickEvent;

        public delegate void MyTabItem1EventHandler();
        public event MyTabItem1EventHandler MyTabItem1Event;

        public delegate void MyTabItem2EventHandler();
        public event MyTabItem2EventHandler MyTabItem2Event;

        public delegate void MyTabItem3EventHandler();
        public event MyTabItem3EventHandler MyTabItem3Event;
        #endregion

        #region constructor
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

            vm.CurrentCharacterSelectedEvent += Vm_CurrentCharacterSelectedEvent;
            vm.Checkbox1CheckedEvent += Vm_Checkbox1CheckedEvent;
            vm.Checkbox2CheckedEvent += Vm_Checkbox2CheckedEvent;
            vm.Checkbox3CheckedEvent += Vm_Checkbox3CheckedEvent;
            vm.GotoFirstCheckboxEvent += Vm_GotoFirstCheckboxEvent;
            base.DataContext = vm;
        }
        #endregion

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

        private void Vm_OffButtonEvent(Boolean p_Value)
        {
            OffButtonEvent(p_Value);
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

        private void Vm_CurrentCharacterSelectedEvent(Int32 p_Index)
        {
            CurrentCharacterSelectedEvent(p_Index);
        }

        private void Vm_Checkbox1CheckedEvent(Boolean p_Value)
        {
            Checkbox1CheckedEvent(p_Value);
        }

        private void Vm_Checkbox2CheckedEvent(Boolean p_Value)
        {
            Checkbox2CheckedEvent(p_Value);
        }

        private void Vm_Checkbox3CheckedEvent(Boolean p_Value)
        {
            Checkbox3CheckedEvent(p_Value);
        }

        private void Vm_GotoFirstCheckboxEvent()
        {
            GotoFirstCheckboxEvent();
        }

        private void Btn_ColorBoxClickEvent(object sender, EventArgs args)
        {
            ColorBoxClickEvent();
        }

        void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var l_Tab = (TabControl)sender;
                if(l_Tab != null && l_Tab.SelectedContent != null)
                {
                    if (MyTabItem1.IsSelected)
                    {
                        if (MyTabItem1Event != null)
                            MyTabItem1Event();
                        else
                            MessageBox.Show("Event thrown for tab1");
                    }
                    if (MyTabItem2.IsSelected)
                    {
                        if (MyTabItem2Event != null)
                            MyTabItem2Event();
                        else
                            MessageBox.Show("Event thrown for tab2");
                    }
                    if (MyTabItem3.IsSelected)
                    {
                        if (MyTabItem3Event != null)
                            MyTabItem3Event();
                        else
                            MessageBox.Show("Event thrown for tab3");
                    }
                }
            }
        }
        #endregion

        #region public functions

        public string ReturnCharacter()
        {
            return vm.ReturnCharacter();
        }

        public void ChangeCharacter(String p_Value)
        {
            vm.ChangeCharacter(p_Value);
        }

        public void AddCurrentCharacter(List<String> p_CurrentCharacters)
        {
            vm.AddCurrentCharacters(p_CurrentCharacters);
        }

        public void ClearCurrentCharacters()
        {
            vm.ClearCurrentCharacters();
        }

        public void SetStatusPaneText(String p_Value)
        {
            vm.SetStatusPaneText(p_Value);
        }

        public void SetSaveRowText1(String p_Value)
        {
            vm.SetSaveRowText1(p_Value);
        }

        public void SetSaveRowText2(String p_Value)
        {
            vm.SetSaveRowText2(p_Value);
        }

        public void SetAnalysisTabName(String p_Value)
        {
            vm.SetAnalysisTabName(p_Value);
        }

        public void SetSessionLogDataGrid(DataTable p_Tbl)
        {
            SessionLogDataGrid.ItemsSource = p_Tbl.AsDataView();
        }

        public void SetAnalysisDataGrid(DataTable p_Tbl)
        {
            AnalysisDataGrid.ItemsSource = p_Tbl.AsDataView();
        }

        public void SetColorButtonColor(Brush p_Color)
        {
            ColorButton.Background = p_Color;
        }
        #endregion
    }
}
