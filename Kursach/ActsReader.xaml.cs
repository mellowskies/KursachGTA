using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
    /// Interaction logic for ActsReader.xaml
    /// </summary>
    public partial class ActsReader : Window
    {
        DateTime startTime;
        DateTime endTime;
        TimeSpan elaspedTime;
        TimeSpan globalTime;
        public ActsReader()
        {
            InitializeComponent();
        }

        private void OnMainPage_Checked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            globalTime = Properties.Settings.Default.ActsReaderGlobalTime;
            startTime = DateTime.Now;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            endTime = DateTime.Now;
            elaspedTime = endTime - startTime;
            globalTime += elaspedTime;
            Properties.Settings.Default.ActsReaderGlobalTime = globalTime;
            Properties.Settings.Default.Save();
        }
    }
}
