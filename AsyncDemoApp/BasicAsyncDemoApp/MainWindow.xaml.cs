using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows;


namespace BasicAsyncDemoApp
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


        #region Download Sync

        private void ExecuteSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            DownloadAllSites();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private void DownloadAllSites()
        {
            List<string> sites = DemoAppMethods.GetUrlWebSites();

            this.ResultTextBlock.Text = "";

            foreach (string item in sites)
            {
                WebSiteInfoDataModel infoData = DemoAppMethods.DownloadWebSite(item);
                ShowWebSiteInfoData(infoData);
            }
        }

        #endregion


        #region Download Async (1)

        private async void ExecuteAsync_1_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await DownloadAllSites_1_Async();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private async Task DownloadAllSites_1_Async()
        {
            List<string> sites = DemoAppMethods.GetUrlWebSites();

            this.ResultTextBlock.Text = "";

            foreach (string item in sites)
            {
                WebSiteInfoDataModel infoData = await DemoAppMethods.DownloadWebSiteAsync(item);
                ShowWebSiteInfoData(infoData);
            }
        }

        #endregion


        #region Download Async (2)

        private async void ExecuteAsync_2_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await DownloadAllSites_2_Async();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private async Task DownloadAllSites_2_Async()
        {
            List<string> sites = DemoAppMethods.GetUrlWebSites();

            this.ResultTextBlock.Text = "";

            foreach (string item in sites)
            {
                WebSiteInfoDataModel infoData = await Task.Run(() => DemoAppMethods.DownloadWebSite(item));
                ShowWebSiteInfoData(infoData);
            }
        }

        #endregion


        #region Download Parallel Async 

        private async void ParallelExecuteAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await DownloadParallel_Async();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private async Task DownloadParallel_Async()
        {
            List<string> sites = DemoAppMethods.GetUrlWebSites();
            List<Task<WebSiteInfoDataModel>> downloadTasks = new List<Task<WebSiteInfoDataModel>>();

            this.ResultTextBlock.Text = "";

            foreach (string item in sites)
            {
                downloadTasks.Add(DemoAppMethods.DownloadWebSiteAsync(item));
            }

            WebSiteInfoDataModel[] results = await Task.WhenAll(downloadTasks);

            foreach (WebSiteInfoDataModel item in results)
            {
                ShowWebSiteInfoData(item);
            }
        }

        #endregion


        private void ShowWebSiteInfoData(WebSiteInfoDataModel infoData)
        {
            this.ResultTextBlock.Text += $"{ infoData.Url }: { infoData.Text.Length } caratteri scaricati.{ Environment.NewLine }";
        }

    }
}
