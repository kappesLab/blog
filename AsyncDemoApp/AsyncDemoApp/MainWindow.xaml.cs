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
            
            Download();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private async void AsyncExecute_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await DownloadAsync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private async void AsyncParallelExecute_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await DownloadParallelAsync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private List<string> GetUrlWebSites()
        {
            List<string> result = new List<string>()
            {
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.codeproject.com",
                "https://www.nytimes.com",
                "https://www.arduino.cc",
                "https://www.nationalgeographic.com",
                "https://www.libreoffice.org",
                "https://edition.cnn.com/"
            };

            return result;
        }

        private WebSiteInfoDataModel DownloadWebSite(string urlWebSite)
        {
            WebSiteInfoDataModel result = new WebSiteInfoDataModel();
            WebClient client = new WebClient();

            result.Url = urlWebSite;
            result.Text = client.DownloadString(urlWebSite);

            return result;
        }

        private void ShowWebSiteInfoData(WebSiteInfoDataModel infoData)
        {
            this.ResultTextBlock.Text += $"{ infoData.Url }: { infoData.Text.Length } caratteri scaricati.{ Environment.NewLine }";
        }

        private void Download()
        {
            List<string> sites = GetUrlWebSites();

            this.ResultTextBlock.Text = "";

            foreach (string item in sites)
            {
                WebSiteInfoDataModel infoData = DownloadWebSite(item);
                ShowWebSiteInfoData(infoData);
            }
        }

        private async Task DownloadAsync()
        {
            List<string> sites = GetUrlWebSites();

            this.ResultTextBlock.Text = "";

            foreach(string item in sites)
            {
                WebSiteInfoDataModel infoData = await Task.Run(() => DownloadWebSite(item));
                ShowWebSiteInfoData(infoData);
            }
        }

        private async Task DownloadParallelAsync()
        {
            List<string> sites = GetUrlWebSites();
            List<Task<WebSiteInfoDataModel>> downloadTasks = new List<Task<WebSiteInfoDataModel>>();
           
            this.ResultTextBlock.Text = "";

            foreach(string item in sites)
            {
                downloadTasks.Add(Task.Run(() => DownloadWebSite(item)));
            }

            WebSiteInfoDataModel[] results = await Task.WhenAll(downloadTasks);

            foreach(WebSiteInfoDataModel item in results)
            {
                ShowWebSiteInfoData(item);
            }
        }

    }
}
