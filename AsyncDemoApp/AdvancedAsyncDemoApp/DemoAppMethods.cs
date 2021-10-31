using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemoApp
{
    public static class DemoAppMethods
    {
        public static List<string> GetUrlWebSites()
        {
            List<string> result = new List<string>()
            {
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.codeproject.com",
                "https://www.nytimes.com",
                "https://www.arduino.cc",
                "https://en.wikipedia.org/wiki/.net",
                "https://www.nationalgeographic.com",
                "https://www.libreoffice.org",
                "https://edition.cnn.com/"
            };

            return result;
        }

        public static List<WebSiteInfoDataModel> Download()
        {
            List<string> sites = GetUrlWebSites();
            List<WebSiteInfoDataModel> results = new List<WebSiteInfoDataModel>();

            foreach (string item in sites)
            {
                WebSiteInfoDataModel infoData = DownloadWebSite(item);
                results.Add(infoData);
            }

            return results;
        }

        public static List<WebSiteInfoDataModel> DownloadParallel()
        {
            List<string> sites = GetUrlWebSites();
            List<WebSiteInfoDataModel> results = new List<WebSiteInfoDataModel>();

            Parallel.ForEach<string>(sites, (item) =>
            {
                WebSiteInfoDataModel infoData = DownloadWebSite(item);
                results.Add(infoData);
            });

            return results;
        }

        public static async Task<List<WebSiteInfoDataModel>> DownloadAsync(IProgress<ProgressReportModel>progress, CancellationToken cancellationToken)
        {
            List<string> sites = GetUrlWebSites();
            List<WebSiteInfoDataModel> results = new List<WebSiteInfoDataModel>();
            ProgressReportModel report = new ProgressReportModel();

            foreach (string item in sites)
            {
                WebSiteInfoDataModel infoData = await DownloadWebSiteAsync(item);
                results.Add(infoData);

                cancellationToken.ThrowIfCancellationRequested();

                report.WebSitesDownloaded = results;
                report.PercentageCompleted = (results.Count * 100) / sites.Count;
                progress.Report(report);
            }

            return results;
        }

        public static async Task<List<WebSiteInfoDataModel>> DownloadParallelAsync()
        {
            List<string> sites = GetUrlWebSites();
            List<Task<WebSiteInfoDataModel>> downloadTasks = new List<Task<WebSiteInfoDataModel>>();

            foreach (string item in sites)
            {
                downloadTasks.Add(DownloadWebSiteAsync(item));
            }

            WebSiteInfoDataModel[] results = await Task.WhenAll(downloadTasks);

            return new List<WebSiteInfoDataModel>(results);
        }

        public static async Task<List<WebSiteInfoDataModel>> DownloadParallel_V2_Async(IProgress<ProgressReportModel>progress, CancellationToken cancellationToken)
        {
            List<string> sites = GetUrlWebSites();
            List<WebSiteInfoDataModel> results = new List<WebSiteInfoDataModel>();
            ProgressReportModel report = new ProgressReportModel();

            // Use ParallelOptions instance to store the CancellationToken
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cancellationToken;
            po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            await Task.Run(() =>
            {
                try
                {
                    Parallel.ForEach<string>(sites, po, (item) =>
                    {
                        WebSiteInfoDataModel infoData = DownloadWebSite(item);
                        results.Add(infoData);

                        report.WebSitesDownloaded = results;
                        report.PercentageCompleted = (results.Count * 100) / sites.Count;
                        progress.Report(report);
                    });
                }
                catch (OperationCanceledException ex)
                {
                    System.Console.WriteLine("SONO QUI");
                }            
            }, cancellationToken);
           

            return new List<WebSiteInfoDataModel>(results);
        }


        private static WebSiteInfoDataModel DownloadWebSite(string urlWebSite)
        {
            WebSiteInfoDataModel result = new WebSiteInfoDataModel();
            WebClient client = new WebClient();

            result.Url = urlWebSite;
            result.Text = client.DownloadString(urlWebSite);

            return result;
        }

        private static async Task<WebSiteInfoDataModel> DownloadWebSiteAsync(string urlWebSite)
        {
            WebSiteInfoDataModel result = new WebSiteInfoDataModel();
            WebClient client = new WebClient();

            result.Url = urlWebSite;
            result.Text = await client.DownloadStringTaskAsync(urlWebSite);

            return result;
        }

    }
}
