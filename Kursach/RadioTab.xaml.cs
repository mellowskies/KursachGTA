using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for RadioTab.xaml
    /// </summary>
    public partial class RadioTab : Window
    {
        MusicPlayer musicPlayer = new MusicPlayer();
        public RadioTab()
        {
            InitializeComponent();
        }
        // Перетаскивание за картинку
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
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
        // Переключение радио, заполнения списка песен из файлов
        private void RadiostationsButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (RadiostationsButtons.SelectedIndex)
            {
                case 0:
                    MainWindow.speechSynthesizer.SpeakAsync("Rap & Hip-Hop");
                    musicPlayer.selectedStation = 1;
                    musicPlayer.StationHeader.Text = "Radio Los Santos";
                    musicPlayer.RadioImage.Source = new BitmapImage(new Uri("Resources/Radio_Los_Santos.jpg", UriKind.RelativeOrAbsolute));
                    musicPlayer.MusicList.Items.Clear();
                    using (StreamReader sr = new StreamReader("RAPplaylist.txt"))
                    {
                        string songs;
                        while ((songs = sr.ReadLine()) != null)
                        {
                            musicPlayer.MusicList.Items.Add(songs);
                        }
                    }
                    this.Hide();
                    musicPlayer.Show();
                    break;
                case 1:
                    MainWindow.speechSynthesizer.SpeakAsync("Rock");
                    musicPlayer.selectedStation = 2;
                    musicPlayer.RadioImage.Source = new BitmapImage(new Uri("Resources/RadioX.jpg", UriKind.RelativeOrAbsolute));

                    musicPlayer.StationHeader.Text = "Radio X";
                    musicPlayer.MusicList.Items.Clear();
                    using (StreamReader sr = new StreamReader("ROCKplaylist.txt"))
                    {
                        string songs;
                        while ((songs = sr.ReadLine()) != null)
                        {
                            musicPlayer.MusicList.Items.Add(songs);
                        }
                    }
                    this.Hide();
                    musicPlayer.Show();
                    break;
                case 2:
                    MainWindow.speechSynthesizer.SpeakAsync("Другие");
                    musicPlayer.selectedStation = 3;
                    musicPlayer.StationHeader.Text = "Выберите песню";
                    musicPlayer.MusicList.Items.Clear();
                    using (StreamReader sr = new StreamReader("otherStations.txt"))
                    {
                        string songs;
                        while ((songs = sr.ReadLine()) != null)
                        {
                            musicPlayer.MusicList.Items.Add(songs);
                        }
                    }
                    this.Hide();
                    musicPlayer.Show();
                    break;
                case 3:
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
                RadiostationsButtons.SelectedIndex = 0;
            }
            if (e.Key == Key.D2)
            {
                RadiostationsButtons.SelectedIndex = 1;
            }
            if (e.Key == Key.D3)
            {
                RadiostationsButtons.SelectedIndex = 2;
            }
            if (e.Key == Key.Escape)
            {
                RadiostationsButtons.SelectedIndex = 3;
            }
        }
    }
}
