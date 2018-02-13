using MarketAnalysis.DomainClass.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using static System.Environment;

namespace MarketAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static BackgroundWorker bw = new BackgroundWorker();
        private Analyze analyze;
        public MainWindow()
        {
            InitializeComponent();
            analyze = new Analyze();

            bw.WorkerReportsProgress = false;
            bw.WorkerSupportsCancellation = false;
            bw.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (e.Argument)
            {
                case "MainForm_Load":
                    Setup();
                    break;
                case "ReadUrls":
                    ReadUrls();
                    break;
            }
        }

        private void Setup()
        {
        }

        private void ReadUrls()
        {
            var str = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
                str = File.ReadAllText(openFileDialog.FileName);

            if (str.IsNotNull())
            {
                AnalyzeCompanies(str);
            }
            else
            {
                MessageBox.Show("The file is empty.");
            }
        }

        private void AnalyzeCompanies(string inputData)
        {
            var urls = inputData.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var list = new List<Company>();

            foreach (var item in urls)
            {
                list.Add(analyze.FullAnalyze(item));
            }

            SavetoFile(list);
        }

        private void SavetoFile(List<Company> companies)
        {
            var csv = new Company().TitleCSV();
            foreach (var item in companies)
            {
                csv += item.CompanyToCSV();
            }

            var filepath = $"{GetFolderPath(SpecialFolder.Desktop)}\\Output.csv";
            using (StreamWriter writer = new StreamWriter(filepath, true, Encoding.UTF8))
            {
                writer.WriteLine(csv);
            }
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync("ReadUrls");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync("MainForm_Load");
            }
        }
    }
}
