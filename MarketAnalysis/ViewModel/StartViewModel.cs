using MarketAnalysis.Helpers;
using MarketAnalysis.View;

namespace MarketAnalysis.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        public RelayCommand NextLevelCommand { get; set; }

        public StartViewModel()
        {
            NextLevelCommand = new RelayCommand(NextLevel);
        }

        private void NextLevel(object parameter)
        {
            CloseWindow();

            var analyseWindow = new AnalyseWindow();
            analyseWindow.Show();
        }
    }
}
