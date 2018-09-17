﻿using MarketAnalysis.Data;
using MarketAnalysis.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace MarketAnalysis.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        public ObservableCollection<Company> CompanyList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private bool? _CloseWindowFlag;

        public BaseViewModel()
        {
            CompanyList = new ObservableCollection<Company>();
            LoadState();
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
            foreach(var item in CompanyList)
            {
                applicationData.UpdateOrInsert(item);
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
    }
}
