﻿using System;
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
    /// Interaction logic for MiniGamesView.xaml
    /// </summary>
    public partial class MiniGamesView : Window
    {
        DateTime startTime;
        DateTime endTime;
        TimeSpan elaspedTime;
        TimeSpan globalTime;
        public MiniGamesView()
        {
            InitializeComponent();
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void OnMainPage_Checked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            globalTime = Properties.Settings.Default.MiniGamesGlobalTime;
            startTime = DateTime.Now;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            endTime = DateTime.Now;
            elaspedTime = endTime - startTime;
            globalTime += elaspedTime;
            Properties.Settings.Default.MiniGamesGlobalTime = globalTime;
            Properties.Settings.Default.Save();
        }
    }
}
