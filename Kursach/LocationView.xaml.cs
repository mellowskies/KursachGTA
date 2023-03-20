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
    /// Interaction logic for LocationView.xaml
    /// </summary>
    public partial class LocationView : Window
    {
        DateTime startTime;
        DateTime endTime;
        TimeSpan elaspedTime;
        TimeSpan globalTime;
        public byte locationSelected;
        public LocationView()
        {
            InitializeComponent();
        }
        public static void changeLocation(byte locationSelected, TextBlock locationName, Image locationPicture)
        {
            switch (locationSelected)
            {
                case 0:
                    locationName.Text = "Los Santos";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/LosSantosSunrise.png", UriKind.RelativeOrAbsolute));
                    break;
                case 1:
                    locationName.Text = "San Fierro";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/San_Fierro_Overview.png", UriKind.RelativeOrAbsolute));
                    break;
                case 2:
                    locationName.Text = "Las Venturas";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/LasVenturas.png", UriKind.RelativeOrAbsolute));
                    break;
                case 3:
                    locationName.Text = "Red County";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/RedCounty.png", UriKind.RelativeOrAbsolute));
                    break;
                case 4:
                    locationName.Text = "Dillimore";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/Dillimore.png", UriKind.RelativeOrAbsolute));
                    break;
                case 5:
                    locationName.Text = "Flint";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/Flint.png", UriKind.RelativeOrAbsolute));
                    break;
                case 6:
                    locationName.Text = "Montgomery";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/Montgomery.png", UriKind.RelativeOrAbsolute));
                    break;
                case 7:
                    locationName.Text = "Tierra Robada";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/TierraRobada.jpg", UriKind.RelativeOrAbsolute));
                    break;
                case 8:
                    locationName.Text = "Las Barrancas";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/LasBarrancas-GTASA.jpg", UriKind.RelativeOrAbsolute));
                    break;
               case 9:
                    locationName.Text = "Bayside";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/Bayside-GTASA.jpg", UriKind.RelativeOrAbsolute));
                    break;
                case 10:
                    locationName.Text = "El Quebrados";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/ElQuebrados-GTASA.jpg", UriKind.RelativeOrAbsolute));
                    break;
                case 11:
                    locationName.Text = "Aldea Malvada";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/AldeaMalvada-GTASA.jpg", UriKind.RelativeOrAbsolute));
                    break;
                case 12:
                    locationName.Text = "Valle Ocultado";
                    locationPicture.Source = new BitmapImage(new Uri("Resources/ValleOcultado-GTASA.jpg", UriKind.RelativeOrAbsolute));
                    break;
            }
        }

        private void prev_bt_Click(object sender, RoutedEventArgs e)
        {
            if (locationSelected > 0)
            {
                locationSelected--;
                changeLocation(locationSelected, locationName, locationPicture);
            }
        }

        private void next_Bt_Click(object sender, RoutedEventArgs e)
        {
            if (locationSelected < 12)
            {
                locationSelected++;
                changeLocation(locationSelected, locationName, locationPicture);
            }
        }

        private void Exit_Bt_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void locationPicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            globalTime = Properties.Settings.Default.LocationViewGlobalTime;
            startTime = DateTime.Now;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            endTime = DateTime.Now;
            elaspedTime = endTime - startTime;
            globalTime += elaspedTime;
            Properties.Settings.Default.LocationViewGlobalTime = globalTime;
            Properties.Settings.Default.Save();
        }
    }
}

