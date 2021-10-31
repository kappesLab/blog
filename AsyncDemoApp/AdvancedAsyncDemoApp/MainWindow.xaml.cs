using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace AsyncDemoApp
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void SyncExecute_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<WebSiteInfoDataModel> results = DemoAppMethods.Download();
            ShowResults(results);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }


        private async void AsyncExecute_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<WebSiteInfoDataModel> results = await DemoAppMethods.DownloadAsync();
            ShowResults(results);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }


        private async void AsyncParallelExecute_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<WebSiteInfoDataModel> results = await DemoAppMethods.DownloadParallelAsync();
            ShowResults(results);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }


        private void CancelOperation_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ShowResults(List<WebSiteInfoDataModel> results)
        {
            this.ResultTextBlock.Text = "";

            foreach (var item in results)
            {
                this.ResultTextBlock.Text += $"{ item.Url }: { item.Text.Length } caratteri scaricati.{ Environment.NewLine }";
            }
        }


    }
}
