using System.IO;
using System.Reflection;
using System.Windows;
using static System.Environment;

namespace MarketAnalysis.View
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            Initialization();
        }

        public void Initialization()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.DefaultPath))
            {
                Properties.Settings.Default.DefaultPath = $"{GetFolderPath(SpecialFolder.Desktop)}\\MarketAnalysis\\";
                if (!Directory.Exists(Properties.Settings.Default.DefaultPath))
                {
                    Directory.CreateDirectory(Properties.Settings.Default.DefaultPath);
                }
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.DbPath))
            {
                Properties.Settings.Default.DbPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }

            Properties.Settings.Default.Save();
        }
    }
}
