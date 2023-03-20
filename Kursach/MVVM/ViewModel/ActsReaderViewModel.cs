using Kursach.Core;

namespace Kursach.MVVM.ViewModel
{
    class ActsReaderViewModel : ObserableObject
    {
        public RelayCommand Act1ViewCommand { get; set; }
        public Act1ViewModel Act1VM { get; set; }
        public RelayCommand Act2ViewCommand { get; set; }
        public Act2ViewModel Act2VM { get; set; }
        public RelayCommand Act3ViewCommand { get; set; }
        public Act3ViewModel Act3VM { get; set; }

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

        public ActsReaderViewModel()
        {
            Act1VM = new Act1ViewModel();
            Act2VM = new Act2ViewModel();
            Act3VM = new Act3ViewModel();

            CurrentView = Act1VM;

            Act1ViewCommand= new RelayCommand(o =>
            {
                CurrentView = Act1VM;
            });
            Act2ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Act2VM;
            });
            Act3ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Act3VM;
            });
        }
    }
}
