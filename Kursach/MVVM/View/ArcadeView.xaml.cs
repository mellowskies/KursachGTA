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
    /// Interaction logic for ArcadeView.xaml
    /// </summary>
    public partial class ArcadeView : UserControl
    {
        public ArcadeView()
        {
            InitializeComponent();
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = (MediaElement)sender;
            mediaElement.LoadedBehavior = MediaState.Manual;
            mediaElement.Position = new TimeSpan(0, 0, 1);
            mediaElement.Play();
        }
    }
}
