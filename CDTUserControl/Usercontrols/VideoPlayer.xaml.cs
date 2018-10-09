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
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using Microsoft.Win32;
using WPFMediaKit.DirectShow.Controls;
using System.Runtime.InteropServices;

namespace CDTUserControl.Usercontrols
{
    /// <summary>
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer : UserControl
    {
        private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;

        private bool IsLooped = false;

        private DispatcherTimer DoubleClickTimer = new DispatcherTimer();

        [DllImport("user32.dll")]
        private static extern uint GetDoubleClickTime();

        #region events

        public delegate void DblClickEventHandler();
        public event DblClickEventHandler DblClickEvent;

        public delegate void LockEventHandler(bool p_IsLocked);
        public event LockEventHandler LockEvent;

        public delegate void LoopEventHandler(bool p_IsLooped);
        public event LoopEventHandler LoopEvent;
        #endregion

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

        public VideoPlayer()
        {
            EnsureApplicationResources();
            InitializeComponent();
        
            LockImage.Source = null;
            LoopImage.Source = null;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            this.mediaUriElement.VideoRenderer = WPFMediaKit.DirectShow.MediaPlayers.VideoRendererType.EnhancedVideoRenderer;
            
            DoubleClickTimer.Interval = TimeSpan.FromMilliseconds(GetDoubleClickTime());
            DoubleClickTimer.Tick += (s, e) => DoubleClickTimer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if ((CDTPlayer.Source != null) && (CDTPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = CDTPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = CDTPlayer.Position.TotalSeconds;
                lblTotalStatus.Text = TimeSpan.FromSeconds(CDTPlayer.NaturalDuration.TimeSpan.TotalSeconds).ToString(@"hh\:mm\:ss");
            }
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (CDTPlayer != null) && (CDTPlayer.Source != null);
            if ((CDTPlayer.Source != null) && (CDTPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                lblTotalStatus.Text = TimeSpan.FromSeconds(CDTPlayer.NaturalDuration.TimeSpan.TotalSeconds).ToString(@"hh\:mm\:ss");
            }
        }

        private void Play_Executed(object sender, RoutedEventArgs e)
        {
            mediaUriElement.Play();
            CDTPlayer.Play();
            mediaPlayerIsPlaying = true;
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Pause_Executed(object sender, RoutedEventArgs e)
        {
            mediaUriElement.Pause();
            CDTPlayer.Pause();
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Stop_Executed(object sender, RoutedEventArgs e)
        {
            mediaUriElement.Stop();
            CDTPlayer.Stop();

            mediaUriElement.MediaPosition = 0;
            CDTPlayer.Position = TimeSpan.Zero;
            
            mediaPlayerIsPlaying = false;
        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;

            double perc = sliProgress.Value / sliProgress.Maximum;
            mediaUriElement.MediaPosition = (long)(mediaUriElement.MediaDuration * perc);

            CDTPlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);

        }

        private void sliProgress_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            userIsDraggingSlider = false;

            double perc = sliProgress.Value / sliProgress.Maximum;
            mediaUriElement.MediaPosition = (long)(mediaUriElement.MediaDuration * perc);

            CDTPlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            mediaUriElement.Volume += (e.Delta > 0) ? 0.05 : -0.05;
        }

        public void SetMediaFile(string p_FileName)
        {
            if (p_FileName != "")
            {
                mediaUriElement.Source = new Uri(p_FileName);
                CDTPlayer.Source = new Uri(p_FileName);
                CDTPlayer.Play();
                mediaUriElement.Play();
            }
            else
            {
                mediaUriElement.Source = null;
                CDTPlayer.Source = null;
            }            
        }

        private void Open_File(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //define the file filter for your dialog

            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp4;*.mov;*.mpeg|All files (*.*)|*.*";
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                mediaUriElement.Source = new Uri(openFileDialog.FileName);
                CDTPlayer.Source = new Uri(openFileDialog.FileName);
                mediaUriElement.Play();
                CDTPlayer.Play();
            }               
        }
        
        private void LockImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)Lock.IsChecked)
                {
                    LockImage.Source = new BitmapImage(new Uri("../Resources/padlock.png", UriKind.Relative));
                }
                else
                {
                    LockImage.Source = null;
                }

                LockEvent((bool)Lock.IsChecked);

            }
            catch (Exception ex)
            {

            }

        }

        private void LoopImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)Loop.IsChecked)
                {
                    LoopImage.Source = new BitmapImage(new Uri("../Resources/loop.png", UriKind.Relative));
                    IsLooped = true;
                }
                else
                {
                    LoopImage.Source = null;
                    IsLooped = false;
                }

                LoopEvent((bool)Loop.IsChecked);

            }
            catch (Exception ex)
            {

            }

        }

        private void CDTPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (IsLooped)
            {
                mediaUriElement.MediaPosition = 0;
                CDTPlayer.Position = TimeSpan.Zero;

                mediaUriElement.Play();
                CDTPlayer.Play();
            }
        }

        private void MediaPlayer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!DoubleClickTimer.IsEnabled)
            {
                DoubleClickTimer.Start();
            }
            else
            {
                DblClickEvent();
            }

        }

    }
}
