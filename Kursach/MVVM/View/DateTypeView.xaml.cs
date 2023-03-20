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

namespace Kursach.MVVM.View
{
    /// <summary>
    /// Interaction logic for DateTypeView.xaml
    /// </summary>
    public partial class DateTypeView : UserControl
    {
        public byte selectedVideo;
        public int offOn;
        public DateTypeView()
        {
            InitializeComponent();
            changeVideo(DateVideo, dateType, selectedVideo);
        }
        public void changeVideo(MediaElement ME, TextBlock TB, byte sV)
        {
            MusicPlayer.turnOffMainTheme();
            switch (sV)
            {
                default:
                    ME.Source = new Uri("1.mp4", UriKind.RelativeOrAbsolute);
                    TB.Text = "Поездка в бар, ресторан";
                    ME.Play();
                    break;
                case 0:
                    ME.Source = new Uri("1.mp4", UriKind.RelativeOrAbsolute);
                    TB.Text = "Поездка в бар, ресторан";
                    ME.Play();
                    break;
                case 1:
                    ME.Source = new Uri("2.mp4", UriKind.RelativeOrAbsolute);
                    TB.Text = "Обычная поездка";
                    ME.Play();
                    break;
                case 2:
                    ME.Source = new Uri("3.mp4", UriKind.RelativeOrAbsolute);
                    TB.Text = "Поездка в клуб";
                    ME.Play();
                    break;
            }
        }
        private void prev_bt_Click(object sender, RoutedEventArgs e)
        {
            if (selectedVideo > 0)
            {
                selectedVideo--;
                changeVideo(DateVideo, dateType, selectedVideo);
            }
        }

        private void next_Bt_Click(object sender, RoutedEventArgs e)
        {
            if (selectedVideo < 2)
            {
                selectedVideo++;
                changeVideo(DateVideo, dateType, selectedVideo);
            }
        }

        private void PlayPause_Bt_Click(object sender, RoutedEventArgs e)
        {
            if (offOn %2 == 0)
            {
                DateVideo.Pause();
                PlayPause_Bt.Content = "⏸";
                offOn++;
            }
            else
            {
                DateVideo.Play();
                PlayPause_Bt.Content = "▶";
                offOn++;
            }
        }
    }
}
