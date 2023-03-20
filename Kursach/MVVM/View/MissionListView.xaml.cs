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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Kursach.MVVM.View
{
    /// <summary>
    /// Interaction logic for MissionListView.xaml
    /// </summary>
    public partial class MissionListView : UserControl
    {
        public MissionListView()
        {
            InitializeComponent();
            using (StreamReader sr = new StreamReader("missionList.txt"))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    Missions.Text += line + "\n";
                }
            }
           
        }
    }
}
