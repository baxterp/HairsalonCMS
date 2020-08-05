using HairDemoSite.Areas.Public.Data.SiteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDemoSite.Areas.Public.Models
{
    public class StartPageFlatData
    {
        private siteDataDbContext context;

        public StartPageFlatData(siteDataDbContext context)
        {
            this.context = context;

            try
            {
                OurServicesMessage = context.MpFlatPageData.Select(s => s.OurServicesMessage).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string OurServicesMessage { get; set; }
    }
}
