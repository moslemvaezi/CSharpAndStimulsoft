using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Stimulsoft.Report;
using Path = System.IO.Path;

namespace WpfExamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly string ProjectRootPath = $"{Environment.CurrentDirectory}/Reports";
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //If path not exist create it
            if (!Directory.Exists(ProjectRootPath))
            {
                Directory.CreateDirectory(ProjectRootPath);
            }

            //Generate name for report
            
            var reportPath = Path.Combine(ProjectRootPath, "WpfReport.mrt");

            var report = new StiReport
            {
                ReportFile = reportPath
            };

            report.DesignWithWpf();

            report.Dispose();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var reportPath = Path.Combine(ProjectRootPath, "WpfReport.mrt");
            if (!File.Exists(reportPath))
            {
                MessageBox.Show("File Not Found!");
            }

            var report = new StiReport();
            report.Load(reportPath);
            report.DesignWithWpf();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var reportPath = Path.Combine(ProjectRootPath, "WpfReport.mrt");
            var report = new StiReport();
            report.Load(reportPath);
            report.Print();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var reportPath = Path.Combine(ProjectRootPath, "WpfReport.mrt");
            var report = new StiReport();
            report.Load(reportPath);
            //report.ShowWithWpf();
            report.Show();
        }
    }
}
