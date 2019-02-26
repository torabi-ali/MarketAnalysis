using MarketAnalysis.Helpers;

namespace MarketAnalysis.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        public RelayCommand NextLevelCommand { get; set; }

        public StartViewModel()
        {
            LoadState();
            NextLevelCommand = new RelayCommand(NextLevel);
        }

        private void NextLevel(object parameter)
        {
            SaveState();
            CloseWindow();

            var analyseWindow = new AnalyseWindow();
            analyseWindow.Show();
        }
    }
}
