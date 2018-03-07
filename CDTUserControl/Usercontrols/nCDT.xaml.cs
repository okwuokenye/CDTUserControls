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
    public partial class nCDT : UserControl
    {
        CDTPlayerUsercontrolViewModel vm;
        NavigationUsercontrolView _Nav = new NavigationUsercontrolView();
        #region events
        public delegate void DeleteButtonEventHandler(String p_FileName, Int32 p_Index);
        public event DeleteButtonEventHandler DeleteButtonEvent;

        public delegate void EditButtonEventHandler(String p_FileName);
        public event EditButtonEventHandler EditButtonEvent;

        public delegate void RenameButtonEventHandler(String p_FileName);
        public event RenameButtonEventHandler RenameButtonEvent;

        public delegate void PrimaryButtonEventHandler(String p_FileName);
        public event PrimaryButtonEventHandler PrimaryButtonEvent;

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

        public delegate void SportButtonEventHandler();
        public event SportButtonEventHandler SportButtonEvent;

        public delegate void AmbientButtonEventHandler();
        public event AmbientButtonEventHandler AmbientButtonEvent;

        public delegate void MusicButtonEventHandler();
        public event MusicButtonEventHandler MusicButtonEvent;

        public delegate void SpkButtonEventHandler();
        public event SpkButtonEventHandler SpkButtonEvent;
        //list box selected item event
        public delegate void Tab1ItemSelectedEventHandler(String p_Item, Int32 p_Index);
        public event Tab1ItemSelectedEventHandler Tab1ItemSelectedEvent;
        public delegate void Tab2ItemSelectedEventHandler(String p_Item, Int32 p_Index);
        public event Tab2ItemSelectedEventHandler Tab2ItemSelectedEvent;
        public delegate void Tab3ItemSelectedEventHandler(String p_Item, Int32 p_Index);
        public event Tab3ItemSelectedEventHandler Tab3ItemSelectedEvent;
        #endregion

        #region public properties
        public NavigationUsercontrolView Nav { get { return _Nav; } }
        #endregion

        #region Constructor
        public nCDT()
        {
            InitializeComponent();
            vm = new CDTPlayerUsercontrolViewModel();
            base.DataContext = vm;
            vm.DeleteButtonEvent += Vm_DeleteButtonEvent;
            vm.EditButonEvent += Vm_EditButonEvent;
            vm.RenameButtonEvent += Vm_RenameButtonEvent;
            vm.PrimaryButtonEvent += Vm_PrimaryButtonEvent;
            vm.CharacterButtonEvent += Vm_CharacterButtonEvent;
            vm.SceneButtonEvent += Vm_SceneButtonEvent;
            vm.ItemButtonEvent += Vm_ItemButtonEvent;
            vm.VideoButtonEvent += Vm_VideoButtonEvent;
            vm.NavigateButtonEvent += Vm_NavigateButtonEvent;
            vm.VoiceButtonEvent += Vm_VoiceButtonEvent;
            vm.SourceButtonEvent += Vm_SourceButtonEvent;
            vm.SportButtonEvent += Vm_SportButtonEvent;
            vm.AmbientButtonEvent += Vm_AmbientButtonEvent;
            vm.MusicButtonEvent += Vm_MusicButtonEvent;
            vm.SpkButtonEvent += Vm_SpkButtonEvent;
            vm.Tab1ItemSelectedEvent += Vm_Tab1ItemSelectedEvent;
            vm.Tab2ItemSelectedEvent += Vm_Tab2ItemSelectedEvent;
            vm.Tab3ItemSelectedEvent += Vm_Tab3ItemSelectedEvent;
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

        public Double Slider6
        {
            get { return vm.Slider6; }
        }

        public Double Slider7
        {
            get { return vm.Slider7; }
        }
        #endregion

        #region eventhandlers
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

        private void Vm_SpkButtonEvent()
        {
            SpkButtonEvent();
        }

        private void Vm_MusicButtonEvent()
        {
            MusicButtonEvent();
        }

        private void Vm_AmbientButtonEvent()
        {
            AmbientButtonEvent();
        }

        private void Vm_SportButtonEvent()
        {
            SportButtonEvent();
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
            //_Nav;
        }

        private void Vm_Tab3ItemSelectedEvent(string p_Item, int p_Index)
        {
            throw new NotImplementedException();
        }

        private void Vm_Tab2ItemSelectedEvent(string p_Item, int p_Index)
        {
            throw new NotImplementedException();
        }

        private void Vm_Tab1ItemSelectedEvent(string p_Item, int p_Index)
        {
            throw new NotImplementedException();
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

        public void AddItemToEnglishTab(List<String> p_Items)
        {
            vm.AddItemsToEnglishTab(p_Items);
        }

        public void AddItemToSourceTab(List<String> p_Items)
        {
            vm.AddItemsToSourceTab(p_Items);
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

        public void ResizeControl(Int32 p_Width)
        {
            //need more information on how this should work
            this.Width = p_Width;
            TCtrl.Width = p_Width - 200;
            MessageBox.Show("Control Resized");
        }
        #endregion
    }
}
