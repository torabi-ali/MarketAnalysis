using MarketAnalysis.Data;
using MarketAnalysis.Helpers;
using MarketAnalysis.View;

namespace MarketAnalysis.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        private ApplicationData ApplicationData = new ApplicationData();
        public RelayCommand NextLevelCommand { get; set; }

        public StartViewModel()
        {
            LoadState();

            NextLevelCommand = new RelayCommand(NextLevel);
        }

        void NextLevel(object parameter)
        {
            SaveState();

            var analyseWindow = new AnalyseWindow();
            analyseWindow.Show();
            CloseWindow();
        }
    }
}
