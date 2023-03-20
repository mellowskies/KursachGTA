using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml.Schema;

namespace Kursach
{
    /// <summary>
    /// Interaction logic for MusicPlayer.xaml
    /// </summary>
    public partial class MusicPlayer : Window
    {
        public byte selectedStation;
        public string CurrentSong;
        public int offOn = 1;

        DateTime startTime;
        DateTime endTime;
        TimeSpan elaspedTime;
        TimeSpan globalTime;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public MusicPlayer()
        {
            InitializeComponent();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }
        public void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            SongCurrentDuration.Text = string.Format("{0:00}:{1:00}", music.Position.Minutes, music.Position.Seconds);
        }

        // Перетаскивание за картинку
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        // Выключить фоновую музыку
        public static void turnOffMainTheme()
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (main != null)
            {
                main.MainTheme.Pause();
            }
        }
        // Слайдер перемотки песни
        private void timelineSlider_DragCompleted(object sender, EventArgs e)
        {
            int SliderValue = (int)timelineSlider.Value;
            timelineSlider.Maximum = music.NaturalDuration.TimeSpan.TotalMilliseconds;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            music.Position = ts;
        }
        // Слайдер громкости
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            music.Volume = (double)volumeSlider.Value;
        }
        // Кнопки управления
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (offOn % 2 == 0)
            {
                music.Pause();
                Play.Content = "⏸";
                offOn++;
            }
            else
            {
                music.Play();
                Play.Content = "▶";
                offOn++;
            }
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (MusicList.SelectedIndex > 0) { MusicList.SelectedIndex--; }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (MusicList.SelectedIndex < MusicList.Items.Count - 1) { MusicList.SelectedIndex++; }
        }
        // Переключение станций
        private void MusicList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Вывод названия песнен и обложек станций
            Play.Content = "▶";
            offOn++;
            if (MusicList.SelectedItem != null)
            {
                CurrentSong = MusicList.SelectedItem.ToString();
                currentSong.Text = CurrentSong;
            }

            if (selectedStation == 1)
            {
                turnOffMainTheme();
                music.Play();
                switch (MusicList.SelectedIndex)
                {
                    default:
                        music.Source = new Uri("01-Ice Cube - It Was A Good Day.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 0:
                        music.Source = new Uri("01-Ice Cube - It Was A Good Day.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 1:
                        music.Source = new Uri("02-N.W.A. - Express Yourself.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 2:
                        music.Source = new Uri("03-Dr. Dre Feat. Snoop Dog - Fuck Wit Dre Day.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 3:
                        music.Source = new Uri("04-Kid Frost - La Raza.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 4:
                        music.Source = new Uri("05-N.W.A. - Alwayz Into Somethin'.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 5:
                        music.Source = new Uri("06-Cypress Hill - How I Could Just Kill A Man.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 6:
                        music.Source = new Uri("07-Da Lench Mob - Guerillas In Tha Mist.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 7:
                        music.Source = new Uri("08-Dr. Dre Feat. Snoop Dog - Deep Cover.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 8:
                        music.Source = new Uri("09-Ice Cube - Check Yo Self.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 9:
                        music.Source = new Uri("10-Above The Law - Murder Rap.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 10:
                        music.Source = new Uri("11-Dr. Dre Feat. Snoop Dog - Nuthin' But A 'G' Thang.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 11:
                        music.Source = new Uri("12-Too Short - The Ghetto.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 12:
                        music.Source = new Uri("13-The DOC - It's Funky Enough.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 13:
                        music.Source = new Uri("14-Compton's Most Wanted - Hood Took Me Under.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 14:
                        music.Source = new Uri("15-Eazy-E - Eazy-Er Said Than Dunn.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 15:
                        music.Source = new Uri("16-2 Pac - I Don't Give A Fuck.mp3", UriKind.RelativeOrAbsolute);
                        break;
                }
            }
            if (selectedStation == 2)
            {
                turnOffMainTheme();
                music.Play();
                switch (MusicList.SelectedIndex)
                {
                    case 0:
                        music.Source = new Uri("01-Faith No More - Midlife Crisis.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 1:
                        music.Source = new Uri("02-Ozzy Osbourne - Hellraiser.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 2:
                        music.Source = new Uri("03-The Stone Roses - Fools Gold.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 3:
                        music.Source = new Uri("04-Danzig - Mother.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 4:
                        music.Source = new Uri("05-Soundgarden - Rusty Cage.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 5:
                        music.Source = new Uri("06-Jane's Addiction - Been Caught Stealing.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 6:
                        music.Source = new Uri("07-Living Colour - Cult Of Personality.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 7:
                        music.Source = new Uri("08-Guns N' Roses - Welcome To The Jungle.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 8:
                        music.Source = new Uri("09-L7 - Pretend That We're Dead.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 9:
                        music.Source = new Uri("10-Depeche Mode - Personal Jesus.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 10:
                        music.Source = new Uri("11-Stone Temple Pilots - Plush.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 11:
                        music.Source = new Uri("12-Primal Scream - Movin' On Up.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 12:
                        music.Source = new Uri("13-Helmet - Unsung.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 13:
                        music.Source = new Uri("14-Alice In Chains - Them Bones.mp3", UriKind.RelativeOrAbsolute);
                        break;
                    case 14:
                        music.Source = new Uri("15-Rage Against The Machine - Killing In The Name.mp3", UriKind.RelativeOrAbsolute);
                        break;
                }
            }
            if (selectedStation == 3)
            {
                turnOffMainTheme();
                music.Play();
                switch (MusicList.SelectedIndex)
                {
                    case 0:
                        music.Source = new Uri("01-Bobby Brown - Don't Be Cruel.mp3", UriKind.RelativeOrAbsolute);
                        StationHeader.Text = "CSR 103.9";
                        RadioImage.Source = new BitmapImage(new Uri("Resources/CSR103.9.jpg", UriKind.RelativeOrAbsolute));
                        break;
                    case 1:
                        music.Source = new Uri("02-Jomanda - Make My Body Rock.mp3", UriKind.RelativeOrAbsolute);
                        StationHeader.Text = "SF-UR";
                        RadioImage.Source = new BitmapImage(new Uri("Resources/SF-UR.jpg", UriKind.RelativeOrAbsolute));
                        break;
                    case 2:
                        music.Source = new Uri("03-Kiss - Strutter.mp3", UriKind.RelativeOrAbsolute);
                        StationHeader.Text = "K-DST";
                        RadioImage.Source = new BitmapImage(new Uri("Resources/K-DST.jpg", UriKind.RelativeOrAbsolute));
                        break;
                    case 3:
                        music.Source = new Uri("04-Maceo & The Macks - Cross The Tracks (We Better Go Back).mp3", UriKind.RelativeOrAbsolute);
                        StationHeader.Text = "Mater Sounds 98.3";
                        RadioImage.Source = new BitmapImage(new Uri("Resources/GTA_SA_Master_Sounds_Logo.jpg", UriKind.RelativeOrAbsolute));
                        break;
                    case 4:
                        music.Source = new Uri("05-Masta Ace - Me & The Biz.mp3", UriKind.RelativeOrAbsolute);
                        StationHeader.Text = "Playback FM";
                        RadioImage.Source = new BitmapImage(new Uri("Resources/Playback_FM-0.jpg", UriKind.RelativeOrAbsolute));
                        break;
                    case 5:
                        music.Source = new Uri("06-Maze - Twilight.mp3", UriKind.RelativeOrAbsolute);
                        StationHeader.Text = "Bounce FM";
                        RadioImage.Source = new BitmapImage(new Uri("Resources/ImageBounceFM.jpg", UriKind.RelativeOrAbsolute));
                        break;
                    case 6:
                        music.Source = new Uri("07-Merle Haggard - Always Wanting You.mp3", UriKind.RelativeOrAbsolute);
                        StationHeader.Text = "K-Rose";
                        RadioImage.Source = new BitmapImage(new Uri("Resources/K-Rose.jpg", UriKind.RelativeOrAbsolute));
                        break;
                    case 7:
                        music.Source = new Uri("08-Reggie Stepper - Drum Pan Sound.mp3", UriKind.RelativeOrAbsolute);
                        StationHeader.Text = "K-Jah West";
                        RadioImage.Source = new BitmapImage(new Uri("Resources/Kjahwest.jpg", UriKind.RelativeOrAbsolute));
                        break;
                }
            }
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            globalTime = Properties.Settings.Default.MusicPlayerGlobalTime;
            startTime = DateTime.Now;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            endTime = DateTime.Now;
            elaspedTime = endTime - startTime;
            globalTime += elaspedTime;
            Properties.Settings.Default.MusicPlayerGlobalTime = globalTime;
            Properties.Settings.Default.Save();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            music.Stop();
            this.Hide();
            RadioTab radioTab = new RadioTab();
            radioTab.Show();
        }

        private void music_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (music.NaturalDuration.HasTimeSpan)
            {
                SongDuration.Text = string.Format("{0:00}:{1:00}", music.NaturalDuration.TimeSpan.Minutes, music.NaturalDuration.TimeSpan.Seconds);
            }
        }
        public void music_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (music.NaturalDuration.HasTimeSpan)
            {
                SongDuration.Text = string.Format("{0:00}:{1:00}", music.NaturalDuration.TimeSpan.Minutes, music.NaturalDuration.TimeSpan.Seconds);
            }
        }


    }   
}
