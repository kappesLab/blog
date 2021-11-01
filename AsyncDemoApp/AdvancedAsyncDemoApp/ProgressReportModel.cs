using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAsyncDemoApp
{
    public class ProgressReportModel
    {
        public int PercentageCompleted { get; set; } = 0;
        public List<WebSiteInfoDataModel> WebSitesDownloaded { get; set; } = new List<WebSiteInfoDataModel>();
    }
}
