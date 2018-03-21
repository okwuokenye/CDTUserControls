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

namespace CDTUserControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl
    {
        CDTPlayerUsercontrolViewModel vm;

        #region events
        public delegate void TextBoxButtonEventHandler();
        public event TextBoxButtonEventHandler TextBoxButtonEvent;

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

        #endregion 

        public MainWindow()
        {
            vm = new CDTPlayerUsercontrolViewModel();
            base.DataContext = vm;
            vm.CharacterButtonEvent += Vm_CharacterButtonEvent;
            vm.SceneButtonEvent += Vm_SceneButtonEvent;
            vm.ItemButtonEvent += Vm_ItemButtonEvent;
            vm.VideoButtonEvent += Vm_VideoButtonEvent;
        }

        private void Vm_VideoButtonEvent()
        {
            MessageBox.Show("Video Clicked");
        }

        private void Vm_ItemButtonEvent()
        {
            MessageBox.Show("Item Clicked");
        }

        private void Vm_SceneButtonEvent()
        {
            MessageBox.Show("Scene Clicked");
        }

        private void Vm_CharacterButtonEvent()
        {
            MessageBox.Show("Character Clicked");
        }
        
    }
}
