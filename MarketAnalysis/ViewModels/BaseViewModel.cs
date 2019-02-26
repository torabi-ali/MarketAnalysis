using MarketAnalysis.Data;
using MarketAnalysis.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MarketAnalysis.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Company> CompanyList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private bool? _CloseWindowFlag;
        private double _CurrentProgress;

        public BaseViewModel()
        {
            CompanyList = new ObservableCollection<Company>();
        }

        internal void RaisePropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public bool? CloseWindowFlag
        {
            get { return _CloseWindowFlag; }
            set
            {
                _CloseWindowFlag = value;
                RaisePropertyChanged("CloseWindowFlag");
            }
        }

        public double CurrentProgress
        {
            get { return _CurrentProgress; }
            set
            {
                _CurrentProgress = value;
                RaisePropertyChanged("CurrentProgress");
            }
        }

        public virtual void CloseWindow(bool? result = true)
        {
            SaveState();

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                CloseWindowFlag = CloseWindowFlag == null ? true : !CloseWindowFlag;
            }));
        }

        public void SaveState()
        {
            ApplicationData applicationData = new ApplicationData();
            foreach (var item in CompanyList)
            {
                applicationData.UpdateOrInsert(item);
            }
        }

        public async Task SaveStateAsync()
        {
            ApplicationData applicationData = new ApplicationData();
            foreach (var item in CompanyList)
            {
                await Task.Run(() => applicationData.UpdateOrInsert(item));
            }
        }

        public void LoadState()
        {
            ApplicationData applicationData = new ApplicationData();
            var list = applicationData.GetAll();
            foreach (var item in list)
            {
                CompanyList.Add(item);
            }
        }

        public async Task LoadStateAsync()
        {
            ApplicationData applicationData = new ApplicationData();
            var list = applicationData.GetAll();
            foreach (var item in list)
            {
                await Task.Run(() => CompanyList.Add(item));
            }
        }

        public void SaveToFile()
        {
            ApplicationData applicationData = new ApplicationData();
            applicationData.SaveToCSV(CompanyList.ToList());
        }

        public async Task SaveToFileAsync()
        {
            ApplicationData applicationData = new ApplicationData();
            await Task.Run(() => applicationData.SaveToCSV(CompanyList.ToList()));
        }
    }
}
