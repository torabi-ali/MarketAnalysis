using MarketAnalysis.Helpers;
using MarketAnalysis.Model;
using MarketAnalysis.View;

namespace MarketAnalysis.ViewModel
{
    public class AnalyseViewModel : BaseViewModel
    {
        public RelayCommand PreviousLevelCommand { get; set; }
        public RelayCommand NextLevelCommand { get; set; }

        public AnalyseViewModel()
        {
            PreviousLevelCommand = new RelayCommand(PreviousLevel);
            NextLevelCommand = new RelayCommand(NextLevel);

            Analyse();
        }

        public void Analyse()
        {
            for (int i = 0; i < CompanyList.Count; i++)
            {
                CompanyList[i] = CompanyList[i].FullAnalyze();
            }
        }

        private void PreviousLevel(object parameter)
        {
            var startWindow = new StartWindow();
            startWindow.Show();
            CloseWindow();
        }

        private void NextLevel(object parameter)
        {
        }
    }
}
