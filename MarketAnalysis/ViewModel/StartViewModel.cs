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
            NextLevelCommand = new RelayCommand(NextLevel);
        }

        private void NextLevel(object parameter)
        {
            var analyseWindow = new AnalyseWindow();
            analyseWindow.Show();
            CloseWindow();
        }
    }
}
