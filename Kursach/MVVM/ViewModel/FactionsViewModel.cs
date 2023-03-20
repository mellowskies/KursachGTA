using Kursach.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.MVVM.ViewModel
{
    internal class FactionsViewModel : ObserableObject
    {
        public RelayCommand GroveViewCommand { get; set; }
        public GroveViewModel GroveVM { get; set; }
        public RelayCommand BallasViewCommand { get; set; }
        public BallasViewModel BallasVM { get; set; }
        public RelayCommand VagosViewCommand { get; set; }
        public VagosViewModel VagosVM { get; set; }
        public RelayCommand AztecasViewCommand { get; set; }
        public AztecasViewModel AztecasVM { get; set; }

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
        public FactionsViewModel()
        {
            GroveVM = new GroveViewModel();
            BallasVM = new BallasViewModel();
            VagosVM = new VagosViewModel();
            AztecasVM = new AztecasViewModel();
            CurrentView = GroveVM;
            GroveViewCommand = new RelayCommand(o => { CurrentView = GroveVM; });
            BallasViewCommand = new RelayCommand(o => { CurrentView = BallasVM; });
            VagosViewCommand = new RelayCommand(o => { CurrentView = VagosVM; });
            AztecasViewCommand = new RelayCommand(o => { CurrentView = AztecasVM; });
        }
    }
}
