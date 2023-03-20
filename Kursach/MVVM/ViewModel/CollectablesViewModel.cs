using Kursach.Core;

namespace Kursach.MVVM.ViewModel
{
    class CollectablesViewModel : ObserableObject
    {
        public RelayCommand GraffitiViewCommand{ get; set; }
        public RelayCommand SnapshotsViewCommand { get; set; }
        public RelayCommand HorseshoesViewCommand { get; set; }
        public RelayCommand OysterViewCommand { get; set; }
        public RelayCommand UniqueJumpsViewCommand { get; set; }
        public HorseshoesViewModel HorseshoesVM{ get; set; }
        public SnapshotsViewModel SnapshotsVM { get; set; }
        public GraffitiViewModel GraffitiVM { get; set; }
        public OysterViewModel OysterVM { get; set; }
        public UniqueJumpsViewModel UniqueJumpsVM { get; set; }

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

        public CollectablesViewModel()
        {
            GraffitiVM = new GraffitiViewModel();
            SnapshotsVM = new SnapshotsViewModel();
            HorseshoesVM = new HorseshoesViewModel();
            OysterVM = new OysterViewModel();
            UniqueJumpsVM = new UniqueJumpsViewModel();
            CurrentView = GraffitiVM;

            GraffitiViewCommand = new RelayCommand(o =>
            {
                CurrentView = GraffitiVM;
            });

            SnapshotsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SnapshotsVM;
            });

            HorseshoesViewCommand = new RelayCommand(o =>
            {
                CurrentView = HorseshoesVM;
            });

            OysterViewCommand = new RelayCommand(o =>
            {
                CurrentView = OysterVM;
            });

            UniqueJumpsViewCommand = new RelayCommand(o =>
            {
                CurrentView = UniqueJumpsVM;
            });

        }
    }
}
