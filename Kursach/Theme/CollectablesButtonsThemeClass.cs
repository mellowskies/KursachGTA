using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Kursach.Theme
{
    partial class CollectablesButtonsThemeClass
    {

        public void MouseEnter(object sender, MouseEventArgs e)
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (main != null)
            {
                main.SFX.Source = new Uri("select.wav", UriKind.RelativeOrAbsolute);
                main.SFX.Play();
            }

        }
        public void MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                main.SFX1.Source = new Uri("click.wav", UriKind.RelativeOrAbsolute);
                main.SFX1.Play();
            }
        }
    }
}
