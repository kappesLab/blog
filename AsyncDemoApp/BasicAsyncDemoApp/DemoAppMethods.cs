using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace BasicAsyncDemoApp
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


        public static WebSiteInfoDataModel DownloadWebSite(string urlWebSite)
        {
            WebSiteInfoDataModel result = new WebSiteInfoDataModel();
            WebClient client = new WebClient();

            result.Url = urlWebSite;
            result.Text = client.DownloadString(urlWebSite);

            return result;
        }


        public static async Task<WebSiteInfoDataModel> DownloadWebSiteAsync(string urlWebSite)
        {
            WebSiteInfoDataModel result = new WebSiteInfoDataModel();
            WebClient client = new WebClient();

            result.Url = urlWebSite;
            result.Text = await client.DownloadStringTaskAsync(urlWebSite);

            return result;
        }


    }
}
