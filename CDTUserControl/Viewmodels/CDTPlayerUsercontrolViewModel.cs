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
        public delegate void DataUpdatedEventHandler();
        public event DataUpdatedEventHandler DataUpdatedEvent;

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

        #endregion

        #region Private variables
        Visibility _LoaderVisibility = Visibility.Visible;
        Int32 _Slider1 = 50;
        Int32 _Slider2 = 50;
        Int32 _Slider3 = 50;
        Int32 _Slider4 = 50;
        Int32 _Slider5 = 50;
        Int32 _Slider6 = 50;

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
        Boolean _IsMetaDataVisible = false;
        Boolean _ExtendSliderHeight = false;
        String _StatusPane = "Test";
        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get { return _LoaderVisibility; }
        }
        public Int32 Slider1
        {
            get { return _Slider1; }
            set
            {
                if (_Slider1 != value)
                {
                    _Slider1 = value;
                    RaisePropertyChanged("Slider1");
                }
            }
        }
        public Int32 Slider2
        {
            get { return _Slider2; }
            set
            {
                if (_Slider2 != value)
                {
                    _Slider2 = value;
                    RaisePropertyChanged("Slider2");
                }
            }
        }
        public Int32 Slider3
        {
            get { return _Slider3; }
            set
            {
                if (_Slider3 != value)
                {
                    _Slider3 = value;
                    RaisePropertyChanged("Slider3");
                }
            }
        }
        public Int32 Slider4
        {
            get { return _Slider4; }
            set
            {
                if (_Slider4 != value)
                {
                    _Slider4 = value;
                    RaisePropertyChanged("Slider4");
                }
            }
        }
        public Int32 Slider5
        {
            get { return _Slider5; }
            set
            {
                if (_Slider5 != value)
                {
                    _Slider5 = value;
                    RaisePropertyChanged("Slider5");
                }
            }
        }
        public Int32 Slider6
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
        public Double SliderHeight { get { return _ExtendSliderHeight ? 400 : 200; } }
        public String StatusPane { get { return _StatusPane; } }
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

            RaisePropertyChanged("MetaDataVisibility");
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
            RaisePropertyChanged("SliderHeight");
        }
        public ICommand ExtendSliderHeight { get { return new RelayCommand(ExtendSliderHeightExecute); } }
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

        public void AddItemToEnglishTab(List<String> p_Items)
        {
            foreach (var p_Item in p_Items)
            {
                _EnglishTabListBoxItems.Add(p_Item);
            }
            RaisePropertyChanged("EnglishTabListBoxItems");
        }

        public void AddItemToSourceTab(List<String> p_Items)
        {
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
