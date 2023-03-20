using Kursach.Core;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.MVVM.ViewModel
{
    internal class MiniGamesViewModel : ObserableObject
    {
        public RelayCommand ArcadeViewCommand { get; set; }
        public ArcadeViewModel ArcadeVM { get; set; }
        public RelayCommand GamblingViewCommand { get; set; }
        public GamblingViewModel GamblingVM { get; set; }
        public RelayCommand SportsViewCommand { get; set; }
        public SportsViewModel SportsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MiniGamesViewModel()
        {
            ArcadeVM = new ArcadeViewModel();
            GamblingVM = new GamblingViewModel();
            SportsVM = new SportsViewModel();
            CurrentView = ArcadeVM;
            ArcadeViewCommand = new RelayCommand(o => { CurrentView = ArcadeVM; });
            GamblingViewCommand = new RelayCommand(o => { CurrentView = GamblingVM; });
            SportsViewCommand = new RelayCommand(o => { CurrentView = SportsVM; });
        }
    }
}
