using Kursach.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.MVVM.ViewModel
{
    class CharacterViewModel : ObserableObject
    {
        public RelayCommand CJViewCommand { get; set; }
        public CJViewModel CJVM { get; set; }
        public RelayCommand SweetViewCommand { get; set; }
        public SweetViewModel SweetVM { get; set; }
        public RelayCommand BigSmokeViewCommand { get; set; }
        public BigSmokeViewModel BigSmokeVM { get; set; }
        public RelayCommand RyderViewCommand { get; set; }
        public RyderViewModel RyderVM { get; set; }
        public RelayCommand TempennyViewCommand { get; set; }
        public TempennyViewModel TempennyVM { get; set; }
        public RelayCommand CesarViewCommand { get; set; }
        public CesarViewModel CesarVM { get; set; }
        public RelayCommand TruthViewCommand { get; set; }
        public TruthViewModel TruthVM { get; set; }
        public RelayCommand WuZiMuViewCommand { get; set; }
        public WuZiMuViewModel WuZiMuVM { get; set; }
        public RelayCommand TorenoViewCommand { get; set; }
        public TorenoViewModel TorenoVM { get; set; }

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
        public CharacterViewModel()
        {
            CJVM = new CJViewModel();
            SweetVM = new SweetViewModel();
            BigSmokeVM = new BigSmokeViewModel();
            RyderVM = new RyderViewModel();
            TempennyVM = new TempennyViewModel();
            CesarVM = new CesarViewModel();
            TruthVM = new TruthViewModel();
            WuZiMuVM = new WuZiMuViewModel();
            TorenoVM = new TorenoViewModel();
            CurrentView = CJVM;
            CJViewCommand = new RelayCommand(o =>
            {
                CurrentView = CJVM;
            });
            SweetViewCommand = new RelayCommand(o =>
            {
                CurrentView = SweetVM;
            });
            BigSmokeViewCommand = new RelayCommand(o =>
            {
                CurrentView = BigSmokeVM;
            });
            RyderViewCommand = new RelayCommand(o => 
            {
                CurrentView = RyderVM;
            });
            TempennyViewCommand = new RelayCommand(o =>
            {
                CurrentView = TempennyVM;
            });
            CesarViewCommand = new RelayCommand(o =>
            {
                CurrentView = CesarVM;
            });
            TruthViewCommand = new RelayCommand(o =>
            {
                CurrentView = TruthVM;
            });
            WuZiMuViewCommand = new RelayCommand(o =>
            {
                CurrentView = WuZiMuVM;
            });
            TorenoViewCommand = new RelayCommand(o =>
            {
                CurrentView = TorenoVM;
            });

        }
    }
}
