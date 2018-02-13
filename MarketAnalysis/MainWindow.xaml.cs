using System.Windows;

namespace MarketAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Analyze analyze;
        public MainWindow()
        {
            InitializeComponent();
            analyze = new Analyze();

            //var alexa = analyze.AlexaAnalyze("aparat.com");
            //var siteRankdata = analyze.SiteRankDataAnalyze("aparat.com");
            //var similarWeb = analyze.SimilarWebAnalyze("daneshjooyar.com");
            //var gtmetrix = analyze.GTmetrixAnalyzeAsync("daneshjooyar.com");

            var company = analyze.FullAnalyze("daneshjooyar.com");

            MessageBox.Show(company.Whois.CEO.ToString());
        }
    }
}
