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

        public delegate void PauseButtonEventHandler(Boolean p_Value);
        public event PauseButtonEventHandler PauseButtonEvent;

        public delegate void OpenLogButtonEventHandler();
        public event OpenLogButtonEventHandler OpenLogButtonEvent;
        
        public delegate void FilterColourChangedEventHandler();
        public event FilterColourChangedEventHandler FilterColourChangedEvent;

        public delegate void ActorChangedEventHandler(String p_Value);
        public event ActorChangedEventHandler ActorChangedEvent;

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
        
        public delegate void MyTabItem1EventHandler();
        public event MyTabItem1EventHandler MyTabItem1Event;

        public delegate void MyTabItem2EventHandler();
        public event MyTabItem2EventHandler MyTabItem2Event;

        public delegate void MyTabItem3EventHandler();
        public event MyTabItem3EventHandler MyTabItem3Event;

        public delegate void HighlightColorEventHandler(Color? p_Value);
        public event HighlightColorEventHandler HighlightColorEvent;
        
        public delegate void ClearColourComboIndexEventHandler(Int32 p_Index);
        public event ClearColourComboIndexEventHandler ClearColourComboIndexEvent;

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
            vm.OpenLogButtonEvent += Vm_OpenLogButtonEvent;

            vm.ActorChangedEvent += Vm_ActorChangedEvent;
            vm.FilterColourChangedEvent += Vm_FilterColourChangedEvent;

            vm.CurrentCharacterSelectedEvent += Vm_CurrentCharacterSelectedEvent;
            vm.Checkbox1CheckedEvent += Vm_Checkbox1CheckedEvent;
            vm.Checkbox2CheckedEvent += Vm_Checkbox2CheckedEvent;
            vm.Checkbox3CheckedEvent += Vm_Checkbox3CheckedEvent;
            vm.GotoFirstCheckboxEvent += Vm_GotoFirstCheckboxEvent;

            vm.HighlightColorEvent += Vm_HighlightColourEvent;
            vm.ClearColourComboIndexEvent += Vm_ClearColourComboIndexEvent;
            base.DataContext = vm;
        }
        #endregion

        #region event handlers

        private void Vm_ActorChangedEvent(String p_Value)
        {
            ActorChangedEvent(p_Value);
        }

        private void Vm_StartButtonEvent(Boolean p_Value)
        {
            StartButtonEvent(p_Value);
        }

        private void Vm_PauseButtonEvent(Boolean p_Value)
        {
            PauseButtonEvent(p_Value);
        }
        private void Vm_OpenLogButtonEvent()
        {
            OpenLogButtonEvent();
        }

        private void Vm_FilterColourChangedEvent()
        {
            FilterColourChangedEvent();
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

        private void Vm_GoToButtonEvent(String p_Value)
        {
            GoToButtonEvent(p_Value);
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
            DeleteFontButtonEvent();
        }

        private void Vm_HighlightButtonEvent(Boolean p_Value)
        {
            HighlightButtonEvent(p_Value);
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

        private void Vm_GotoFirstCheckboxEvent(Boolean p_Value)
        {
            GotoFirstCheckboxEvent(p_Value);
        }
        
        private void Vm_HighlightColourEvent(Color? p_Value)
        {
            HighlightColorEvent(p_Value);
        }

        private void Vm_ClearColourComboIndexEvent(Int32 p_int)
        {
            ClearColourComboIndexEvent(p_int);
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
                            MyTabItem1Event();
                    }
                    if (MyTabItem2.IsSelected)
                    {
                            MyTabItem2Event();
                    }
                    if (MyTabItem3.IsSelected)
                    {
                            MyTabItem3Event();
                    }
                }
            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            ActorChangedEvent(textBox.Text);
        }

        private void MouseButtonDownHandler(object sender, MouseButtonEventArgs e)
        {
            FilterColourChangedEvent();
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

        public void SetFilterColor(Color? p_Value)
        {
            vm.SetFilterColor(p_Value);
        }


        public void SetHighlightColor(Color? p_Value)
        {
            vm.SetHighlightColor(p_Value);
        }

        public void SetSessionLogDataGrid(DataTable p_Tbl)
        {
            SessionLogDataGrid.ItemsSource = p_Tbl.AsDataView();
        }

        public void SetAnalysisDataGrid(DataTable p_Tbl)
        {
            AnalysisDataGrid.DataContext = p_Tbl.DefaultView;
        }
        

        #endregion
    }
}
