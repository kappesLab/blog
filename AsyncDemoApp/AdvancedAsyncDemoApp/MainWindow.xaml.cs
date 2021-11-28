using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;



namespace AdvancedAsyncDemoApp
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cts { get; set; } = null;


        public MainWindow()
        {
            InitializeComponent();
        }

        #region Download Sync
        private void ExecuteSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<WebSiteInfoDataModel> results = DemoAppMethods.Download();
            ShowResults(results);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private void ParallelExecuteSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<WebSiteInfoDataModel> results = DemoAppMethods.DownloadParallel();
            ShowResults(results);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        #endregion


        #region Download Async
        private async void ExecuteAsync_Click(object sender, RoutedEventArgs e)
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += Progress_ProgressChanged;

            cts = new CancellationTokenSource();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                List<WebSiteInfoDataModel> results = await DemoAppMethods.DownloadAsync(progress, cts.Token);
                ShowResults(results);
            }
            catch (OperationCanceledException)
            {
                this.ResultTextBlock.Text += $"L'operazione di download è stata cancellata.{ Environment.NewLine }";
            }
            finally
            {
                cts.Dispose();
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }


        private async void ParallelExecuteAsync_1_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<WebSiteInfoDataModel> results = await DemoAppMethods.DownloadParallelAsync();
            ShowResults(results);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        private async void ParallelExecuteAsync_2_Click(object sender, RoutedEventArgs e)
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += Progress_ProgressChanged;

            cts = new CancellationTokenSource();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                List<WebSiteInfoDataModel> results = await DemoAppMethods.DownloadParallel_V2_Async(progress, cts.Token); ;
                ShowResults(results);
            }
            catch(OperationCanceledException)
            {
                this.ResultTextBlock.Text += $"L'operazione di download è stata cancellata.{ Environment.NewLine }";
            }
            finally
            {
                cts.Dispose();
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            this.ResultTextBlock.Text += $"{ Environment.NewLine }Tempo di esecuzione totale: { elapsedMs } (ms).";
        }

        #endregion


        private void CancelOperation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cts?.Cancel();
            }
            catch (ObjectDisposedException)
            {
                System.Console.WriteLine("cts object is disposed, no opretation running.");
            }
        }


        private void Progress_ProgressChanged(object sender, ProgressReportModel e)
        {
            this.DownloadProgress.Value = e.PercentageCompleted;
            ShowResults(e.WebSitesDownloaded);
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
