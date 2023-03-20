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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursach.MVVM.View
{
    /// <summary>
    /// Interaction logic for GraffitiView.xaml
    /// </summary>
    public partial class GraffitiView : UserControl
    {
        public GraffitiView()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BigMapWindow bigMapWindow = new BigMapWindow();
            bigMapWindow.currentImage.Source = new BitmapImage(new Uri ("Resources/tagsmap.png", UriKind.RelativeOrAbsolute));
            bigMapWindow.Show();
        }
    }
}
