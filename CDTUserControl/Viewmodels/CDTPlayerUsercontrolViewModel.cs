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

namespace CDTUserControl.Viewmodels
{
    class CDTPlayerUsercontrolViewModel : ObservableObject
    {
        #region Event Declarations
        public delegate void ExtendSliderHeightEventHandler(Boolean p_bool);
        public event ExtendSliderHeightEventHandler ExtendSliderHeightEvent;

        public delegate void ShowMetaDataEventHandler(Boolean p_bool);
        public event ShowMetaDataEventHandler ShowMetaDataEvent;

        public delegate void IsSliderVisibleEventHandler(Boolean p_bool);
        public event IsSliderVisibleEventHandler IsSliderVisibleEvent;

        public delegate void DeleteButtonEventHandler(String p_FileName, Int32 p_Index);
        public event DeleteButtonEventHandler DeleteButtonEvent;

        public delegate void EditButtonEventHandler(String p_FileName);
        public event EditButtonEventHandler EditButonEvent;

        public delegate void RenameButtonEventHandler(String p_FileName);
        public event RenameButtonEventHandler RenameButtonEvent;

        public delegate void PrimaryButtonEventHandler(String p_FileName);
        public event PrimaryButtonEventHandler PrimaryButtonEvent;

        //ignore small buttons 1 and 2
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
        public delegate void MuteSlider7EventHandler(Boolean p_IsMute);
        public event MuteSlider7EventHandler MuteSlider7Event;

        #endregion

        #region Private variables
        Visibility _LoaderVisibility = Visibility.Visible;
        Double _Slider1 = 100;
        Double _Slider2 = 100;
        Double _Slider3 = 100;
        Double _Slider4 = 100;
        Double _Slider5 = 100;
        Double _Slider6 = 100;
        Double _Slider7;

        String _SliderText1 = "100";
        String _SliderText2 = "100";
        String _SliderText3 = "100";
        String _SliderText4 = "100";
        String _SliderText5 = "100";

        Boolean _Slider1IsMute = false;
        Boolean _Slider2IsMute = false;
        Boolean _Slider3IsMute = false;
        Boolean _Slider4IsMute = false;
        Boolean _Slider5IsMute = false;
        Boolean _Slider6IsMute = false;

        ObservableCollection<String> _EnglishTabListBoxItems = new ObservableCollection<String>();
        String _EnglishTabListBoxItem;

        ObservableCollection<String> _SourceTabListBoxItems = new ObservableCollection<String>();
        String _SourceTabListBoxItem;

        String _FileSize;
        String _DateMod;
        String _AudioType;
        String _BitDepth;
        String _Format;
        String _SampleRate;
        String _AAT;
        String _EAT;
        String _Difference;
        String _Percentage;
        String _WordCount;
        String _CharCount;
        Boolean _IsSliderVisible = true;
        Boolean _IsMetaDataVisible = true;
        Boolean _ExtendSliderHeight = false;
        Boolean _CloseSlider = false;
        String _StatusPane = "Test";

        String _Tab1HeaderText = "English";
        String _Tab2HeaderText = "Source";
        String _Tab3HeaderText = "Glossary";
        Int32 _ProgressBar1Maximum = 100;
        Int32 _ProgressBar1Value = 70;
        Int32 _ProgressBar2Maximum = 100;
        Int32 _ProgressBar2Value = 20;
        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get { return _LoaderVisibility; }
        }
        public Double Slider1
        {
            get { return _Slider1; }
            set
            {
                if (_Slider1 != value)
                {
                    _Slider1 = value;
                    if (value > 100)
                    {
                        SliderText1 = "+" + value.ToString();
                    }
                    else
                    {
                        SliderText1 = value.ToString();
                    }

                    RaisePropertyChanged("Slider1");
                }
            }
        }
        public Double Slider2
        {
            get { return _Slider2; }
            set
            {
                if (_Slider2 != value)
                {
                    _Slider2 = value;
                    if (value > 100)
                    {
                        SliderText2 = "+" + value.ToString();
                    }
                    else
                    {
                        SliderText2 = value.ToString();
                    }
                    RaisePropertyChanged("Slider2");
                }
            }
        }
        public Double Slider3
        {
            get { return _Slider3; }
            set
            {
                if (_Slider3 != value)
                {
                    _Slider3 = value;
                    if (value > 100)
                    {
                        SliderText3 = "+" + value.ToString();
                    }
                    else
                    {
                        SliderText3 = value.ToString();
                    }
                    RaisePropertyChanged("Slider3");
                }
            }
        }
        public Double Slider4
        {
            get { return _Slider4; }
            set
            {
                if (_Slider4 != value)
                {
                    _Slider4 = value;
                    if (value > 100)
                    {
                        SliderText4 = "+" + value.ToString();
                    }
                    else
                    {
                        SliderText4 = value.ToString();
                    }
                    RaisePropertyChanged("Slider4");
                }
            }
        }
        public Double Slider5
        {
            get { return _Slider5; }
            set
            {
                if (_Slider5 != value)
                {
                    _Slider5 = value;
                    if (value > 100)
                    {
                        SliderText5 = "+" + value.ToString();
                    }
                    else
                    {
                        SliderText5 = value.ToString();
                    }
                    RaisePropertyChanged("Slider5");
                }
            }
        }
        public Double Slider6
        {
            get { return _Slider6; }
            set
            {
                if (_Slider6 != value)
                {
                    _Slider6 = value;
                    RaisePropertyChanged("Slider6");
                }
            }
        }
        public Double Slider7
        {
            get { return _Slider7; }
            set
            {
                if (_Slider7 != value)
                {
                    _Slider7 = value;
                    RaisePropertyChanged("Slider7");
                }
            }
        }
        public string SliderText1
        {
            get { return _SliderText1; }
            set
            {
                if (_SliderText1 != value)
                {                   
                    _SliderText1 = value;
                    RaisePropertyChanged("SliderText1");
                }
            }
        }
        public string SliderText2
        {
            get { return _SliderText2; }
            set
            {
                if (_SliderText2 != value)
                {
                    _SliderText2 = value;
                    RaisePropertyChanged("SliderText2");
                }
            }
        }
        public string SliderText3
        {
            get { return _SliderText3; }
            set
            {
                if (_SliderText3 != value)
                {
                    _SliderText3 = value;
                    RaisePropertyChanged("SliderText3");
                }
            }
        }
        public string SliderText4
        {
            get { return _SliderText4; }
            set
            {
                if (_SliderText4 != value)
                {
                    _SliderText4 = value;
                    RaisePropertyChanged("SliderText4");
                }
            }
        }
        public string SliderText5
        {
            get { return _SliderText5; }
            set
            {
                if (_SliderText5 != value)
                {
                    _SliderText5 = value;
                    RaisePropertyChanged("SliderText5");
                }
            }
        }
        public ObservableCollection<String> EnglishTabListBoxItems { get { return _EnglishTabListBoxItems; } }
        public String EnglishTabListBoxItem
        {
            get
            {
                return _EnglishTabListBoxItem;
            }
            set
            {
                if (_EnglishTabListBoxItem != value)
                {
                    _EnglishTabListBoxItem = value;
                    //raise Item selected event
                    Tab1ItemSelectedEvent(_EnglishTabListBoxItem, _EnglishTabListBoxItems.IndexOf(_EnglishTabListBoxItem));
                }
            }
        }
        public ObservableCollection<String> SourceTabListBoxItems { get { return _SourceTabListBoxItems; } }
        public String SourceTabListBoxItem
        {
            get
            {
                return _SourceTabListBoxItem;
            }
            set
            {
                if (_SourceTabListBoxItem != value)
                {
                    _SourceTabListBoxItem = value;
                    //raise Item selected event
                    Tab2ItemSelectedEvent(_SourceTabListBoxItem, _SourceTabListBoxItems.IndexOf(_SourceTabListBoxItem));
                }
            }
        }
        public String FileSize
        {
            get
            {
                return _FileSize;
            }
            set
            {
                if (_FileSize != value)
                {
                    _FileSize = value;
                }
            }
        }
        public String DateMod
        {
            get
            {
                return _DateMod;
            }
            set
            {
                if (_DateMod != value)
                {
                    _DateMod = value;
                }
            }
        }
        public String AudioType
        {
            get
            {
                return _AudioType;
            }
            set
            {
                if (_AudioType != value)
                {
                    _AudioType = value;
                }
            }
        }
        public String BitDepth
        {
            get { return _BitDepth; }
            set
            {
                if (_BitDepth != value)
                {
                    _BitDepth = value;
                }
            }
        }
        public String Format
        {
            get { return _Format; }
            set
            {
                if (_Format != value)
                {
                    _Format = value;
                }
            }
        }
        public String SampleRate
        {
            get { return _SampleRate; }
            set
            {
                if (_SampleRate != value)
                {
                    _SampleRate = value;
                }
            }
        }
        public String AAT
        {
            get { return _AAT; }
            set
            {
                if (_AAT != value)
                {
                    _AAT = value;
                }
            }
        }
        public String EAT
        {
            get { return _EAT; }
            set
            {
                if (_EAT != value)
                {
                    _EAT = value;
                }
            }
        }
        public String Difference
        {
            get { return _Difference; }
            set
            {
                if (_Difference != value)
                {
                    _Difference = value;
                }
            }
        }
        public String Percentage
        {
            get { return _Percentage; }
            set
            {
                if (_Percentage != value)
                {
                    _Percentage = value;
                }
            }
        }
        public String WordCount
        {
            get { return _WordCount; }
            set
            {
                if (_WordCount != value)
                {
                    _WordCount = value;
                }
            }
        }
        public String CharCount
        {
            get { return _CharCount; }
            set
            {
                if (_CharCount != value)
                {
                    _CharCount = value;
                }
            }
        }
        public Visibility SliderVisibility { get { return _IsSliderVisible ? Visibility.Visible : Visibility.Collapsed; } }
        public Visibility MetaDataVisibility { get { return _IsMetaDataVisible ? Visibility.Visible : Visibility.Collapsed; } }
        public Double Column2Width { get { return _IsMetaDataVisible ? 160 : 0; } }
        public Double SliderHeight { get { return _CloseSlider ? 0 : _ExtendSliderHeight ? 280 : 80; } }
        public String StatusPane { get { return _StatusPane; } }
        public String Tab1HeaderText
        {
            get { return _Tab1HeaderText; }
        }
        public String Tab2HeaderText
        {
            get { return _Tab2HeaderText; }
        }
        public String Tab3HeaderText
        {
            get { return _Tab3HeaderText; }
        }
        public Int32 ProgressBar1Maximum { get { return _ProgressBar1Maximum; } }
        public Int32 ProgressBar1Value { get { return _ProgressBar1Value; } }
        public Int32 ProgressBar2Maximum { get { return _ProgressBar2Maximum; } }
        public Int32 ProgressBar2Value { get { return _ProgressBar2Value; } }
        #endregion

        #region Constructors
        public CDTPlayerUsercontrolViewModel()
        {
            Load_Async();
        }
        #endregion

        #region Commands
        private void DeleteExecute()
        {
            DeleteButtonEvent(_EnglishTabListBoxItem, _EnglishTabListBoxItems.IndexOf(_EnglishTabListBoxItem));
        }
        private Boolean TabLisItenSelected()
        {
            return _EnglishTabListBoxItem != null || _SourceTabListBoxItem != null;
        }
        public ICommand Delete { get { return new RelayCommand(DeleteExecute, TabLisItenSelected); } }

        private void EditExecute()
        {
            EditButonEvent(_EnglishTabListBoxItem);
        }
        public ICommand Edit { get { return new RelayCommand(EditExecute, TabLisItenSelected); } }

        private void RenameExecute()
        {
            RenameButtonEvent(_EnglishTabListBoxItem);
        }
        public ICommand Rename { get { return new RelayCommand(RenameExecute, TabLisItenSelected); } }

        private void PrimaryExecute()
        {
            PrimaryButtonEvent(_EnglishTabListBoxItem);
        }
        public ICommand Primary { get { return new RelayCommand(PrimaryExecute, TabLisItenSelected); } }

        private void CharacterExecute()
        {
            CharacterButtonEvent();
        }
        public ICommand Character { get { return new RelayCommand(CharacterExecute); } }

        private void SceneExecute()
        {
            SceneButtonEvent();
        }
        public ICommand Scene { get { return new RelayCommand(SceneExecute); } }

        private void ItemExecute()
        {
            ItemButtonEvent();
        }
        public ICommand Item { get { return new RelayCommand(ItemExecute); } }

        private void VideoExecute()
        {
            VideoButtonEvent();
        }
        public ICommand Video { get { return new RelayCommand(VideoExecute); } }

        private void NavigateExecute()
        {
            NavigateButtonEvent();
        }
        public ICommand Navigate { get { return new RelayCommand(NavigateExecute); } }

        private void VoiceExecute()
        {
            VoiceButtonEvent();
        }
        public ICommand Voice { get { return new RelayCommand(VoiceExecute); } }

        private void SourceExecute()
        {
            SourceButtonEvent();
        }
        public ICommand Source { get { return new RelayCommand(SourceExecute); } }

        private void SportExecute()
        {
            SportButtonEvent();
        }
        public ICommand Sport { get { return new RelayCommand(SportExecute); } }

        private void AmbientExecute()
        {
            AmbientButtonEvent();
        }
        public ICommand Ambient { get { return new RelayCommand(AmbientExecute); } }

        private void MusicExecute()
        {
            MusicButtonEvent();
        }
        public ICommand Music { get { return new RelayCommand(MusicExecute); } }

        private void SpkExecute()
        {
            SpkButtonEvent();
        }
        public ICommand Spk { get { return new RelayCommand(SpkExecute); } }

        private void CloseSliderExecute()
        {
            if (_IsSliderVisible)
            {
                _IsSliderVisible = false;
            }
            else
            {
                _IsSliderVisible = true;
            }
            IsSliderVisibleEvent(_IsSliderVisible);
            RaisePropertyChanged("SliderVisibility");
        }
        public ICommand CloseSlider { get { return new RelayCommand(CloseSliderExecute); } }

        private void CloseMetaDataExecute()
        {
            if (_IsMetaDataVisible)
            {
                _IsMetaDataVisible = false;
            }
            else
            {
                _IsMetaDataVisible = true;
            }
            ShowMetaDataEvent(_IsMetaDataVisible);
            RaisePropertyChanged("Column2Width");
        }
        public ICommand CloseMetaData { get { return new RelayCommand(CloseMetaDataExecute); } }

        private void ExtendSliderHeightExecute()
        {
            if (_ExtendSliderHeight)
            {
                _ExtendSliderHeight = false;
            }
            else
            {
                _ExtendSliderHeight = true;
            }
            ExtendSliderHeightEvent(_ExtendSliderHeight);
            RaisePropertyChanged("SliderHeight");
        }
        public ICommand ExtendSliderHeight { get { return new RelayCommand(ExtendSliderHeightExecute); } }

        private void MuteSlider1Execute()
        {
            if (_Slider1IsMute)
            {
                _Slider1IsMute = false;
            }
            else
            {
                _Slider1IsMute = true;
            }
            MuteSlider1Event(_Slider1IsMute);
        }
        public ICommand MuteSlider1 { get { return new RelayCommand(MuteSlider1Execute); } }

        private void MuteSlider2Execute()
        {
            if (_Slider2IsMute)
            {
                _Slider2IsMute = false;
            }
            else
            {
                _Slider2IsMute = true;
            }
            MuteSlider2Event(_Slider2IsMute);
        }
        public ICommand MuteSlider2 { get { return new RelayCommand(MuteSlider2Execute); } }


        private void MuteSlider3Execute()
        {
            if (_Slider3IsMute)
            {
                _Slider3IsMute = false;
            }
            else
            {
                _Slider3IsMute = true;
            }
            MuteSlider3Event(_Slider3IsMute);
        }
        public ICommand MuteSlider3 { get { return new RelayCommand(MuteSlider3Execute); } }


        private void MuteSlider4Execute()
        {
            if (_Slider4IsMute)
            {
                _Slider4IsMute = false;
            }
            else
            {
                _Slider4IsMute = true;
            }
            MuteSlider4Event(_Slider4IsMute);
        }
        public ICommand MuteSlider4 { get { return new RelayCommand(MuteSlider4Execute); } }


        private void MuteSlider5Execute()
        {
            if (_Slider5IsMute)
            {
                _Slider5IsMute = false;
            }
            else
            {
                _Slider5IsMute = true;
            }
            MuteSlider5Event(_Slider5IsMute);
        }
        public ICommand MuteSlider5 { get { return new RelayCommand(MuteSlider5Execute); } }

        private void MuteSlider6Execute()
        {
            if (_Slider6IsMute)
            {
                _Slider6IsMute = false;
            }
            else
            {
                _Slider6IsMute = true;
            }
            MuteSlider6Event(_Slider6IsMute);
        }
        public ICommand MuteSlider6 { get { return new RelayCommand(MuteSlider6Execute); } }

        #endregion

        #region Public Functions
        public void SetMetaData(String p_FileSize, String p_DateMod, String p_AudioType, 
            String p_BitDpth, String p_Format, String p_SampleRate, String p_AAT, String p_EAT, String p_Difference,
            String p_Percent, String p_WordCount, String p_CharCount)
        {
            _FileSize = p_FileSize;
            _DateMod = p_DateMod;
            _AudioType = p_AudioType;
            _BitDepth = p_BitDpth;
            _Format = p_Format;
            _SampleRate = p_SampleRate;
            _AAT = p_AAT;
            _EAT = p_EAT;
            _Difference = p_Difference;
            _Percentage = p_Percent;
            _WordCount = p_WordCount;
            _CharCount = p_CharCount;

            RaisePropertyChanged("FileSize");
            RaisePropertyChanged("DateMod");
            RaisePropertyChanged("AudioType");
            RaisePropertyChanged("BitDepth");
            RaisePropertyChanged("Format");
            RaisePropertyChanged("SampleRate");
            RaisePropertyChanged("AAT");
            RaisePropertyChanged("EAT");
            RaisePropertyChanged("Difference");
            RaisePropertyChanged("Percentage");
            RaisePropertyChanged("WordCount");
            RaisePropertyChanged("CharCount");
        }

        public void SetStatusPane(String p_StatusPane)
        {
            _StatusPane = p_StatusPane;
            RaisePropertyChanged("StatusPane");
        }

        public void AddItemsToEnglishTab(List<String> p_Items)
        {
            RemoveAllItemsFromEnglishTab();
            foreach (var p_Item in p_Items)
            {
                _EnglishTabListBoxItems.Add(p_Item);
            }
            RaisePropertyChanged("EnglishTabListBoxItems");
        }

        public void AddItemsToSourceTab(List<String> p_Items)
        {
            RemoveAllItemsFromSourceTab();
            foreach (var p_Item in p_Items)
            {
                _SourceTabListBoxItems.Add(p_Item);
            }
            RaisePropertyChanged("SourceTabListBoxItems");
        }

        public void RemoveItemFromEnglishTab(Int32 p_ItemIndex)
        {
            _EnglishTabListBoxItems.RemoveAt(p_ItemIndex);
            RaisePropertyChanged("EnglishTabListBoxItems");
        }

        public void RemoveItemFromSourceTab(Int32 p_ItemIndex)
        {
            _SourceTabListBoxItems.RemoveAt(p_ItemIndex);
            RaisePropertyChanged("SourceTabListBoxItems");
        }

        public void RemoveAllItemsFromEnglishTab()
        {
            _EnglishTabListBoxItems.Clear();
            RaisePropertyChanged("EnglishTabListBoxItems");
        }

        public void RemoveAllItemsFromSourceTab()
        {
            _SourceTabListBoxItems.Clear();
            RaisePropertyChanged("SourceTabListBoxItems");
        }

        public void SetTab1HeaderText(String p_Text)
        {
            _Tab1HeaderText = p_Text;
            RaisePropertyChanged("Tab1HeaderText");
        }

        public void SetTab2HeaderText(String p_Text)
        {
            _Tab2HeaderText = p_Text;
            RaisePropertyChanged("Tab2HeaderText");
        }

        public void SetTab3HeaderText(String p_Text)
        {
            _Tab3HeaderText = p_Text;
            RaisePropertyChanged("Tab3HeaderText");
        }

        public void SetProgressBar1Maximum(Int32 p_Value)
        {
            _ProgressBar1Maximum = p_Value;
            RaisePropertyChanged("ProgressBar1Maximum");
        }

        public void SetProgressBar1Value(Int32 p_Value)
        {
            _ProgressBar1Value = p_Value;
            RaisePropertyChanged("ProgressBar1Value");
        }

        public void SetProgressBar2Maximum(Int32 p_Value)
        {
            _ProgressBar2Maximum = p_Value;
            RaisePropertyChanged("ProgressBar2Maximum");
        }

        public void SetProgressBar2Value(Int32 p_Value)
        {
            _ProgressBar2Value = p_Value;
            RaisePropertyChanged("ProgressBar2Value");
        }
        #endregion

        #region Private Functions
        private async void Load_Async()
        {
            try
            {
                _LoaderVisibility = Visibility.Visible;
                RaisePropertyChanged("LoaderVisibility");
                await Task.Run(() =>
                {

                });

                _EnglishTabListBoxItems.Add("No Files Found");
                _SourceTabListBoxItems.Add("No Files Found");

                _LoaderVisibility = Visibility.Collapsed;
                //Raise property changed for every property in view model
                foreach (System.Reflection.PropertyInfo p in this.GetType().GetProperties())
                {
                    RaisePropertyChanged(p.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.ToString() + ".Load_Async\n\n" + ex.Message, "Error found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

    }
}
