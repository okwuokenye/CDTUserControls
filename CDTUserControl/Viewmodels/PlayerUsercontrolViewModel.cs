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
using System.Drawing;

namespace CDTUserControl.Viewmodels
{
    class PlayerUsercontrolViewModel : ObservableObject
    {
        #region Event Declarations
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

        public delegate void EditButtonEventHandler(String p_FileName);
        public event EditButtonEventHandler EditButonEvent;

        public delegate void RenameButtonEventHandler(String p_FileName);
        public event RenameButtonEventHandler RenameButtonEvent;

        public delegate void PrimaryButtonEventHandler(String p_FileName);
        public event PrimaryButtonEventHandler PrimaryButtonEvent;


        public delegate void VoiceClickEventHandler();
        public event VoiceClickEventHandler VoiceClickEvent;

        public delegate void VoiceDblClickEventHandler();
        public event VoiceDblClickEventHandler VoiceDblClickEvent;
        
        public delegate void SourceClickEventHandler();
        public event SourceClickEventHandler SourceClickEvent;

        public delegate void SourceDblClickEventHandler();
        public event SourceDblClickEventHandler SourceDblClickEvent;

        public delegate void GlossaryClickEventHandler();
        public event GlossaryClickEventHandler GlossaryClickEvent;

        public delegate void GlossaryDblClickEventHandler();
        public event GlossaryDblClickEventHandler GlossaryDblClickEvent;

        //ignore small buttons 1 and 2
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

        #endregion

        #region Private variables
        Visibility _LoaderVisibility = Visibility.Visible;
        Int32 _Slider1 = 100;
        Int32 _Slider2 = 100;
        Int32 _Slider3 = 100;
        Int32 _Slider4 = 100;
        Int32 _Slider5 = 100;
        Int32 _Slider6 = 100;
        Int32 _Slider7;

        String _SliderText1 = "100";
        String _SliderText2 = "100";
        String _SliderText3 = "100";
        String _SliderText4 = "100";
        String _SliderText5 = "100";

        Boolean _CompareSource = false;

        Boolean _Slider1IsMute = false;
        Boolean _Slider2IsMute = false;
        Boolean _Slider3IsMute = false;
        Boolean _Slider4IsMute = false;
        Boolean _Slider5IsMute = false;
        Boolean _Slider6IsMute = false;
        Boolean _Slider4IsLoop = true;
        Boolean _Slider5IsLoop = true;

        ObservableCollection<String> _EnglishTabListBoxItems = new ObservableCollection<String>();
        String _EnglishTabListBoxItem;
        Int32 _EnglishTabIndex = 0;

        ObservableCollection<String> _SourceTabListBoxItems = new ObservableCollection<String>();
        String _SourceTabListBoxItem;
        Int32 _SourceTabIndex = 0;

        ObservableCollection<String> _GlossaryTabListBoxItems = new ObservableCollection<String>();
        String _GlossaryTabListBoxItem;
        Int32 _GlossaryTabIndex = 0;

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

        Boolean _VoiceEnabled = false;

        String _StatusPane = "";

        Int32 _TabIndex = 0;

        String _Tab1HeaderText = "English";
        String _Tab2HeaderText = "Source";
        String _Tab3HeaderText = "Glossary";
        Int32 _ProgressBar1Maximum = 100;
        Int32 _ProgressBar1Value = 0;
        Int32 _ProgressBar2Maximum = 100;
        Int32 _ProgressBar2Value = 0;

        System.Windows.Media.Brush _ProgressBarColour = System.Windows.Media.Brushes.Green;

        //bool variables for enabling buttons
        bool _IsSideButtons = false;
        bool _IsVoiceEnabled = false;
        bool _IsSourceEnabled = false;
        bool _IsMusicEnabled = false;
        bool _IsSFXEnabled = false;
        bool _IsLFXEnabled = false;
        bool _IsSpkTextEnabled = false;

        bool _IsCharacterEnabled = false;
        bool _IsSceneEnabled = false;
        bool _IsItemEnabled = false;
        bool _IsVideoEnabled = false;

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
                    if (value > 100)
                    {
                        SliderText1 = "+" + value.ToString();
                    }
                    else
                    {
                        SliderText1 = value.ToString();
                    }
                    Volume1Event(value);
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
                    if (value > 100)
                    {
                        SliderText2 = "+" + value.ToString();
                    }
                    else
                    {
                        SliderText2 = value.ToString();
                    }
                    Volume2Event(value);
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
                    if (value > 100)
                    {
                        SliderText3 = "+" + value.ToString();
                    }
                    else
                    {
                        SliderText3 = value.ToString();
                    }
                    Volume3Event(value);
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
                    if (value > 100)
                    {
                        SliderText4 = "+" + value.ToString();
                    }
                    else
                    {
                        SliderText4 = value.ToString();
                    }
                    Volume4Event(value);
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
                    if (value > 100)
                    {
                        SliderText5 = "+" + value.ToString();
                    }
                    else
                    {
                        SliderText5 = value.ToString();
                    }
                    Volume5Event(value);
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
                    Volume6Event(value);
                    RaisePropertyChanged("Slider6");
                }
            }
        }
        public Int32 Slider7
        {
            get { return _Slider7; }
            set
            {
                if (_Slider7 != value)
                {
                    _Slider7 = value;
                    Volume7Event(value);
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

        public ObservableCollection<String> GlossaryTabListBoxItems { get { return _GlossaryTabListBoxItems; } }
        public String GlossaryTabListBoxItem
        {
            get
            {
                return _GlossaryTabListBoxItem;
            }
            set
            {
                if (_GlossaryTabListBoxItem != value)
                {
                    _GlossaryTabListBoxItem = value;
                    //raise Item selected event
                    Tab3ItemSelectedEvent(_GlossaryTabListBoxItem, _GlossaryTabListBoxItems.IndexOf(_GlossaryTabListBoxItem));
                }
            }
        }



        public Int32 GlossaryTabIndex
        {
            get { return _GlossaryTabIndex; }
            set
            {
                if (_GlossaryTabIndex != value)
                {
                    _GlossaryTabIndex = value;
                    RaisePropertyChanged("GlossaryTabIndex");
                }
            }
        }

        public Int32 EnglishTabIndex
        {
            get { return _EnglishTabIndex; }
            set
            {
                if (_EnglishTabIndex != value)
                {
                    _EnglishTabIndex = value;
                    RaisePropertyChanged("EnglishTabIndex");
                }
            }
        }

        public Int32 SourceTabIndex
        {
            get { return _SourceTabIndex; }
            set
            {
                if (_SourceTabIndex != value)
                {
                    _SourceTabIndex = value;
                    RaisePropertyChanged("SourceTabIndex");
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


        public String CloseSliderTT { get { return _IsSliderVisible ? "Hide Slider" : "Show Slider"; } }
        public String ExtendSliderTT { get { return _ExtendSliderHeight ? "Reduce Slider Height" : "Extend Slider Height"; } }
        public String MetaDataTT { get { return _IsMetaDataVisible ? "Hide MetaData" : "Show MetaData"; } }
        
        public Int32 Column2Width { get { return _IsMetaDataVisible ? 165 : 0; } }
        public Int32 SliderHeight { get { return _IsSliderVisible ? _ExtendSliderHeight ? 180 : 80 :  0; } }
        public Int32 Row2Height { get { return _IsSliderVisible ? _ExtendSliderHeight ? 225 : 125 : 0; } }

        public String StatusPane { get { return _StatusPane; } }
        
        public Boolean VoiceEnabled { get { return _VoiceEnabled; } }

        public Int32 TabIndex
        {
            get { return _TabIndex; }
            set
            {
                if (_TabIndex != value)
                {
                    _TabIndex = value;
                }
            }
        }

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

        public System.Windows.Media.Brush ProgressBarColour { get { return _ProgressBarColour; } }

        public String Mute1Source { get { return _Slider1IsMute ? "../Resources/mute.png" : "../Resources/unmute.png"; } }
        public String Mute1Tooltip { get { return _Slider1IsMute ? "unmute voice stream" : "mute voice stream"; } }

        public String Mute2Source { get { return _Slider2IsMute ? "../Resources/mute.png" : "../Resources/unmute.png"; } }
        public String Mute2Tooltip { get { return _Slider2IsMute ? "unmute source stream" : "mute source stream"; } }

        public String Mute3Source { get { return _Slider3IsMute ? "../Resources/mute.png" : "../Resources/unmute.png"; } }
        public String Mute3Tooltip { get { return _Slider3IsMute ? "unmute spot effects" : "mute spot effects"; } }

        public String Mute4Source { get { return _Slider4IsMute ? "../Resources/mute.png" : "../Resources/unmute.png"; } }
        public String Mute4Tooltip { get { return _Slider4IsMute ? "unmute ambient effects" : "mute ambient effects"; } }

        public String Mute5Source { get { return _Slider5IsMute ? "../Resources/mute.png" : "../Resources/unmute.png"; } }
        public String Mute5Tooltip { get { return _Slider5IsMute ? "unmute music" : "mute music"; } }

        public String Mute6Source { get { return _Slider6IsMute ? "../Resources/mute.png" : "../Resources/unmute.png"; } }
        public String Mute6Tooltip { get { return _Slider6IsMute ? "unmute text to speech" : "mute text to speech"; } }

        public String Loop4Source { get { return _Slider4IsLoop ? "../Resources/loop.png" : "../Resources/unloop.png"; } }
        public String Loop4Tooltip { get { return _Slider4IsLoop ? "unloop ambient effects" : "loop ambient effects"; } }

        public String Loop5Source { get { return _Slider5IsLoop ? "../Resources/loop.png" : "../Resources/unloop.png"; } }
        public String Loop5Tooltip { get { return _Slider5IsLoop ? "unloop music" : "loop music"; } }
        public bool IsSideButtonsEnabled { get { return _IsSideButtons; } } //property for side buttons
        public bool IsVoiceEnabled { get { return _IsVoiceEnabled; } } //property for side buttons
        public bool IsSourceEnabled { get { return _IsSourceEnabled; } } //property for side buttons
        public bool IsMusicEnabled { get { return _IsMusicEnabled; } } //property for side buttons
        public bool IsSFXEnabled { get { return _IsSFXEnabled; } } //property for side buttons
        public bool IsLFXEnabled { get { return _IsLFXEnabled; } } //property for side buttons
        public bool IsSpkTextEnabled { get { return _IsSpkTextEnabled; } } //property for side buttons

        public bool IsCharacterEnabled { get { return _IsCharacterEnabled; } } //property for side buttons
        public bool IsSceneEnabled { get { return _IsSceneEnabled; } } //property for side buttons
        public bool IsItemEnabled { get { return _IsItemEnabled; } } //property for side buttons
        public bool IsVideoEnabled { get { return _IsVideoEnabled; } } //property for side buttons

        #endregion

        #region Constructors
        public PlayerUsercontrolViewModel()
        {
            Load_Async();
        }
        #endregion

        #region Commands
        private void DeleteExecute()
        {
            DeleteButtonEvent(_EnglishTabListBoxItem, _EnglishTabListBoxItems.IndexOf(_EnglishTabListBoxItem));
        }

        private Boolean CheckSideButtons()
        {
            return _IsSideButtons;
        }

        public ICommand Delete { get { return new RelayCommand(DeleteExecute); } }

        private void EditExecute()
        {
            EditButonEvent(_EnglishTabListBoxItem);
        }

        public ICommand Edit { get { return new RelayCommand(EditExecute); } }

        private void RenameExecute()
        {
            RenameButtonEvent(_EnglishTabListBoxItem);
        }
        public ICommand Rename { get { return new RelayCommand(RenameExecute); } }

        private void PrimaryExecute()
        {
            PrimaryButtonEvent(_EnglishTabListBoxItem);
        }
        public ICommand Primary { get { return new RelayCommand(PrimaryExecute); } }

        private void TextExecute()
        {
            TextButtonEvent();
        }
        public ICommand Text { get { return new RelayCommand(TextExecute); } }

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

        private Boolean CheckVoice()
        {
            return _IsVoiceEnabled;
        }
        private Boolean CheckSource()
        {
            return _IsSourceEnabled;
        }
        private Boolean CheckMusic()
        {
            return _IsMusicEnabled;
        }
        private Boolean CheckLFX()
        {
            return _IsLFXEnabled;
        }
        private Boolean CheckSFX()
        {
            return _IsSFXEnabled;
        }
        private Boolean CheckSpkText()
        {
            return _IsSpkTextEnabled;
        }


        private Boolean CheckCharacter()
        {
            return _IsCharacterEnabled;
        }

        private Boolean CheckScene()
        {
            return _IsSceneEnabled;
        }

        private Boolean CheckItem()
        {
            return _IsItemEnabled;
        }

        private Boolean CheckVideo()
        {
            return _IsVideoEnabled;
        }

        public ICommand Voice { get { return new RelayCommand(VoiceExecute); } }

        private void SourceExecute()
        {
            SourceButtonEvent();
        }
        public ICommand Source { get { return new RelayCommand(SourceExecute); } }

        private void SpotExecute()
        {
            SpotButtonEvent();
        }
        public ICommand Spot { get { return new RelayCommand(SpotExecute); } }

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
        
        private void StopExecute()
        {
            StopButtonEvent();
        }
        public ICommand Stop { get { return new RelayCommand(StopExecute); } }

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

            RaisePropertyChanged("SliderHeight");
            RaisePropertyChanged("SliderVisibility");
            RaisePropertyChanged("Row2Height");
            RaisePropertyChanged("CloseSliderTT");

            if (_ExtendSliderHeight)
            {
                
                IsSliderVisibleEvent(_IsSliderVisible, 200);
            }
            else
            {
                IsSliderVisibleEvent(_IsSliderVisible, 125);
            }

            

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

            RaisePropertyChanged("Column2Width");
            RaisePropertyChanged("MetaDataVisibility");   
            ShowMetaDataEvent(_IsMetaDataVisible, 165);
            RaisePropertyChanged("MetaDataTT");


        }
        public ICommand CloseMetaData { get { return new RelayCommand(CloseMetaDataExecute); } }

        private void ShowFilePathExecute()
        {
            ShowFilePathEvent();
        }
        public ICommand ShowFilePath { get { return new RelayCommand(ShowFilePathExecute); } }
        
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
            RaisePropertyChanged("SliderVisibility");
            RaisePropertyChanged("Row2Height");
            RaisePropertyChanged("ExtendSliderTT");

            if (_IsSliderVisible)
            {
                ExtendSliderHeightEvent(_ExtendSliderHeight, 100);
            }


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
            RaisePropertyChanged("Mute1Source");
            MuteSlider1Event(_Slider1IsMute);
        }

        public ICommand MuteSlider1 { get { return new RelayCommand(MuteSlider1Execute); } }

        private void CompareSourceExecute()
        {
            if (_CompareSource)
            {
                _CompareSource = false;
            }
            else
            {
                _CompareSource = true;
            }
            RaisePropertyChanged("CompareSource");
            CompareSourceEvent(_CompareSource);
        }

        public ICommand CompareSource { get { return new RelayCommand(CompareSourceExecute); } }


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
            RaisePropertyChanged("Mute2Source");
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
            RaisePropertyChanged("Mute3Source");
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
            RaisePropertyChanged("Mute4Source");
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
            RaisePropertyChanged("Mute5Source");
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
            RaisePropertyChanged("Mute6Source");
            MuteSlider6Event(_Slider6IsMute);
        }
        public ICommand MuteSlider6 { get { return new RelayCommand(MuteSlider6Execute); } }

        private void LoopSlider4Execute()
        {
            if (_Slider4IsLoop)
            {
                _Slider4IsLoop = false;
            }
            else
            {
                _Slider4IsLoop = true;
            }
            RaisePropertyChanged("Loop4Source");
            Loop4Event(_Slider4IsLoop);
        }
        public ICommand LoopSlider4 { get { return new RelayCommand(LoopSlider4Execute); }}

        private void LoopSlider5Execute()
        {
            if (_Slider5IsLoop)
            {
                _Slider5IsLoop = false;
            }
            else
            {
                _Slider5IsLoop = true;
            }
            RaisePropertyChanged("Loop5Source");
            Loop5Event(_Slider5IsLoop);
        }
        public ICommand LoopSlider5 { get { return new RelayCommand(LoopSlider5Execute); } }
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

            ChangeEnglishIndex(0);

            RaisePropertyChanged("EnglishTabListBoxItems");
        }

        public void AddItemsToSourceTab(List<String> p_Items)
        {
            RemoveAllItemsFromSourceTab();
            foreach (var p_Item in p_Items)
            {
                _SourceTabListBoxItems.Add(p_Item);
            }
            
            ChangeSourceIndex(0);

            RaisePropertyChanged("SourceTabListBoxItems");
        }

        public void AddItemsToGlossaryTab(List<String> p_Items)
        {
            RemoveAllItemsFromGlossaryTab();
            foreach (var p_Item in p_Items)
            {
                _GlossaryTabListBoxItems.Add(p_Item);
            }
            
            ChangeGlossaryIndex(0);

            RaisePropertyChanged("GlossaryTabListBoxItems");
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

        public void RemoveAllItemsFromGlossaryTab()
        {
            _GlossaryTabListBoxItems.Clear();
            RaisePropertyChanged("GlossaryTabListBoxItems");
        }
        
        public void SetTabIndex(Int32 p_Value)
        {
            TabIndex = p_Value;
            RaisePropertyChanged("TabIndex");
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

        public void SetProgressBarColour(System.Windows.Media.Brush p_Color)
        {
            _ProgressBarColour = p_Color;
            RaisePropertyChanged("ProgressBarColour");
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
        
        public void SetSlider1Value(Int32 p_Value)
        {
            Slider1 = p_Value;
            RaisePropertyChanged("Slider1");
        }
        public void SetSlider2Value(Int32 p_Value)
        {
            Slider2 = p_Value;
            RaisePropertyChanged("Slider2");
        }
        public void SetSlider3Value(Int32 p_Value)
        {
            Slider3 = p_Value;
            RaisePropertyChanged("Slider3");
        }
        public void SetSlider4Value(Int32 p_Value)
        {
            Slider4 = p_Value;
            RaisePropertyChanged("Slider4");
        }
        public void SetSlider5Value(Int32 p_Value)
        {
            Slider5 = p_Value;
            RaisePropertyChanged("Slider5");
        }
        public void SetSlider6Value(Int32 p_Value)
        {
            Slider6 = p_Value;
            RaisePropertyChanged("Slider6");
        }
        public void SetSlider7Value(Int32 p_Value)
        {
            Slider7 = p_Value;
            RaisePropertyChanged("Slider7");
        }
        
        public void ChangeSideButtonStatus(bool p_IsEnabled)
        {
            _IsSideButtons = p_IsEnabled;
            RaisePropertyChanged("IsSideButtonsEnabled"); //I added a property to the properties region. The property is bound to the buttons in the view
        }
        public void ChangeVoiceStatus(bool p_IsEnabled)
        {
            _IsVoiceEnabled = p_IsEnabled;
            RaisePropertyChanged("IsVoiceEnabled");
        }
        public void ChangeSpkTextStatus(bool p_IsEnabled)
        {
            _IsSpkTextEnabled = p_IsEnabled;
            RaisePropertyChanged("IsSpkTextEnabled");
        }
        public void ChangeLFXStatus(bool p_IsEnabled)
        {
            _IsLFXEnabled = p_IsEnabled;
            RaisePropertyChanged("IsLFXEnabled");
        }
        public void ChangeSFXStatus(bool p_IsEnabled)
        {
            _IsSFXEnabled = p_IsEnabled;
            RaisePropertyChanged("IsSFXEnabled");
        }
        public void ChangeMusicStatus(bool p_IsEnabled)
        {
            _IsMusicEnabled = p_IsEnabled;
            RaisePropertyChanged("IsMusicEnabled");
        }
        public void ChangeSourceStatus(bool p_IsEnabled)
        {
            _IsSourceEnabled = p_IsEnabled;
            RaisePropertyChanged("IsSourceEnabled");
        }

        public void ChangeCharacterStatus(bool p_IsEnabled)
        {
            _IsCharacterEnabled = p_IsEnabled;
            RaisePropertyChanged("IsCharacterEnabled");
        }

        public void ChangeSceneStatus(bool p_IsEnabled)
        {
            _IsSceneEnabled = p_IsEnabled;
            RaisePropertyChanged("IsSceneEnabled");
        }

        public void ChangeItemStatus(bool p_IsEnabled)
        {
            _IsItemEnabled = p_IsEnabled;
            RaisePropertyChanged("IsItemEnabled");
        }

        public void ChangeVideoStatus(bool p_IsEnabled)
        {
            _IsVideoEnabled = p_IsEnabled;
            RaisePropertyChanged("IsVideoEnabled");
        }
        #endregion

        #region Private Functions

        private void ChangeEnglishIndex(Int32 p_value)
        {
            EnglishTabIndex = p_value;
        }

        private void ChangeSourceIndex(Int32 p_value)
        {
            SourceTabIndex = p_value;
        }

        private void ChangeGlossaryIndex(Int32 p_value)
        {
            GlossaryTabIndex = p_value;
        }

        private async void Load_Async()
        {
            try
            {
                _LoaderVisibility = Visibility.Visible;
                RaisePropertyChanged("LoaderVisibility");
                await Task.Run(() =>
                {

                });
                
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
