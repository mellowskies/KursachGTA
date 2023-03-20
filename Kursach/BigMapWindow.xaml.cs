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
using System.Windows.Shapes;

namespace Kursach
{
    /// <summary>
    /// Interaction logic for BigMapWindow.xaml
    /// </summary>
    public partial class BigMapWindow : Window
    {
        public BigMapWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void currentImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
