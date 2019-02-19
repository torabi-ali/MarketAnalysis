using MarketAnalysis.Data;
using MarketAnalysis.Helpers;
using MarketAnalysis.Model;
using MarketAnalysis.View;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace MarketAnalysis.ViewModel
{
    public class AnalyseViewModel : BaseViewModel
    {
        public RelayCommand PreviousLevelCommand { get; set; }
        public RelayCommand StartAnalyseCommand { get; set; }

        public AnalyseViewModel()
        {
            LoadState();

            PreviousLevelCommand = new RelayCommand(PreviousLevel);
            StartAnalyseCommand = new RelayCommand(StartAnalyse);
        }

        public Company Analyse(Company company)
        {
            var progressChunk = 1 / CompanyList.Count * 100.0;
            company = company.FullAnalyse();
            CurrentProgress += progressChunk;

            return company;
        }

        private void PreviousLevel(object parameter)
        {
            CloseWindow();

            var startWindow = new StartWindow();
            startWindow.Show();
        }

        private async void StartAnalyse(object parameter)
        {
            var applicationData = new ApplicationData();
            var company = new Company();
            for (int i = CompanyList.Count - 1; i >= 0; i--)
            {
                await Task.Run(() => company = Analyse(CompanyList[i]));
                CompanyList.RemoveAt(i);
                CompanyList.Add(company);
            }

            await SaveStateAsync();
            await SaveToFileAsync();

            MessageBox.Show("اطلاعات در فایل و دیتابیس ذخیره شد", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
