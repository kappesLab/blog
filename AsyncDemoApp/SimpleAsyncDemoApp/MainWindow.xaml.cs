using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows;




namespace SimpleAsyncDemoApp
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


        #region Download Async

        private async void ExecuteAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await DownloadAllSitesAsync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private async Task DownloadAllSitesAsync()
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


        private void ShowWebSiteInfoData(WebSiteInfoDataModel infoData)
        {
            this.ResultTextBlock.Text += $"{ infoData.Url }: { infoData.Text.Length } caratteri scaricati.{ Environment.NewLine }";
        }


    }
}
