using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Speech.Synthesis;
using System.Windows.Input;
using System.Threading;
using System.Windows.Media.Imaging;

namespace Kursach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        DateTime startTime;
        DateTime endTime;
        TimeSpan elaspedTime;
        TimeSpan globalTime;
        public MainWindow()
        {
            InitializeComponent();
        }

        // Запуск фоновой музыки
        public static void playMainTheme()
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (main != null)
            {
                main.MainTheme.Volume = 0.2;
                main.MainTheme.Play();
            }
        }

        // Звук при наведении
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
        // Кнопки - переход на окна и выход
        // 0 - Story, 1 - Gameplay, 2 - Radio, 3 - Settings, 4 - Exit
        private void MainMenuButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (MainMenuButtons.SelectedIndex)
            {
                case 0:
                    speechSynthesizer.SpeakAsync("Сюжет");
                    StoryTab storyTab = new StoryTab();
                    this.Hide();
                    storyTab.Show();
                    break;
                case 1:
                    speechSynthesizer.SpeakAsync("Геймплей");
                    this.Hide();
                    GameplayTab gameplayTab = new GameplayTab();
                    gameplayTab.Show();
                    break;
                case 2:
                    speechSynthesizer.SpeakAsync("Радиостанции");
                    RadioTab radioTab = new RadioTab();
                    this.Hide();
                    radioTab.Show();
                    break;
                case 3:
                    speechSynthesizer.SpeakAsync("Статистика");
                    this.Hide();
                    StatsView statsView = new StatsView();
                    statsView.Show();
                    break;
                case 4:
                    speechSynthesizer.SpeakAsync("Выход");
                    if (MessageBox.Show("Вы действтительно хотите выйти из приложения?",
                                        "Выход",
                                        MessageBoxButton.YesNo,
                                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Application.Current.Shutdown();
                    }
                    else { MainMenuButtons.SelectedIndex = -1; }
                    break;
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.isMusicPlaying == true)
            { 
                playMainTheme();
                mainThemeCheckBox.IsChecked = false;
            }
            if (Properties.Settings.Default.isMusicPlaying == false)
            { 
                MusicPlayer.turnOffMainTheme();
                mainThemeCheckBox.IsChecked = true;
            }
            if (Properties.Settings.Default.isSSplaying == true)
            { 
                speechSCheckBox.IsChecked = true;
                speechSynthesizer.Resume();
            }
            if (Properties.Settings.Default.isSSplaying == false)
            {
                speechSCheckBox.IsChecked = false;
                speechSynthesizer.Pause();
            }
            globalTime = Properties.Settings.Default.MainWindowGlobalTime;
            startTime = DateTime.Now;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            endTime = DateTime.Now;
            elaspedTime = endTime - startTime;
            globalTime += elaspedTime;
            Properties.Settings.Default.MainWindowGlobalTime = globalTime;
            Properties.Settings.Default.Save();
        }

        private void mainThemeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (mainThemeCheckBox.IsChecked == true)
            {
                Properties.Settings.Default.isMusicPlaying = false;
                MusicPlayer.turnOffMainTheme();
            }
        }
        private void mainThemeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (mainThemeCheckBox.IsChecked == false)
            {
                Properties.Settings.Default.isMusicPlaying = true;
                playMainTheme();
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
            if (Keyboard.Modifiers == ModifierKeys.Shift && e.Key == Key.L)
            {
                MessageBox.Show("А на самом деле игра про негров");
            }
        }

        private void speechSCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (speechSCheckBox.IsChecked == true)
            {
                Properties.Settings.Default.isSSplaying = true;
                speechSynthesizer.SpeakAsyncCancelAll();
                speechSynthesizer.Resume();
                
            }
        }

        private void speechSCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (speechSCheckBox.IsChecked == false)
            {
                Properties.Settings.Default.isSSplaying = false;
                speechSynthesizer.Pause();
            }
        }
    }
}
