using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;

namespace CodingDojo7.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentView;
        public RelayCommand OverviewBtnClickCmd { get; set; }
        public RelayCommand MyToysBtnClickCmd { get; set; }
        public ViewModelBase CurrentView
        {
            get { return currentView; ; }
            set { currentView = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            CurrentView = SimpleIoc.Default.GetInstance<OverviewVM>();
            OverviewBtnClickCmd = new RelayCommand(()=> 
            {
                CurrentView = CurrentView = SimpleIoc.Default.GetInstance<OverviewVM>();
                RaisePropertyChanged();
            });

            MyToysBtnClickCmd = new RelayCommand(() =>
            {
                CurrentView = CurrentView = SimpleIoc.Default.GetInstance<MyToysVM>();
                RaisePropertyChanged();
            });

        }
    }
}