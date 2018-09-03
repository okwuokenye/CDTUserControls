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
    /// Interaction logic for nCDT.xaml
    /// </summary>
    public partial class PlayerUserControl : UserControl
    {
        PlayerUsercontrolViewModel vm;
        NavigationUserControl _Nav = new NavigationUserControl();
        #region events
        public delegate void ExtendSliderHeightEventHandler(Boolean p_bool, Int32 p_Value);
        public event ExtendSliderHeightEventHandler ExtendSliderHeightEvent;

        public delegate void ShowMetaDataEventHandler(Boolean p_bool, Int32 p_Value);
        public event ShowMetaDataEventHandler ShowMetaDataEvent;

        public delegate void IsSliderVisibleEventHandler(Boolean p_bool, Int32 p_Value);
        public event IsSliderVisibleEventHandler IsSliderVisibleEvent;

        public delegate void ShowFilePathEventHandler();
        public event ShowFilePathEventHandler ShowFilePathEvent;

        public delegate void DeleteButtonEventHandler(String p_FileName, Int32 p_Index);
        public event DeleteButtonEventHandler DeleteButtonEvent;
        
        public delegate void VoiceClickEventHandler(String p_Item);
        public event VoiceClickEventHandler VoiceClickEvent;

        public delegate void VoiceDblClickEventHandler();
        public event VoiceDblClickEventHandler VoiceDblClickEvent;
        
        public delegate void SourceClickEventHandler(String p_Item);
        public event SourceClickEventHandler SourceClickEvent;

        public delegate void SourceDblClickEventHandler();
        public event SourceDblClickEventHandler SourceDblClickEvent;

        public delegate void GlossaryClickEventHandler(String p_Item);
        public event GlossaryClickEventHandler GlossaryClickEvent;

        public delegate void GlossaryDblClickEventHandler();
        public event GlossaryDblClickEventHandler GlossaryDblClickEvent;

        public delegate void EditButtonEventHandler(String p_FileName);
        public event EditButtonEventHandler EditButtonEvent;

        public delegate void RenameButtonEventHandler(String p_FileName);
        public event RenameButtonEventHandler RenameButtonEvent;

        public delegate void PrimaryButtonEventHandler(String p_FileName);
        public event PrimaryButtonEventHandler PrimaryButtonEvent;

        public delegate void TextButtonEventHandler();
        public event TextButtonEventHandler TextButtonEvent;

        public delegate void CharacterButtonEventHandler();
        public event CharacterButtonEventHandler CharacterButtonEvent;

        public delegate void SceneButtonEventHandler();
        public event SceneButtonEventHandler SceneButtonEvent;

        public delegate void ItemButtonEventHandler();
        public event ItemButtonEventHandler ItemButtonEvent;

        public delegate void VideoButtonEventHandler();
        public event VideoButtonEventHandler VideoButtonEvent;

        public delegate void NavigateButtonEventHandler();
        public event NavigateButtonEventHandler NavigateButtonEvent;

        public delegate void VoiceButtonEventHandler();
        public event VoiceButtonEventHandler VoiceButtonEvent;

        public delegate void SourceButtonEventHandler();
        public event SourceButtonEventHandler SourceButtonEvent;

        public delegate void SpotButtonEventHandler();
        public event SpotButtonEventHandler SpotButtonEvent;

        public delegate void AmbientButtonEventHandler();
        public event AmbientButtonEventHandler AmbientButtonEvent;

        public delegate void MusicButtonEventHandler();
        public event MusicButtonEventHandler MusicButtonEvent;

        public delegate void SpkButtonEventHandler();
        public event SpkButtonEventHandler SpkButtonEvent;
        
        public delegate void StopButtonEventHandler();
        public event StopButtonEventHandler StopButtonEvent;

        //list box selected item event
        public delegate void Tab1ItemSelectedEventHandler(String p_Item, Int32 p_Index);
        public event Tab1ItemSelectedEventHandler Tab1ItemSelectedEvent;
        public delegate void Tab2ItemSelectedEventHandler(String p_Item, Int32 p_Index);
        public event Tab2ItemSelectedEventHandler Tab2ItemSelectedEvent;
        public delegate void Tab3ItemSelectedEventHandler(String p_Item, Int32 p_Index);
        public event Tab3ItemSelectedEventHandler Tab3ItemSelectedEvent;


        public delegate void CompareSourceEventHandler(Boolean p_Bool);
        public event CompareSourceEventHandler CompareSourceEvent;

        public delegate void MuteSlider1EventHandler(Boolean p_IsMute);
        public event MuteSlider1EventHandler MuteSlider1Event;
        public delegate void MuteSlider2EventHandler(Boolean p_IsMute);
        public event MuteSlider2EventHandler MuteSlider2Event;
        public delegate void MuteSlider3EventHandler(Boolean p_IsMute);
        public event MuteSlider3EventHandler MuteSlider3Event;
        public delegate void MuteSlider4EventHandler(Boolean p_IsMute);
        public event MuteSlider4EventHandler MuteSlider4Event;
        public delegate void MuteSlider5EventHandler(Boolean p_IsMute);
        public event MuteSlider5EventHandler MuteSlider5Event;
        public delegate void MuteSlider6EventHandler(Boolean p_IsMute);
        public event MuteSlider6EventHandler MuteSlider6Event;

        public delegate void Loop4EventHandler(Boolean p_IsLoop);
        public event Loop4EventHandler Loop4Event;
        public delegate void Loop5EventHandler(Boolean p_IsLoop);
        public event Loop5EventHandler Loop5Event;

        public delegate void Volume1EventHandler(Int32 p_Value);
        public event Volume1EventHandler Volume1Event;
        public delegate void Volume2EventHandler(Int32 p_Value);
        public event Volume2EventHandler Volume2Event;
        public delegate void Volume3EventHandler(Int32 p_Value);
        public event Volume3EventHandler Volume3Event;
        public delegate void Volume4EventHandler(Int32 p_Value);
        public event Volume4EventHandler Volume4Event;
        public delegate void Volume5EventHandler(Int32 p_Value);
        public event Volume5EventHandler Volume5Event;
        public delegate void Volume6EventHandler(Int32 p_Value);
        public event Volume6EventHandler Volume6Event;
        public delegate void Volume7EventHandler(Int32 p_Value);
        public event Volume7EventHandler Volume7Event;


        public delegate void TabIndexChangedEventHandler(Int32 p_Value);
        public event TabIndexChangedEventHandler TabIndexChangedEvent;

        #endregion

        #region public properties
        public NavigationUserControl Nav { get { return _Nav; } }
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


        public PlayerUserControl()
        {
            EnsureApplicationResources();
            InitializeComponent();
            vm = new PlayerUsercontrolViewModel();
            base.DataContext = vm;
            
            vm.DeleteButtonEvent += Vm_DeleteButtonEvent;
            vm.EditButonEvent += Vm_EditButonEvent;
            vm.RenameButtonEvent += Vm_RenameButtonEvent;
            vm.PrimaryButtonEvent += Vm_PrimaryButtonEvent;
            vm.TextButtonEvent += Vm_TextButtonEvent;
            vm.CharacterButtonEvent += Vm_CharacterButtonEvent;
            vm.SceneButtonEvent += Vm_SceneButtonEvent;
            vm.ItemButtonEvent += Vm_ItemButtonEvent;
            vm.VideoButtonEvent += Vm_VideoButtonEvent;
            vm.NavigateButtonEvent += Vm_NavigateButtonEvent;
            vm.VoiceButtonEvent += Vm_VoiceButtonEvent;
            vm.SourceButtonEvent += Vm_SourceButtonEvent;
            vm.SpotButtonEvent += Vm_SpotButtonEvent;
            vm.AmbientButtonEvent += Vm_AmbientButtonEvent;
            vm.MusicButtonEvent += Vm_MusicButtonEvent;
            vm.SpkButtonEvent += Vm_SpkButtonEvent;
            vm.StopButtonEvent += Vm_StopButtonEvent;

            vm.Tab1ItemSelectedEvent += Vm_Tab1ItemSelectedEvent;
            vm.Tab2ItemSelectedEvent += Vm_Tab2ItemSelectedEvent;
            vm.Tab3ItemSelectedEvent += Vm_Tab3ItemSelectedEvent;

            vm.ExtendSliderHeightEvent += Vm_ExtendSliderHeightEvent;
            vm.ShowMetaDataEvent += Vm_ShowMetaDataEvent;
            vm.IsSliderVisibleEvent += Vm_IsSliderVisibleEvent;
            vm.ShowFilePathEvent += Vm_ShowFilePathEvent;

            vm.CompareSourceEvent += Vm_CompareSourceEvent;

            vm.MuteSlider1Event += Vm_MuteSlider1Event;
            vm.MuteSlider2Event += Vm_MuteSlider2Event;
            vm.MuteSlider3Event += Vm_MuteSlider3Event;
            vm.MuteSlider4Event += Vm_MuteSlider4Event;
            vm.MuteSlider5Event += Vm_MuteSlider5Event;
            vm.MuteSlider6Event += Vm_MuteSlider6Event;
            vm.Loop4Event += Vm_Loop4Event;
            vm.Loop5Event += Vm_Loop5Event;


            vm.Volume1Event += Vm_Volume1Event;
            vm.Volume2Event += Vm_Volume2Event;
            vm.Volume3Event += Vm_Volume3Event;
            vm.Volume4Event += Vm_Volume4Event;
            vm.Volume5Event += Vm_Volume5Event;
            vm.Volume6Event += Vm_Volume6Event;
            vm.Volume7Event += Vm_Volume7Event;

            vm.VoiceClickEvent += Vm_VoiceClickEvent;
            vm.GlossaryClickEvent += Vm_GlossaryClickEvent;
            vm.SourceClickEvent += Vm_SourceClickEvent;
        }        

        #endregion

        #region Properties
        public string SliderText1
        {
            get { return vm.SliderText1; }
        }

        public string SliderText2
        {
            get { return vm.SliderText2; }
        }

        public string SliderText3
        {
            get { return vm.SliderText3; }
        }

        public string SliderText4
        {
            get { return vm.SliderText4; }
        }

        public string SliderText5
        {
            get { return vm.SliderText5; }
        }

        public Int32 Slider1
        {
            get { return vm.Slider1; }
        }
        public Int32 Slider2
        {
            get { return vm.Slider2; }
        }
        public Int32 Slider3
        {
            get { return vm.Slider3; }
        }
        public Int32 Slider4
        {
            get { return vm.Slider4; }
        }
        public Int32 Slider5
        {
            get { return vm.Slider5; }
        }
        public Int32 Slider6
        {
            get { return vm.Slider6; }
        }
        public Int32 Slider7
        {
            get { return vm.Slider7; }
        }

        #endregion

        #region viewmodel eventhandlers
        private void Vm_Volume1Event(Int32 p_Value)
        {
            Volume1Event(p_Value);
        }
        private void Vm_Volume2Event(Int32 p_Value)
        {
            Volume2Event(p_Value);
        }
        private void Vm_Volume3Event(Int32 p_Value)
        {
            Volume3Event(p_Value);
        }
        private void Vm_Volume4Event(Int32 p_Value)
        {
            Volume4Event(p_Value);
        }
        private void Vm_Volume5Event(Int32 p_Value)
        {
            Volume5Event(p_Value);
        }
        private void Vm_Volume6Event(Int32 p_Value)
        {
            Volume6Event(p_Value);
        }
        private void Vm_Volume7Event(Int32 p_Value)
        {
            Volume7Event(p_Value);
        }

        private void Vm_Loop5Event(Boolean p_IsLoop)
        {
            Loop5Event(p_IsLoop);
        }

        private void Vm_Loop4Event(Boolean p_IsLoop)
        {
            Loop4Event(p_IsLoop);
        }


        private void Vm_CompareSourceEvent(bool p_Bool)
        {
            CompareSourceEvent(p_Bool);
        }

        private void Vm_MuteSlider1Event(bool p_IsMute)
        {
            MuteSlider1Event(p_IsMute);
        }

        private void Vm_MuteSlider2Event(bool p_IsMute)
        {
            MuteSlider2Event(p_IsMute);
        }

        private void Vm_MuteSlider3Event(bool p_IsMute)
        {
            MuteSlider3Event(p_IsMute);
        }

        private void Vm_MuteSlider4Event(bool p_IsMute)
        {
            MuteSlider4Event(p_IsMute);
        }

        private void Vm_MuteSlider5Event(bool p_IsMute)
        {
            MuteSlider5Event(p_IsMute);
        }

        private void Vm_MuteSlider6Event(bool p_IsMute)
        {
            MuteSlider6Event(p_IsMute);
        }

        private void Vm_IsSliderVisibleEvent(Boolean p_bool, Int32 p_Value)
        {
            IsSliderVisibleEvent(p_bool, p_Value);
        }

        private void Vm_ShowMetaDataEvent(Boolean p_bool, Int32 p_Value)
        {
            ShowMetaDataEvent(p_bool, p_Value);
        }

        private void Vm_ExtendSliderHeightEvent(Boolean p_bool, Int32 p_Value)
        {
            ExtendSliderHeightEvent(p_bool, p_Value);
        }

        private void Vm_ShowFilePathEvent()
        {
            ShowFilePathEvent();
        }

        private void Vm_PrimaryButtonEvent(string p_FileName)
        {
            PrimaryButtonEvent(p_FileName);
        }

        private void Vm_RenameButtonEvent(string p_FileName)
        {
            RenameButtonEvent(p_FileName);
        }

        private void Vm_EditButonEvent(string p_FileName)
        {
            EditButtonEvent(p_FileName);
        }

        private void Vm_DeleteButtonEvent(String p_SelectedFile, Int32 p_Index)
        {
            DeleteButtonEvent(p_SelectedFile, p_Index);
        }

        private void Vm_VideoButtonEvent()
        {
            VideoButtonEvent();
        }

        private void Vm_ItemButtonEvent()
        {
            ItemButtonEvent();
        }

        private void Vm_SceneButtonEvent()
        {
            SceneButtonEvent();
        }

        private void Vm_CharacterButtonEvent()
        {
            CharacterButtonEvent();
        }

        private void Vm_TextButtonEvent()
        {
            TextButtonEvent();
        }

        private void Vm_SpkButtonEvent()
        {
            SpkButtonEvent();
        }

        private void Vm_StopButtonEvent()
        {
            StopButtonEvent();
        }

        private void Vm_MusicButtonEvent()
        {
            MusicButtonEvent();
        }

        private void Vm_AmbientButtonEvent()
        {
            AmbientButtonEvent();
        }

        private void Vm_SpotButtonEvent()
        {
            SpotButtonEvent();
        }

        private void Vm_SourceButtonEvent()
        {
            SourceButtonEvent();
        }

        private void Vm_VoiceButtonEvent()
        {
            VoiceButtonEvent();
        }

        private void Vm_NavigateButtonEvent()
        {
            NavigateButtonEvent();
        }

        private void Vm_Tab3ItemSelectedEvent(string p_Item, int p_Index)
        {
            Tab3ItemSelectedEvent(p_Item, p_Index);
        }

        private void Vm_Tab2ItemSelectedEvent(string p_Item, int p_Index)
        {
            Tab2ItemSelectedEvent(p_Item, p_Index);
        }

        private void Vm_Tab1ItemSelectedEvent(string p_Item, int p_Index)
        {
            Tab1ItemSelectedEvent(p_Item, p_Index);
        }

        #endregion

        #region child window eventhandlers
        private void Voice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VoiceDblClickEvent();
        }

        private void Source_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SourceDblClickEvent();
        }

        private void Glossary_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GlossaryDblClickEvent();
        }

        private void Voice_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Source is ListBox)
            {
                var lb = (ListBox)sender;
                string selectedText = (string)lb.SelectedItem;
                VoiceClickEvent(selectedText);
            }
        }

        private void Vm_VoiceClickEvent(string p_Item)
        {
            VoiceClickEvent(p_Item);
        }

        private void Vm_SourceClickEvent(string p_Item)
        {
            SourceClickEvent(p_Item);
        }

        private void Vm_GlossaryClickEvent(string p_Item)
        {
            GlossaryClickEvent(p_Item);
        }

        private void Source_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Source is ListBox)
            {
                var lb = (ListBox)sender;
                string selectedText = (string)lb.SelectedItem;
                SourceClickEvent(selectedText);
            }
        }

        private void Glossary_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Source is ListBox)
            {
                var lb = (ListBox)sender;
                string selectedText = (string)lb.SelectedItem;
                GlossaryClickEvent(selectedText);
            }
        }

        void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var l_Tab = (TabControl)sender;
                if (l_Tab != null && l_Tab.SelectedContent != null)
                {
                    if (MyTabItem0.IsSelected)
                    {
                        TabIndexChangedEvent(0);
                    }
                    else if (MyTabItem1.IsSelected)
                    {
                        TabIndexChangedEvent(1);
                    }
                    else if (MyTabItem2.IsSelected)
                    {
                        TabIndexChangedEvent(2);
                    }
                }
            }
        }

        private void Slider1DblClick(object sender, RoutedEventArgs args)
        {
            vm.SetSlider1Value(100);
        }
        private void Slider2DblClick(object sender, RoutedEventArgs args)
        {
            vm.SetSlider2Value(100);
        }
        private void Slider3DblClick(object sender, RoutedEventArgs args)
        {
            vm.SetSlider3Value(100);
        }
        private void Slider4DblClick(object sender, RoutedEventArgs args)
        {
            vm.SetSlider4Value(100);
        }
        private void Slider5DblClick(object sender, RoutedEventArgs args)
        {
            vm.SetSlider5Value(100);
        }
        #endregion

        #region public functions
        public void SetMetaData(String p_FileSize, String p_DateMod, String p_AudioType,
            String p_BitDpth, String p_Format, String p_SampleRate, String p_AAT, String p_EAT, String p_Difference,
            String p_Percent, String p_WordCount, String p_CharCount)
        {
            vm.SetMetaData(p_FileSize, p_DateMod, p_AudioType, p_BitDpth, p_Format, p_SampleRate, p_AAT, p_EAT, p_Difference, p_Percent, p_WordCount, p_CharCount);
        }
        
        public void SetStatusPane(String p_StatusPane)
        {
            vm.SetStatusPane(p_StatusPane);
        }

        public void AddItemsToEnglishTab(List<String> p_Items)
        {
            vm.AddItemsToEnglishTab(p_Items);
        }

        public void AddItemsToSourceTab(List<String> p_Items)
        {
            vm.AddItemsToSourceTab(p_Items);
        }
        
        public void AddItemsToGlossaryTab(List<String> p_Items)
        {
            vm.AddItemsToGlossaryTab(p_Items);
        }

        public void RemoveItemFromEnglishTab(Int32 p_ItemIndex)
        {
            vm.RemoveItemFromEnglishTab(p_ItemIndex);
        }

        public void RemoveItemFromSourceTab(Int32 p_ItemIndex)
        {
            vm.RemoveItemFromSourceTab(p_ItemIndex);
        }

        public void RemoveAllItemsFromEnglishTab()
        {
            vm.RemoveAllItemsFromEnglishTab();
        }

        public void RemoveAllItemsFromSourceTab()
        {
            vm.RemoveAllItemsFromSourceTab();
        }

        public void SetTabIndex(Int32 p_Value)
        {
            vm.SetTabIndex(p_Value);
            if(p_Value == 0)
            {
                MyTabItem0.IsSelected = true;
            }
            else if (p_Value == 1)
            {
                MyTabItem1.IsSelected = true;
            }
            else if (p_Value == 2)
            {
                MyTabItem2.IsSelected = true;
            }
        }

        public void SetTab1HeaderText(String p_Text)
        {
            vm.SetTab1HeaderText(p_Text);
        }

        public void SetTab2HeaderText(String p_Text)
        {
            vm.SetTab2HeaderText(p_Text);
        }

        public void SetTab3HeaderText(String p_Text)
        {
            vm.SetTab3HeaderText(p_Text);
        }

        public void SetProgressBar1Maximum(Int32 p_Value)
        {
            vm.SetProgressBar1Maximum(p_Value);
        }

        public void SetProgressBar1Value(Int32 p_Value)
        {
            vm.SetProgressBar1Value(p_Value);
        }

        public void SetProgressBar2Maximum(Int32 p_Value)
        {
            vm.SetProgressBar2Maximum(p_Value);
        }

        public void SetProgressBar2Value(Int32 p_Value)
        {
            vm.SetProgressBar2Value(p_Value);
        }

        public void SetProgressBarColour(System.Windows.Media.Brush p_Color)
        {
            vm.SetProgressBarColour(p_Color);
        }

        public void SetSlider1Value(Int32 p_Value)
        {
            vm.SetSlider1Value(p_Value);
        }
        public void SetSlider2Value(Int32 p_Value)
        {
            vm.SetSlider2Value(p_Value);
        }
        public void SetSlider3Value(Int32 p_Value)
        {
            vm.SetSlider3Value(p_Value);
        }
        public void SetSlider4Value(Int32 p_Value)
        {
            vm.SetSlider4Value(p_Value);
        }
        public void SetSlider5Value(Int32 p_Value)
        {
            vm.SetSlider5Value(p_Value);
        }
        public void SetSlider6Value(Int32 p_Value)
        {
            vm.SetSlider6Value(p_Value);
        }
        public void SetSlider7Value(Int32 p_Value)
        {
            vm.SetSlider7Value(p_Value);
        }
        public void ChangeSideButtonStatus(bool p_IsEnabled)
        {
            vm.ChangeSideButtonStatus(p_IsEnabled);
        }
        public void ChangeVoiceStatus(bool p_IsEnabled)
        {
            vm.ChangeVoiceStatus(p_IsEnabled);
        }
        public void ChangeSourceStatus(bool p_IsEnabled)
        {
            vm.ChangeSourceStatus(p_IsEnabled);
        }
        public void ChangeMusicStatus(bool p_IsEnabled)
        {
            vm.ChangeMusicStatus(p_IsEnabled);
        }
        public void ChangeSFXStatus(bool p_IsEnabled)
        {
            vm.ChangeSFXStatus(p_IsEnabled);
        }
        public void ChangeLFXStatus(bool p_IsEnabled)
        {
            vm.ChangeLFXStatus(p_IsEnabled);
        }
        public void ChangeSpkTextStatus(bool p_IsEnabled)
        {
            vm.ChangeSpkTextStatus(p_IsEnabled);
        }

        public void ChangeVideoStatus(bool p_IsEnabled)
        {
            vm.ChangeVideoStatus(p_IsEnabled);
        }
        public void ChangeCharacterStatus(bool p_IsEnabled)
        {
            vm.ChangeCharacterStatus(p_IsEnabled);
        }
        public void ChangeSceneStatus(bool p_IsEnabled)
        {
            vm.ChangeSceneStatus(p_IsEnabled);
        }
        public void ChangeItemStatus(bool p_IsEnabled)
        {
            vm.ChangeItemStatus(p_IsEnabled);
        }

        public void SetBackgroundColor(string p_Color)
        {
            vm.SetBackgroundColor(p_Color);
        }
        

        #endregion

    }
}
