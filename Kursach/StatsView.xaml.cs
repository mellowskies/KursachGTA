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
using static System.Net.Mime.MediaTypeNames;

namespace Kursach
{
    /// <summary>
    /// Interaction logic for StatsView.xaml
    /// </summary>
    public partial class StatsView : Window
    {
        public StatsView()
        {
            InitializeComponent();
        }
        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            SFX.Source = new Uri("select.wav", UriKind.RelativeOrAbsolute);
            SFX.Play();
        }
        // Звук при нажатии
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SFX.Source = new Uri("click.wav", UriKind.RelativeOrAbsolute);
            SFX.Play();
        }
        // Перетаскивание окна при зажатии в области картинки
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            MW.Text = "Главная " + string.Format("{0:00}:{1:00}", Properties.Settings.Default.MainWindowGlobalTime.Minutes, Properties.Settings.Default.MainWindowGlobalTime.Seconds);
            AR.Text = "Акты " + string.Format("{0:00}:{1:00}", Properties.Settings.Default.ActsReaderGlobalTime.Minutes, Properties.Settings.Default.ActsReaderGlobalTime.Seconds);
            Chars.Text = "Персонажи " + string.Format("{0:00}:{1:00}", Properties.Settings.Default.CharactersGlobalTime.Minutes, Properties.Settings.Default.CharactersGlobalTime.Seconds);
            FW.Text = "Фракции " + string.Format("{0:00}:{1:00}", Properties.Settings.Default.FactionsViewGlobalTime.Minutes, Properties.Settings.Default.FactionsViewGlobalTime.Seconds);
            CM.Text = "Собирательство " + string.Format("{0:00}:{1:00}", Properties.Settings.Default.CollectablesMapsGlobalTime.Minutes, Properties.Settings.Default.CollectablesMapsGlobalTime.Seconds);
            LV.Text = "Локации " + string.Format("{0:00}:{1:00}", Properties.Settings.Default.LocationViewGlobalTime.Minutes, Properties.Settings.Default.LocationViewGlobalTime.Seconds);
            MP.Text = "Радио " + string.Format("{0:00}:{1:00}", Properties.Settings.Default.MusicPlayerGlobalTime.Minutes, Properties.Settings.Default.MusicPlayerGlobalTime.Seconds);
            DV.Text = "Свидания " + string.Format("{0:00}:{1:00}", Properties.Settings.Default.DatesGlobalTime.Minutes, Properties.Settings.Default.DatesGlobalTime.Seconds);
            MG.Text = "Мини-игры " + string.Format("{0:00}:{1:00}", Properties.Settings.Default.MiniGamesGlobalTime.Minutes, Properties.Settings.Default.MiniGamesGlobalTime.Seconds);
            MV.Text = "Миссии " + string.Format("{0:00}:{1:00}", Properties.Settings.Default.MissionsGlobalTime.Minutes, Properties.Settings.Default.MissionsGlobalTime.Seconds);
        }
        private void MainMenuButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainMenuButtons.SelectedIndex == 0)
            {
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }
}
