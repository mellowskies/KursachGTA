using Kursach.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.MVVM.ViewModel
{
    internal class DatesViewModel : ObserableObject
    {
        public RelayCommand RedirectToHomeViewCommand { get; set; }
        public RedirectToHomeViewModel RedirectToHomeVM { get; set; }
        public RelayCommand GirlFriendsViewCommand { get; set; }
        public GirlfriendsViewModel GirlFriendsVM { get; set; }
        public RelayCommand DateTypeViewCommand { get; set; }
        public DateTypeViewModel DateTypeVM { get; set; }
        public RelayCommand GoodDateViewCommand { get; set; }
        public GoodDateViewModel GoodDateVM { get; set; }
        public RelayCommand BadDateViewCommand { get; set; }
        public BadDateViewModel BadDateVM { get; set; }

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
        public DatesViewModel()
        {
            RedirectToHomeVM = new RedirectToHomeViewModel();
            GirlFriendsVM = new GirlfriendsViewModel();
            DateTypeVM = new DateTypeViewModel();
            GoodDateVM = new GoodDateViewModel();
            BadDateVM = new BadDateViewModel();
            CurrentView = GirlFriendsVM;

            RedirectToHomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = RedirectToHomeVM;
            });

            GirlFriendsViewCommand = new RelayCommand(o =>
            {
                CurrentView = GirlFriendsVM;
            });
            DateTypeViewCommand = new RelayCommand(o =>
            {
                CurrentView = DateTypeVM;
            });
            GoodDateViewCommand = new RelayCommand(o =>
            {
                CurrentView = GoodDateVM;
            });
            BadDateViewCommand = new RelayCommand(o =>
            {
                CurrentView = BadDateVM;
            });
        }
    }
}
