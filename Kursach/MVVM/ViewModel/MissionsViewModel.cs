using Kursach.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.MVVM.ViewModel
{
    internal class MissionsViewModel : ObserableObject
    {
        public RelayCommand MissionsHowToPlayViewCommand { get; set; }
        public MissionsHowToPlayViewModel MissionsHowToPlayVM { get; set; }
        public RelayCommand MissionListViewCommand { get; set; }
        public MissionListViewModel MissionListVM { get; set; }


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
        public MissionsViewModel()
        {
            MissionsHowToPlayVM = new MissionsHowToPlayViewModel();
            MissionListVM = new MissionListViewModel();
            CurrentView = MissionsHowToPlayVM;
            MissionsHowToPlayViewCommand = new RelayCommand(o =>
            {
                CurrentView = MissionsHowToPlayVM;
            });
            MissionListViewCommand = new RelayCommand(o =>
            {
                CurrentView = MissionListVM;
            });
        }
    }
}
