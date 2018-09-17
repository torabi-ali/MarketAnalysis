using MarketAnalysis.Helpers;
using MarketAnalysis.View;

namespace MarketAnalysis.ViewModel
{
    public class AnalyseViewModel : BaseViewModel
    {
        public RelayCommand PreviousLevelCommand { get; set; }
        public RelayCommand NextLevelCommand { get; set; }

        public AnalyseViewModel()
        {
            LoadState();

            PreviousLevelCommand = new RelayCommand(PreviousLevel);
            NextLevelCommand = new RelayCommand(NextLevel);
        }

        void PreviousLevel(object parameter)
        {
            SaveState();

            var startWindow = new StartWindow();
            startWindow.Show();
            CloseWindow();
        }

        void NextLevel(object parameter)
        {
        }
    }
}
