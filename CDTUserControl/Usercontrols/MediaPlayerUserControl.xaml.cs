using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Windows.Media;

namespace CDTUserControl.Usercontrols
{
    /// <summary>
    /// Interaction logic for MediaPlayerUserControl.xaml
    /// </summary>
    public partial class MediaPlayerUserControl : UserControl
    {
        private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;

        #region events
        public delegate void LockEventHandler(bool p_IsLocked);
        public event LockEventHandler LockEvent;
        #endregion

        public MediaPlayerUserControl()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if ((CDTPlayer.Source != null) && (CDTPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = CDTPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = CDTPlayer.Position.TotalSeconds;
            }
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (CDTPlayer != null) && (CDTPlayer.Source != null);
        }

        private void Play_Executed(object sender, RoutedEventArgs e)
        {
            CDTPlayer.Play();
            MessageBox.Show("Play Clicked");
            mediaPlayerIsPlaying = true;
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Pause_Executed(object sender, RoutedEventArgs e)
        {
            CDTPlayer.Pause();
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Stop_Executed(object sender, RoutedEventArgs e)
        {
            CDTPlayer.Stop();
            mediaPlayerIsPlaying = false;
        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            CDTPlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            CDTPlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }
        
        public void SetMediaFile(string p_FileName)
        {
                CDTPlayer.Source = new Uri(p_FileName);
        }

        private void LockImage_Click(object sender, RoutedEventArgs e)
        {
            //here you can do an if to change the image on the lock button
            if ((bool)Lock.IsChecked)
            {
                //LockImage.Source = ;
            }
            else
            {
                //LockImage.Source = ;
            }

            //this returns an event with a bool property
            LockEvent((bool)Lock.IsChecked);
        }
    }
}