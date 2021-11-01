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

        private void SyncExecute_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            Download();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private void Download()
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

        #region Download Async

        private async void AsyncExecute_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await DownloadAsync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private async Task DownloadAsync()
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

        #region Download Parallel Async (1)

        private async void AsyncParallelExecute_1_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await DownloadParallel_1_Async();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private async Task DownloadParallel_1_Async()
        {
            List<string> sites = DemoAppMethods.GetUrlWebSites();
            List<Task<WebSiteInfoDataModel>> downloadTasks = new List<Task<WebSiteInfoDataModel>>();

            this.ResultTextBlock.Text = "";

            foreach (string item in sites)
            {
                downloadTasks.Add(Task.Run(() => DemoAppMethods.DownloadWebSite(item)));
            }

            WebSiteInfoDataModel[] results = await Task.WhenAll(downloadTasks);

            foreach (WebSiteInfoDataModel item in results)
            {
                ShowWebSiteInfoData(item);
            }
        }

        #endregion

        #region  Download Parallel Async (2)
        private async void AsyncParallelExecute_2_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await DownloadParallel_2_Async();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private async Task DownloadParallel_2_Async()
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
