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
    /// Interaction logic for GameplayTab.xaml
    /// </summary>
    public partial class GameplayTab : Window
    {
        public GameplayTab()
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
        private void MainMenuButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (MainMenuButtons.SelectedIndex)
            {
                case 0:
                    MainWindow.speechSynthesizer.SpeakAsync("Миссии");
                    MissionsView missionsView = new MissionsView();
                    this.Hide();
                    missionsView.Show();
                    break;
                case 1:
                    MainWindow.speechSynthesizer.SpeakAsync("Собирательство");
                    this.Hide();
                    CollectablesMaps collectablesMaps = new CollectablesMaps();
                    collectablesMaps.Show();
                    break;
                case 2:
                    MainWindow.speechSynthesizer.SpeakAsync("Свидания");
                    this.Hide();
                    DatesView datesView = new DatesView();
                    datesView.Show();
                    break;
                case 3:
                    MainWindow.speechSynthesizer.SpeakAsync("Мини-игры");
                    this.Hide();
                    MiniGamesView miniGamesView = new MiniGamesView();
                    miniGamesView.Show();
                    break;
                case 4:
                    MainWindow.speechSynthesizer.SpeakAsync("Главное окно");
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    break;
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D1)
            {
                MainMenuButtons.SelectedIndex = 0;
            }
            if (e.Key == Key.D2)
            {
                MainMenuButtons.SelectedIndex = 1;
            }
            if (e.Key == Key.D3)
            {
                MainMenuButtons.SelectedIndex = 2;
            }
            if (e.Key == Key.D4)
            {
                MainMenuButtons.SelectedIndex = 3;
            }
            if (e.Key == Key.Escape)
            {
                MainMenuButtons.SelectedIndex = 4;
            }
        }
    }
}
