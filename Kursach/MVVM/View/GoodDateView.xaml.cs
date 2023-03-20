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
    /// Interaction logic for GoodDateView.xaml
    /// </summary>
    public partial class GoodDateView : UserControl
    {
        public int offOn;
        public GoodDateView()
        {
            InitializeComponent();
            MusicPlayer.turnOffMainTheme();
            DateVideo.Source = new Uri("5.mp4", UriKind.RelativeOrAbsolute);
            DateVideo.Play();
        }

        private void PlayPause_Bt_Click(object sender, RoutedEventArgs e)
        {
            if (offOn % 2 == 0)
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
